using System.Collections.Generic;
using System.IO;
using System.Linq;
using org.pdfclown.files;
using File = System.IO.File;

namespace ImgConverter
{
    public class PdfUtils : IPdfUtils
    {
        private readonly string _src;

        public PdfUtils()
        {
        }

        public PdfUtils(string src)
        {
            _src = src;
        }

        public void MergePdfDocuments(string destFile)
        {
            var list = Directory.GetFiles(Path.GetFullPath(_src));
            if (string.IsNullOrWhiteSpace(_src) || string.IsNullOrWhiteSpace(destFile) || list.Length <= 1)
                return;
            var files = list.Select(File.ReadAllBytes).ToList();
            using (var dest = new org.pdfclown.files.File(new org.pdfclown.bytes.Buffer(files[0])))
            {
                var document = dest.Document;
                var builder = new org.pdfclown.tools.PageManager(document);
                foreach (var file in files.Skip(1))
                {
                    using (var src = new org.pdfclown.files.File(new org.pdfclown.bytes.Buffer(file)))
                    { builder.Add(src.Document); }
                }

                dest.Save(destFile, SerializationModeEnum.Incremental);
            }
        }

        public byte[] MergePdfDocuments(List<byte[]> files)
        {
            if (files == null)
                return null;
            if (files.Count == 1)
                return files[0];
            using (var dest = new org.pdfclown.files.File(new org.pdfclown.bytes.Buffer(files[0])))
            {
                var document = dest.Document;
                var builder = new org.pdfclown.tools.PageManager(document);
                foreach (var file in files.Skip(1))
                {
                    using (var src = new org.pdfclown.files.File(new org.pdfclown.bytes.Buffer(file)))
                    { builder.Add(src.Document); }
                }

                using (var output = new org.pdfclown.bytes.Buffer())
                {
                    dest.Save(output, SerializationModeEnum.Incremental);
                    return output.ToByteArray();
                }
            }
        }

        public void SaveByteToPdf(byte[] bytes, string src)
        {
            using (var ms = new MemoryStream(bytes))
            {
                using (org.pdfclown.bytes.IInputStream stream = new org.pdfclown.bytes.Stream(ms))
                {
                    using (var file = new org.pdfclown.files.File(stream))
                    {
                        file.Save(src, SerializationModeEnum.Standard);
                    }
                }
            }
        }
    }
}
