using System;
using System.IO;
using System.Text;
using Xfinium.Pdf;
using Xfinium.Pdf.Graphics;
using Xfinium.Pdf.Forms;

namespace xfinium
{
    public class ReadAndFillPdf
    {
        public ReadAndFillPdf(Person person, String src, String dest)
        {
            Person = person;
            Src = src;
            Dest = dest;
        }

        public Person Person { get; }
        public string Src { get; }
        public string Dest { get; }

        public void Run()
        {
            PdfStandardFont helvetica = new PdfStandardFont(PdfStandardFontFace.Helvetica, 9);

            PdfBrush textBrush = new PdfBrush(PdfRgbColor.Black);
            PdfBrush checkBrush = new PdfBrush(PdfRgbColor.Red);

            FileStream srcFile = File.Open(Src, FileMode.Open, FileAccess.ReadWrite);

            var saveFile = File.Open(Dest, FileMode.Create);
            PdfFixedDocument document = new PdfFixedDocument(srcFile);

            // With fillable Forms
            // (document.Form.Fields["PatientName"] as PdfTextBoxField).Text = "John";
            // (document.Form.Fields["PatientDateOfBirth"] as PdfTextBoxField).Text = "07/07/1977";

            var page = document.Pages[0];
            page.Graphics.DrawString($"{Person.FirstName} {Person.LastName}", helvetica, textBrush, 100, 167);
            page.Graphics.DrawString($"{Person.DateOfBirth}", helvetica, textBrush, 120, 203);
            if (Person.Gender == "Male")
            {
                page.Graphics.DrawString("X", helvetica, checkBrush, 242, 204);
            }
            else
            {
                page.Graphics.DrawString("X", helvetica, checkBrush, 304, 204);
            }
            page.Graphics.DrawString($"{Person.PhoneNumber}", helvetica, textBrush, 435, 203);
            page.Graphics.DrawString("65 Main St PO Box 65", helvetica, textBrush, 127, 239);
            page.Graphics.DrawString("Dublin", helvetica, textBrush, 85, 277);
            page.Graphics.DrawString("OH", helvetica, textBrush, 267, 277);
            page.Graphics.DrawString("43106", helvetica, textBrush, 443, 277);

            page.Graphics.DrawString("Medical Mutual", helvetica, textBrush, 128, 329);
            page.Graphics.DrawString("Bob's Used Car Lot", helvetica, textBrush, 103, 365);
            page.Graphics.DrawString("10/01/2017", helvetica, textBrush, 80, 402);
            page.Graphics.DrawString("#567XY24", helvetica, textBrush, 260, 402);
            page.Graphics.DrawString("W.04.12", helvetica, textBrush, 432, 402);

            page.Graphics.DrawString("Dr Bob", helvetica, textBrush, 125, 454);
            page.Graphics.DrawString("#QX678Z86", helvetica, textBrush, 388, 454);
            page.Graphics.DrawString("(746) 222 - 5687", helvetica, textBrush, 90, 491);
            page.Graphics.DrawString("(746) 254 - 9712", helvetica, textBrush, 330, 491);

            page.Graphics.DrawString("Tylenol 500mg", helvetica, textBrush, 160, 543);
            page.Graphics.DrawString("6", helvetica, textBrush, 456, 543);
            page.Graphics.DrawString("90", helvetica, textBrush, 77, 580);
            page.Graphics.DrawString("30", helvetica, textBrush, 206, 580);
            page.Graphics.DrawString("X", helvetica, checkBrush, 249, 575);
            page.Graphics.DrawString("X", helvetica, checkBrush, 339, 575);
            page.Graphics.DrawString("10/05/2017", helvetica, textBrush, 372, 586);
            page.Graphics.DrawString("6 months", helvetica, textBrush, 497, 586);




            byte[] buffer = Encoding.ASCII.GetBytes(document.ToString());
            saveFile.Write(buffer, 0, buffer.Length);
            document.Save(saveFile);
            saveFile.Flush();
            saveFile.Close();

        }

    }
}