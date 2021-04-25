using System;
using System.IO;
using ImageMagick;

namespace ImgConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }

        public static void TestImageUtils(string[] args)
        {
            var src = @"C:\temp\img\input";
            var dest = @"C:\temp\img\output";

            var iu = new ImageUtils(src);
            iu.ConvertToImage(dest);
        }

        public static void MergePdfTest()
        {
            var src = @"C:\temp\pdf\input";
            var dest = @"c:\temp\pdf\output\merged.pdf";

            var pu = new PdfUtils(src);
            pu.MergePdfDocuments(dest);
        }
    }
}
