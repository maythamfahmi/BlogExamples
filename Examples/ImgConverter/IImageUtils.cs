using ImageMagick;

namespace ImgConverter
{
    public interface IImageUtils
    {
        void ConvertToImage(string dest, MagickFormat format = MagickFormat.Jpg);
    }
}
