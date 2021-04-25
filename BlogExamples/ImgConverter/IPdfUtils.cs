using System.Collections.Generic;

namespace ImgConverter
{
    public interface IPdfUtils
    {
        void MergePdfDocuments(string destFile);
        byte[] MergePdfDocuments(List<byte[]> files);
        void SaveByteToPdf(byte[] bytes, string src);
    }
}
