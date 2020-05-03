namespace MongoUtiliyProcessWrapper.MessageParser {
	interface IProcessMessageParser {
		MongodumpMessage ParseMessage(string message);
	}
}
