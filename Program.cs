using System;
using System.IO;
using System.Text;
using Xfinium.Pdf;
using Xfinium.Pdf.Graphics;
using Xfinium.Pdf.Forms;

namespace xfinium
{
    class Program
    {
        static void Main(string[] args)
        {
            var luke = new Person("Luke", "Skywalker", "07/07/1977", "Male", "(740) 565 - 1987");
            var src = "LOMN.pdf";
            var dest = "Filled_LOMN.pdf";
            var newPdf = new ReadAndFillPdf(luke, src, dest);
            newPdf.Run();

            Console.WriteLine("Hello World!");
        }
    }
}
