using System.IO;
using ImageMagick;

namespace ImgConverter
{
    public class ImageUtils : IImageUtils
    {
        private readonly FileInfo[] _files;

        public ImageUtils(string filesPath)
        {
            _files = new DirectoryInfo(filesPath).GetFiles();
        }

        /**
         * Convert AI, EPS, PDF and PS file to any image file format
         */
        public void ConvertToImage(string dest, MagickFormat format = MagickFormat.Jpg)
        {
            using (var images = new MagickImageCollection())
            {
                foreach (var file in _files)
                {
                    var image = new MagickImage(file)
                    {
                        Format = format,
                        Depth = 8,
                    };
                    images.Add(image);
                }

                foreach (var image in images)
                {
                    var file = Path.GetFileNameWithoutExtension(new FileInfo(image.FileName).Name);
                    image.Write(Path.Combine(dest, $"{file}.{format.ImageExt()}"));
                }

                images.Dispose();
            }
        }
    }
}
