namespace FileLibrary
{
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using System.Linq;

    public static partial class FileByte
	{
		public static byte[] ConvertFilePathToByte(string fullPathFile)
        {
			string curFile = $@"{fullPathFile}";

			return File.Exists(curFile) ? 
				File.ReadAllBytes(curFile) :
				new byte[0];
		}

		public static bool SaveByteInPath(string path, string fileNameAndType, byte[] bytes)
		{
			try
			{
				if (Directory.Exists(path))
				{
					File.WriteAllBytes($@"{path}\{fileNameAndType}", bytes);

					return true;
				}

				return false;
			}
            catch
            {
				return false;
            }
		}

		public static byte[] ConvertFormFileToBytes(IFormFile file)
		{
			byte[] CoverFileBytes = null;
			try
			{
				BinaryReader reader = new BinaryReader(file.OpenReadStream());
				CoverFileBytes = reader.ReadBytes((int)file.Length);
				return CoverFileBytes;
			}
			catch
			{
				return CoverFileBytes;
			}
		}

		public static string GetNameAndType(string fullPathFile)
		{
			return GetProperties(fullPathFile);
		}

		public static string GetType(string fullPathFile)
		{
			var file = GetProperties(fullPathFile);
			if (!string.IsNullOrEmpty(file))
			{
				var last = GetProperties(fullPathFile);

				return last.Substring(last.Length -3, 3);
			}
			else
				return string.Empty;
		}

		public static string GetName(string fullPathFile)
		{
			var file = GetProperties(fullPathFile);
			if (!string.IsNullOrEmpty(file))
			{
				var last = GetProperties(fullPathFile);
				return last.Remove(last.Length - 4);
			}
			else
				return string.Empty;
		}

		private static string GetProperties(string fullPathFile)
		{
			try
			{
				int index = fullPathFile.LastIndexOf(@"\");
				if (index == 0)
					return string.Empty;

				var path = fullPathFile.Substring(0, index);

				if (Directory.Exists(path))
				{
					var pathFile = fullPathFile.Split('\\');
					return pathFile.Last();
				}

				return string.Empty;
			}
			catch
			{
				return string.Empty;
			}
		}
	}
}
