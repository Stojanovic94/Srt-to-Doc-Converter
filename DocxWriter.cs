using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using WordDocument = DocumentFormat.OpenXml.Wordprocessing.Document;

namespace Srt_to_Doc_Converter
{
    public static class DocxWriter
    {
        public static void Write(string path, string text)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? ".");

            using var document = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document);
            var mainPart = document.AddMainDocumentPart();
            mainPart.Document = new WordDocument();
            var body = mainPart.Document.AppendChild(new Body());

            var paragraphs = (text ?? string.Empty)
                .Replace("\r\n", "\n")
                .Split('\n');

            if (paragraphs.Length == 0)
            {
                body.AppendChild(new Paragraph(new Run(new Text(string.Empty))));
            }
            else
            {
                foreach (var line in paragraphs)
                {
                    var paragraph = new Paragraph();
                    var run = new Run();
                    run.AppendChild(new RunProperties(
                        new RunFonts { Ascii = "Calibri", HighAnsi = "Calibri" },
                        new FontSize { Val = "22" }));
                    run.AppendChild(new Text(line) { Space = SpaceProcessingModeValues.Preserve });
                    paragraph.AppendChild(run);
                    body.AppendChild(paragraph);
                }
            }

            body.AppendChild(new SectionProperties(
                new PageMargin
                {
                    Top = 720,
                    Right = 720,
                    Bottom = 720,
                    Left = 720
                }));

            mainPart.Document.Save();
        }

        public static string GetOutputPath(string sourcePath, string outputDirectory)
        {
            var fileName = Path.GetFileNameWithoutExtension(sourcePath) + ".docx";
            return Path.Combine(outputDirectory, fileName);
        }

        public static string UniquePath(string path)
        {
            if (!File.Exists(path))
            {
                return path;
            }

            var directory = Path.GetDirectoryName(path) ?? string.Empty;
            var name = Path.GetFileNameWithoutExtension(path);
            var extension = Path.GetExtension(path);
            var index = 2;

            string candidate;
            do
            {
                candidate = Path.Combine(directory, $"{name} ({index}){extension}");
                index++;
            }
            while (File.Exists(candidate));

            return candidate;
        }
    }
}
