using Renaminator;
using System.Diagnostics;
using System.Text.RegularExpressions;

class Automatic {
	static void Main() {
		Stopwatch Timer = new Stopwatch();
		Timer.Start();

		string CurrentPath = Environment.CurrentDirectory;
		if (!Path.Exists(CurrentPath)) Environment.Exit(0);
		string[] FilesFound = Directory.GetFiles(CurrentPath);
		Console.WriteLine($"{FilesFound.Length} files found in '{CurrentPath}'");

		int Count = 1;
		int FilesChanged = 0;
		string CommonName = String.Join("-", Path.GetFileName(CurrentPath)!.Split(" "));

		foreach (string FilePath in FilesFound) {
			string OldName = Path.GetFileName(FilePath);
			string FileExtension = Path.GetExtension(FilePath);

			Correction Uooh = IsCorrectionNeeded(OldName, FileExtension);
			if (Uooh == Correction.EXE) {
				Logger.Log(OldName, "is an executable", LogLevel.INFO);
				continue;
			} else if (Uooh == Correction.ANGEL) {
				Logger.Log(OldName, "is already corrected", LogLevel.INFO);
				continue;
			}

			try {
				string NewName = GetNewFileName(FileExtension);
				string NewPath = GetNewFilePath(NewName);
				File.Move(FilePath, NewPath);
				Count++;
				FilesChanged++;
				Logger.Log(OldName, NewName);
			} catch (Exception ex) {
				Logger.Log(OldName, ex.Message, LogLevel.ERROR);
				continue;
			}
		}

		Timer.Stop();
		Console.WriteLine($"{FilesChanged} files were renamed in {Timer.Elapsed.TotalSeconds:F2} seconds");
		Console.ReadKey();

		Correction IsCorrectionNeeded(string OldName, string FileExtension) {
			Regex CheckName = new Regex($"\\@{CommonName}\\[\\d+\\]$", RegexOptions.IgnoreCase);
			Match Corrected = CheckName.Match(OldName.Split(".")[0]);
			if (FileExtension == ".exe") return Correction.EXE;
			else if (Corrected.Success) return Correction.ANGEL;
			else return Correction.BRAT;
		}

		string GetNewFilePath(string NewName) {
			return Path.Combine(CurrentPath, NewName);
		}

		string GetNewFileName(string FileExtension) {
			if (Count > FilesFound.Length) throw new Exception("Unable to get a new name after multiple attempts");
			string NewName = $"@{CommonName.ToLower()}[{Count}]";
			Boolean IsFileUnique = FileDuplicationCheck.IsUnique(CurrentPath, NewName, FileExtension);
			if (IsFileUnique) return $"{NewName}{FileExtension}";
			else {
				Count++;
				return GetNewFileName(FileExtension);
			}
		}
	}
}

public enum LogLevel {
	INFO,
	ERROR,
}

public enum Correction {
	EXE,
	ANGEL,
	BRAT
}