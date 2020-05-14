using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MongoUtiliyProcessWrapper {
	public abstract class MongoComponentProcessAbstractWrapper : IProcessWrapper {
		protected MongoComponentProcessAbstractWrapper(string componentPath, string mongodbURI) {
			this.FileName = componentPath;
			this.Args.Add(FormatUriArg(mongodbURI));
		}

		/// <summary>
		/// Generates <see cref="ProcessStartInfo"/> based on currently available info
		/// (<see cref="MongoComponentProcessAbstractWrapper.FileName"/>, <see cref="MongoComponentProcessAbstractWrapper.MongoDbUri"/> etc)
		/// </summary>
		/// <returns>Instance of <see cref="ProcessStartInfo"/></returns>
		public ProcessStartInfo GetProcessStartInfo() =>
			new ProcessStartInfo {
				FileName = FileName,
				Arguments = Args != null && Args.Any() ? string.Join(" ", Args) : string.Empty,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
			};

		/// <summary> Formats given uri in arguments line </summary>
		/// <param name="uriValue"> uri in format: "mongodb://{host}:{port}/{dbName}"</param>
		/// <example> "mongodb://mongodb0.example.com:27017/TestDb" </example>
		/// <example> "mongodb://localhost:27017/TestDb" </example>
		/// /// <returns>formatted string</returns>
		public string FormatUriArg(string uriValue) => $"--uri={uriValue}";

		#region IProcessWrapper members

		/// <inheritdoc/>
		public Process GetProcess(ProcessStartInfo info = null) {
			var componentProcess = new Process { StartInfo = info ?? GetProcessStartInfo() };
			//componentProcess.OutputDataReceived += new DataReceivedEventHandler(this.OnProcessMessage);
			componentProcess.ErrorDataReceived += new DataReceivedEventHandler(this.OnProcessErrorMessage);

			componentProcess.Start();

			componentProcess.BeginOutputReadLine();
			componentProcess.BeginErrorReadLine();

			return componentProcess;
		}

		/// <inheritdoc/>
		public Action<object, DataReceivedEventArgs> OnProcessMessage { get; set; } = (s, e) => Console.WriteLine(e.Data);

		/// <inheritdoc/>
		public Action<object, DataReceivedEventArgs> OnProcessErrorMessage { get; set; } = (s, e) => Console.Error.WriteLine(e.Data);

		/// <inheritdoc/>
		public List<string> Args { get; } = new List<string>();

		/// <inheritdoc/>
		public string FileName { get; set; }
		
		#endregion
	}

}
