using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPGA
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dna1 = new DNA(new int[] { 0, 2, 5, 1, 4, 6, 7, 3 });
            //var dna2 = new DNA(new int[] { 0, 5, 6, 3, 7, 1, 2, 4 });

            //var dna = dna1.CrossOver(dna2, 0, 3);

            FrmDisplay f = new FrmDisplay();
            f.ShowDialog();

            Console.Read();
        }
    }
}
