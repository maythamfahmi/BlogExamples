using SelectPdf;
using System;
using System.IO;

namespace PdfGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string invoice = CreateInvoice();
            string saveTo = @"c:\temp\invoice.pdf";

            if (invoice != null)
            {
                Console.WriteLine("Done");
                HtmlToPdf(invoice, saveTo);
            }
        }

        private static string CreateInvoice()
        {
            var root = AppDomain.CurrentDomain.BaseDirectory;

            var template = $"{root}\\template\\invoice.html";

            if (!File.Exists(template))
            {
                return null;
            }

            return File.ReadAllText(template);
        }

        private static void HtmlToPdf(string htmlDoc, string outputFolder)
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(htmlDoc);

            // save pdf document
            doc.Save(outputFolder);

            // close pdf document
            doc.Close();
        }

    }
}

