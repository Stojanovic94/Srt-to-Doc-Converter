using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Srt_to_Doc_Converter
{
    public sealed class SrtConversionOptions
    {
        public bool SeparateCues { get; set; }
        public bool StripFormattingTags { get; set; } = true;
    }

    /// <summary>
    /// Parses SRT subtitle files into readable document text.
    /// </summary>
    public static class SrtConverter
    {
        private static readonly Regex TimestampLine = new Regex(
            @"^\d{1,2}:\d{2}:\d{2}[,.]\d{1,3}\s*-->\s*\d{1,2}:\d{2}:\d{2}[,.]\d{1,3}",
            RegexOptions.Compiled);

        private static readonly Regex HtmlTag = new Regex(@"</?[^>]+>", RegexOptions.Compiled);

        public static string ToPlainText(string srtContent, SrtConversionOptions options = null)
        {
            options ??= new SrtConversionOptions();

            if (string.IsNullOrWhiteSpace(srtContent))
            {
                return string.Empty;
            }

            var cues = ParseCues(srtContent, options.StripFormattingTags);
            if (cues.Count == 0)
            {
                return string.Empty;
            }

            if (options.SeparateCues)
            {
                return string.Join(Environment.NewLine + Environment.NewLine, cues);
            }

            return string.Join(" ", cues);
        }

        private static List<string> ParseCues(string srtContent, bool stripTags)
        {
            var cues = new List<string>();
            var cueLines = new List<string>();

            using (var reader = new System.IO.StringReader(NormalizeNewLines(srtContent)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        AddCue(cues, cueLines, stripTags);
                        continue;
                    }

                    var trimmed = line.Trim();
                    if (IsIndexLine(trimmed) && cueLines.Count == 0)
                    {
                        continue;
                    }

                    if (TimestampLine.IsMatch(trimmed))
                    {
                        continue;
                    }

                    cueLines.Add(trimmed);
                }
            }

            AddCue(cues, cueLines, stripTags);
            return cues;
        }

        private static void AddCue(List<string> cues, List<string> cueLines, bool stripTags)
        {
            if (cueLines.Count == 0)
            {
                return;
            }

            var text = string.Join(" ", cueLines);
            if (stripTags)
            {
                text = HtmlTag.Replace(text, string.Empty);
            }

            text = CollapseWhitespace(text);
            if (!string.IsNullOrWhiteSpace(text))
            {
                cues.Add(text);
            }

            cueLines.Clear();
        }

        private static bool IsIndexLine(string line)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (!char.IsDigit(line[i]))
                {
                    return false;
                }
            }

            return line.Length > 0;
        }

        private static string NormalizeNewLines(string value)
        {
            return value.Replace("\r\n", "\n").Replace('\r', '\n');
        }

        private static string CollapseWhitespace(string value)
        {
            var builder = new StringBuilder(value.Length);
            var previousWasSpace = false;

            foreach (var c in value)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!previousWasSpace)
                    {
                        builder.Append(' ');
                        previousWasSpace = true;
                    }
                }
                else
                {
                    builder.Append(c);
                    previousWasSpace = false;
                }
            }

            return builder.ToString().Trim();
        }
    }
}
