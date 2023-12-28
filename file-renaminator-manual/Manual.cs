using System;
using System.IO;

class Manual {
	static void Main() {
		Boolean ValidPath = false;
		string FolderPath = "";

		Console.WriteLine("Input the folder path [X to exit]");

		// Checks if Path is valid
		while (!ValidPath) {
			FolderPath = Console.ReadLine()!;
			if (FolderPath.Trim().Length > 0) {
				if (Directory.Exists(FolderPath)) {
					ValidPath = true;
				} else if (FolderPath.ToLower() == "x") {
					Environment.Exit(0);
				} else {
					Console.WriteLine("Invalid Path");
				}
			}
		}
		if (ValidPath) Console.WriteLine("Path Found!");

		// Gets the files in the Path
		string[] FilesFound = Directory.GetFiles(FolderPath);
		int FoundAmount = FilesFound.Length;

		// Confirmation to Proceed
		Console.WriteLine($"{FoundAmount} files found. Do you wish to proceed ? [Y/N]");
		Boolean Proceed = false;
		while (!Proceed) {
			ConsoleKey Confirmation = Console.ReadKey(true).Key;
			if (Confirmation == ConsoleKey.N) {
				Console.WriteLine("Cancelling process");
				Console.ReadKey(true);
				Environment.Exit(0);
			} else if (Confirmation == ConsoleKey.Y) { Proceed = true; }
		}

		// Asks for the Name
		Console.WriteLine("Provide a common Name: ");
		string? Name = Console.ReadLine();
		if (Name != null) {
			string[] NameArray = Name.Split(" ");
			Name = String.Join("-", NameArray);
		}

		int Count = 1;
		foreach (string FilePath in FilesFound) {
			string NewName;
			string NewPath;
			string FileExtension = Path.GetExtension(FilePath);
			string PathArray = Path.GetDirectoryName(FilePath)!;
			string OldName = FilePath.Split("\\")[^1];

			if (Name != "") {
				NewName = $"@{Name}[{Count}]{FileExtension}";
			} else { NewName = $"{Count}.{FileExtension}"; }

			NewPath = Path.Combine(PathArray, NewName);
			File.Move(FilePath, NewPath);
			Logger(OldName, NewName);
			Count++;
		}

		static void Logger(string OldName, string NewName) {
			string Now = DateTime.Now.ToShortTimeString();
			Console.WriteLine($"[INFO * {Now}] : '{OldName}' renamed to '{NewName}'.");
		}
	}
}