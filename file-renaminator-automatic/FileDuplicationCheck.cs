namespace Automatic_Renaminator;

public class FileDuplicationCheck {
	public static Boolean? IsUnique(string CurrentPath, string FileName, string FileExtension) {
		List<string> ImageExtensions = [".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".tif", ".webp", ".svg"];
		List<string> VideoExtensions = [".mp4", ".avi", ".mkv", ".mov", ".wmv", ".flv", ".webm", ".mpeg", ".mpg", ".3gp"];
		List<string> AudioExtensions = [".mp3", ".wav", ".ogg", ".flac", ".aac", ".wma", ".m4a", ".ape", ".opus", ".pcm"];

		if (ImageExtensions.Contains(FileExtension)) {
			return IsImageFileUnique(CurrentPath, FileName);
		} else if (VideoExtensions.Contains(FileExtension)) {
			return IsVideoFileUnique(CurrentPath, FileName);
		} else if (AudioExtensions.Contains(FileExtension)) {
			return IsAudioFileUnique(CurrentPath, FileName);
		} else return null;
	}

	// Returns false if not unique;
	public static Boolean IsImageFileUnique(string CurrentPath, string FileName) {
		Boolean GIF = File.Exists(Path.Combine(CurrentPath, $"{FileName}.gif"));
		Boolean PNG = File.Exists(Path.Combine(CurrentPath, $"{FileName}.png"));
		Boolean JPG = File.Exists(Path.Combine(CurrentPath, $"{FileName}.jpg"));
		Boolean JPEG = File.Exists(Path.Combine(CurrentPath, $"{FileName}.jpeg"));
		Boolean BMP = File.Exists(Path.Combine(CurrentPath, $"{FileName}.bmp"));
		Boolean TIFF = File.Exists(Path.Combine(CurrentPath, $"{FileName}.tiff"));
		Boolean TIF = File.Exists(Path.Combine(CurrentPath, $"{FileName}.tif"));
		Boolean WEBP = File.Exists(Path.Combine(CurrentPath, $"{FileName}.webp"));
		Boolean SVG = File.Exists(Path.Combine(CurrentPath, $"{FileName}.svg"));

		return !(PNG || JPG || GIF || JPEG || BMP || TIFF || TIF || WEBP || SVG);
	}

	public static Boolean IsVideoFileUnique(string CurrentPath, string FileName) {
		Boolean MP4 = File.Exists(Path.Combine(CurrentPath, $"{FileName}.mp4"));
		Boolean AVI = File.Exists(Path.Combine(CurrentPath, $"{FileName}.avi"));
		Boolean MKV = File.Exists(Path.Combine(CurrentPath, $"{FileName}.mkv"));
		Boolean MOV = File.Exists(Path.Combine(CurrentPath, $"{FileName}.mov"));
		Boolean WMV = File.Exists(Path.Combine(CurrentPath, $"{FileName}.wmv"));
		Boolean FLV = File.Exists(Path.Combine(CurrentPath, $"{FileName}.flv"));
		Boolean WEBM = File.Exists(Path.Combine(CurrentPath, $"{FileName}.webm"));
		Boolean MPEG = File.Exists(Path.Combine(CurrentPath, $"{FileName}.mpeg"));
		Boolean MPG = File.Exists(Path.Combine(CurrentPath, $"{FileName}.mpg"));
		Boolean _3GP = File.Exists(Path.Combine(CurrentPath, $"{FileName}.3gp"));

		return !(MP4 || AVI || MKV || MOV || WMV || FLV || WEBM || MPEG || MPG || _3GP);
	}

	public static Boolean IsAudioFileUnique(string CurrentPath, string FileName) {
		Boolean MP3 = File.Exists(Path.Combine(CurrentPath, $"{FileName}.mp3"));
		Boolean WAV = File.Exists(Path.Combine(CurrentPath, $"{FileName}.wav"));
		Boolean OGG = File.Exists(Path.Combine(CurrentPath, $"{FileName}.ogg"));
		Boolean FLAC = File.Exists(Path.Combine(CurrentPath, $"{FileName}.flac"));
		Boolean AAC = File.Exists(Path.Combine(CurrentPath, $"{FileName}.aac"));
		Boolean WMA = File.Exists(Path.Combine(CurrentPath, $"{FileName}.wma"));
		Boolean M4A = File.Exists(Path.Combine(CurrentPath, $"{FileName}.m4a"));
		Boolean APE = File.Exists(Path.Combine(CurrentPath, $"{FileName}.ape"));
		Boolean OPUS = File.Exists(Path.Combine(CurrentPath, $"{FileName}.opus"));
		Boolean PCM = File.Exists(Path.Combine(CurrentPath, $"{FileName}.pcm"));

		return !(MP3 || WAV || OGG || FLAC || AAC || WMA || M4A || APE || OPUS || PCM);
	}
}
