using System.Drawing;
using System.Drawing.Printing;

namespace Presentation
{
    public class Printer
    {
        private string _text;
        PrintDocument PD = new PrintDocument();
        public Printer()
        {
            var printer = PrinterSettings.InstalledPrinters[0];
            var PS = new PrinterSettings {PrinterName = printer};
            PD.PrinterSettings = PS;
            PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);
        }

        public void Print(string text)
        {
            _text = text;
            PD.Print();
            
        }
        
        private void PD_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font PrintFont = new Font("Times New Roman", 16, FontStyle.Regular, GraphicsUnit.Millimeter);
            e.Graphics.DrawString(_text, PrintFont, Brushes.Black, new PointF(20, 20));
        }
    }
}