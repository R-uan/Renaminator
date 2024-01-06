namespace Renaminator;

public class Logger {
	public static void Log(string OldName, string NewName) {
		string Now = DateTime.Now.ToShortTimeString();
		Console.WriteLine($"[{LogLevel.INFO} * {Now}] : '{OldName}' renamed to '{NewName}'.");
	}

	public static void Log(string OldName, string Message, LogLevel Level) {
		string Now = DateTime.Now.ToShortTimeString();
		if (Level == LogLevel.INFO) {
			Console.WriteLine($"[{Level} * {Now}] : '{OldName}': {Message}.");
		} else if (Level == LogLevel.ERROR) {
			Console.WriteLine($"[{Level} * {Now}] : Failed to rename '{OldName}': {Message}.");
		}
	}

}
