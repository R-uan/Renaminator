using System;
using System.IO;
using System.Diagnostics;
using Automatic_Renaminator;
using System.Text.RegularExpressions;
class Automatic {
	static void Main() {
		string CurrentPath = Environment.CurrentDirectory;
		if (!Path.Exists(CurrentPath)) Environment.Exit(0);

		string[] FilesFound = Directory.GetFiles(CurrentPath);
		Console.WriteLine($"{FilesFound.Length} files found in '{CurrentPath}'");

		string CommonName = String.Join("-", Path.GetFileName(CurrentPath)!.Split(" "));

		Stopwatch Timer = new Stopwatch();
		Timer.Start();

		int Count = 1;
		int FilesChanged = 0;
		foreach (string FilePath in FilesFound) {
			string OldName = Path.GetFileName(FilePath);
			string FileExtension = Path.GetExtension(FilePath);
			if (FileExtension == ".exe") continue;
			Regex CheckName = new Regex($"\\@{CommonName}\\[\\d+\\]$", RegexOptions.IgnoreCase);
			Match AlreadyInConvention = CheckName.Match(OldName.Split(".")[0]);
			if (AlreadyInConvention.Success) continue;
			string NewName = GetNewFileName(FilePath, FileExtension);
			string NewPath = $"{CurrentPath}\\{NewName}";
			try {
				File.Move(FilePath, NewPath);
			} catch (System.Exception) {
				Logger(OldName, NewName, LogLevel.ERROR);
			}
			Logger(OldName, NewName, LogLevel.INFO);
			Count++;
			FilesChanged++;
		}

		Timer.Stop();
		Double ElapsedTime = Timer.Elapsed.TotalSeconds;
		Console.WriteLine($"{FilesChanged} files were renamed in {ElapsedTime:F2} seconds");
		Console.ReadKey();
		string GetNewFilePath(string NewName) {
			string NewPath = $"{CurrentPath}\\{NewName}";
			return "";
		}
		string? GetNewFileName(string FilePath, string FileExtension) {
			string NewName = $"@{CommonName.ToLower()}[{Count}]";
			Boolean? IsFileUnique = FileDuplicationCheck.IsUnique(CurrentPath, FilePath, FileExtension);
			if (IsFileUnique == null) return null;
			else if (IsFileUnique.Value == false) { Count++; return GetNewFileName(FilePath, FileExtension); }
			return $"{NewName}{FileExtension}";
		}
		static void Logger(string OldName, string NewName, LogLevel Level) {
			string Now = DateTime.Now.ToShortTimeString();
			if (Level == LogLevel.INFO) {
				Console.WriteLine($"[{Level} * {Now}] : '{OldName}' renamed to '{NewName}'.");
			} else if (Level == LogLevel.ERROR) {
				Console.WriteLine($"[ERROR * {Now}] : 'Failed to rename: {OldName}' to: '{NewName}'.");
			}
		}

	}
}

public enum LogLevel {
	INFO,
	ERROR,
}