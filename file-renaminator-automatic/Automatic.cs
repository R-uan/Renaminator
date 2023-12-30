using System;
using System.IO;

class Automatic {
	static void Main() {
		string CurrentPath = Environment.CurrentDirectory;
		if (!Path.Exists(CurrentPath)) Environment.Exit(0);

		string CommonName = String.Join("-", Path.GetFileName(CurrentPath)!.Split(" "));
		string[] FilesFound = Directory.GetFiles(CurrentPath);
		Console.WriteLine($"{FilesFound.Length} files found in '{CurrentPath}'");

		int Count = 1;
		foreach (string FilePath in FilesFound) {
			string OldName = Path.GetFileName(FilePath);
			string NewName = GetNewFileName(FilePath);
			string NewPath = $"{CurrentPath}\\{NewName}";
			File.Move(FilePath, NewPath);
			Logger(OldName, NewName);
			Count++;
		}

		static void Logger(string OldName, string NewName) {
			string Now = DateTime.Now.ToShortTimeString();
			Console.WriteLine($"[INFO * {Now}] : '{OldName}' renamed to '{NewName}'.");
		}

		string GetNewFileName(string FilePath) {
			string NewName;
			string FileExtension = Path.GetExtension(FilePath);
			if (CommonName != "") {
				NewName = $"@{CommonName}[{Count}]{FileExtension}";
			} else { NewName = $"{Count}.{FileExtension}"; }

			Boolean CheckIfExists = Path.Exists($"{CurrentPath}\\{NewName}");
			if (CheckIfExists) {
				Count++;
				return GetNewFileName(FilePath);
			} else return NewName.ToLower();
		}
	}
}