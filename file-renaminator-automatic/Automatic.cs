using System;
using System.IO;

class Automatic {
	static void Main() {
		string PathName;
		string CurrentPath = Environment.CurrentDirectory;

		if (!Path.Exists(CurrentPath)) Environment.Exit(0);
		PathName = Path.GetFileName(CurrentPath)!;

		// Gets the files in the Path
		string[] FilesFound = Directory.GetFiles(CurrentPath);
		int FoundAmount = FilesFound.Length;

		// Asks for the Name
		if (PathName != null) {
			string[] NameArray = PathName.Split(" ");
			PathName = String.Join("-", NameArray);
		}

		int Count = 1;
		foreach (string FilePath in FilesFound) {
			string NewName;
			string NewPath;
			string FileExtension = Path.GetExtension(FilePath);
			string PathArray = Path.GetDirectoryName(FilePath)!;
			string OldName = FilePath.Split("\\")[^1];

			if (PathName != "") {
				NewName = $"@{PathName}[{Count}]{FileExtension}";
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