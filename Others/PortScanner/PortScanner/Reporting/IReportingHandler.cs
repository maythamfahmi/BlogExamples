using System.Windows.Forms;

namespace PortScanner.Reporting
{
    public interface IReportingHandler
    {
        void SetReportType(Enum.ReportType reportType);
        SaveFileDialog GetSaveFileDialog();
        string BuildTextFile(TextBox mainWindowTextBox);
        int GetReportType();
        void BuildWorkBook(TextBox mainWindowTextBox, string path);
        string GetSaveFileLocation(Enum.ReportType reportType);
    }
}