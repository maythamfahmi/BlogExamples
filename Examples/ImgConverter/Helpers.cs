using System;
using System.Collections.Generic;
using System.IO;
using ImageMagick;

namespace ImgConverter
{
    public static class Helpers
    {
        public static string GetRootPath()
        {
            return Directory.GetParent(Environment.CurrentDirectory)?.Parent?.FullName;
        }

        public static string ImageExt(this MagickFormat format)
        {
            return $".{format.ToString().ToLower()}";
        }

        public static List<string> AllowedImages()
        {
            return new List<string>() { ".png", ".jpg", ".bmp" };
        }
    }
}
