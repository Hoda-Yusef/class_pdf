using System;
using iTextSharp.text;
using iTextSharp;
using System.IO;

namespace class_pdf
{
    public class Program
    {
        Document myDocument = new Document();
        
        
        public static void Main(string[] args)
        {
            int[,] numbers = new int[10,10];
            for(int i=0;i<10;i++)
            {
                for(int j=0;j<10;j++)
                {
                    numbers[i,j] = i;
                }
            }

            Program pr = new Program();
            pr.SetImage("apple.png");
            pr.CloseReport();
            

            
        }

        public Program()
        {
            
            iTextSharp.text.pdf.PdfWriter.GetInstance(myDocument, new FileStream("myDocument.pdf", FileMode.Create));
            myDocument.Open();
        }

        public Program(string file_name)
        {
            
            iTextSharp.text.pdf.PdfWriter.GetInstance(myDocument, new FileStream(file_name+".pdf", FileMode.Create));
            myDocument.Open();
        }

        public void SetTitle(string title)
        {
            Font myFont = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, Font.ITALIC);
            myDocument.Add(new Paragraph(title,myFont));
        }

        public void SetImage(string imagePath)
        {
           
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagePath);
            img.ScalePercent(50f);
            myDocument.Add(img);
            
        }

        public void SetIntTable(int[,] table)
        {
            iTextSharp.text.pdf.PdfPTable myTable = new iTextSharp.text.pdf.PdfPTable(10);
            myTable.HorizontalAlignment = Element.ALIGN_CENTER;

            //set coloumn width in percent
            float[] widthCell = new float[10];
            for (int i = 0; i < 10; i++)
                widthCell[i] = 10;
            myTable.SetTotalWidth(widthCell);

            iTextSharp.text.pdf.PdfPCell myCell = new iTextSharp.text.pdf.PdfPCell();
            myCell.GrayFill = 0.5F;
            myCell.FixedHeight = 20;

            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    myCell.Phrase = new Phrase(table[i,j].ToString());
                    myTable.AddCell(myCell);
                }

            }

            myDocument.Add(myTable);
        }

        public void CloseReport()
        {
            myDocument.Close();
        }
    }
}
