using System;
using System.IO;
using System.Text;

namespace Srt_to_Doc_Converter
{
    public static class SubtitleFileReader
    {
        public static string ReadAllText(string path)
        {
            var bytes = File.ReadAllBytes(path);
            if (bytes.Length == 0)
            {
                return string.Empty;
            }

            if (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
            {
                return Encoding.UTF8.GetString(bytes, 3, bytes.Length - 3);
            }

            var utf8 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
            try
            {
                return utf8.GetString(bytes);
            }
            catch (DecoderFallbackException)
            {
                return Encoding.GetEncoding(1250).GetString(bytes);
            }
        }
    }
}
