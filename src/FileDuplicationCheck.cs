namespace Renaminator;

public class FileDuplicationCheck {
	public static Boolean IsUnique(string CurrentPath, string NewName, string FileExtension) {
		List<string> ImageExtensions = [".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".tif", ".webp", ".svg"];
		List<string> VideoExtensions = [".mp4", ".avi", ".mkv", ".mov", ".wmv", ".flv", ".webm", ".mpeg", ".mpg", ".3gp"];
		List<string> AudioExtensions = [".mp3", ".wav", ".ogg", ".flac", ".aac", ".wma", ".m4a", ".ape", ".opus", ".pcm"];

		if (ImageExtensions.Contains(FileExtension)) {
			return IsImageFileUnique(CurrentPath, NewName);
		} else if (VideoExtensions.Contains(FileExtension)) {
			return IsVideoFileUnique(CurrentPath, NewName);
		} else if (AudioExtensions.Contains(FileExtension)) {
			return IsAudioFileUnique(CurrentPath, NewName);
		} else throw new Exception("Unable to find file extension");
	}

	// Returns false if not unique;
	public static Boolean IsImageFileUnique(string CurrentPath, string NewName) {
		Boolean GIF = File.Exists(Path.Combine(CurrentPath, $"{NewName}.gif"));
		Boolean PNG = File.Exists(Path.Combine(CurrentPath, $"{NewName}.png"));
		Boolean JPG = File.Exists(Path.Combine(CurrentPath, $"{NewName}.jpg"));
		Boolean JPEG = File.Exists(Path.Combine(CurrentPath, $"{NewName}.jpeg"));
		Boolean BMP = File.Exists(Path.Combine(CurrentPath, $"{NewName}.bmp"));
		Boolean TIFF = File.Exists(Path.Combine(CurrentPath, $"{NewName}.tiff"));
		Boolean TIF = File.Exists(Path.Combine(CurrentPath, $"{NewName}.tif"));
		Boolean WEBP = File.Exists(Path.Combine(CurrentPath, $"{NewName}.webp"));
		Boolean SVG = File.Exists(Path.Combine(CurrentPath, $"{NewName}.svg"));

		return !(PNG || JPG || GIF || JPEG || BMP || TIFF || TIF || WEBP || SVG);
	}

	public static Boolean IsVideoFileUnique(string CurrentPath, string NewName) {
		Boolean MP4 = File.Exists(Path.Combine(CurrentPath, $"{NewName}.mp4"));
		Boolean AVI = File.Exists(Path.Combine(CurrentPath, $"{NewName}.avi"));
		Boolean MKV = File.Exists(Path.Combine(CurrentPath, $"{NewName}.mkv"));
		Boolean MOV = File.Exists(Path.Combine(CurrentPath, $"{NewName}.mov"));
		Boolean WMV = File.Exists(Path.Combine(CurrentPath, $"{NewName}.wmv"));
		Boolean FLV = File.Exists(Path.Combine(CurrentPath, $"{NewName}.flv"));
		Boolean WEBM = File.Exists(Path.Combine(CurrentPath, $"{NewName}.webm"));
		Boolean MPEG = File.Exists(Path.Combine(CurrentPath, $"{NewName}.mpeg"));
		Boolean MPG = File.Exists(Path.Combine(CurrentPath, $"{NewName}.mpg"));
		Boolean _3GP = File.Exists(Path.Combine(CurrentPath, $"{NewName}.3gp"));

		return !(MP4 || AVI || MKV || MOV || WMV || FLV || WEBM || MPEG || MPG || _3GP);
	}

	public static Boolean IsAudioFileUnique(string CurrentPath, string NewName) {
		Boolean MP3 = File.Exists(Path.Combine(CurrentPath, $"{NewName}.mp3"));
		Boolean WAV = File.Exists(Path.Combine(CurrentPath, $"{NewName}.wav"));
		Boolean OGG = File.Exists(Path.Combine(CurrentPath, $"{NewName}.ogg"));
		Boolean FLAC = File.Exists(Path.Combine(CurrentPath, $"{NewName}.flac"));
		Boolean AAC = File.Exists(Path.Combine(CurrentPath, $"{NewName}.aac"));
		Boolean WMA = File.Exists(Path.Combine(CurrentPath, $"{NewName}.wma"));
		Boolean M4A = File.Exists(Path.Combine(CurrentPath, $"{NewName}.m4a"));
		Boolean APE = File.Exists(Path.Combine(CurrentPath, $"{NewName}.ape"));
		Boolean OPUS = File.Exists(Path.Combine(CurrentPath, $"{NewName}.opus"));
		Boolean PCM = File.Exists(Path.Combine(CurrentPath, $"{NewName}.pcm"));

		return !(MP3 || WAV || OGG || FLAC || AAC || WMA || M4A || APE || OPUS || PCM);
	}
}
