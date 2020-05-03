using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MongoUtiliyProcessWrapper {
	/// <summary>Describes behavior/functions of wrapper</summary>
	public interface IProcessWrapper {
		/// <summary><see cref="ProcessStartInfo.FileName"/> </summary>
		string FileName { get; set; }

		/// <summary>List of command line arguments which will be parsed to <seealso cref="ProcessStartInfo.Arguments"/> </summary>
		List<string> Args { get; }

		/// <summary>Action which will be invoked on each <see cref="Process.ErrorDataReceived"/></summary>
		/// <remarks>!Important! in case of using more than one handler possible problems with blocking of the subprocess</remarks>
		Action<object, DataReceivedEventArgs> OnProcessErrorMessage { get; set; }

		/// <summary>Action which will be invoked on each <see cref="Process.OutputDataReceived"/></summary>
		/// <remarks>!Important! in case of using more than one handler possible problems with blocking of the subprocess</remarks>
		Action<object, DataReceivedEventArgs> OnProcessMessage { get; set; }

		/// <summary>Create instance of <see cref="Process"/> for given <paramref name="info"/></summary>
		/// <param name="info"></param>
		/// <returns></returns>
		Process GetProcess(ProcessStartInfo info);
	}
}