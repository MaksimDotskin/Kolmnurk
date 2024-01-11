using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dotskin_Triangle
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Triangle());
            Triangle_ triangle = new Triangle_(60, 60, 10);
            Console.WriteLine(triangle.outputA(),triangle.outputB(), triangle.outputC());
        }
    }
}
