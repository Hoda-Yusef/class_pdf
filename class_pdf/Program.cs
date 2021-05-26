using System;
using iTextSharp.text;
using iTextSharp;
using System.IO;

namespace class_pdf
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public Program()
        {
            Document myDocument = new Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(myDocument, new FileStream("myDocument.pdf", FileMode.Create));
        }

        public Program(string file_name)
        {
            Document myDocument = new Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(myDocument, new FileStream(file_name+".pdf", FileMode.Create));
        }

        public void SetTitle(string title)
        {
            Font myFont = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, Font.ITALIC);

        }

        public void SetImage(string imagePath)
        {

        }
    }
}
