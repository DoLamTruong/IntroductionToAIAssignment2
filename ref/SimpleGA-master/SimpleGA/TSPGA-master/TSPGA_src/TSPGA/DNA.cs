using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPGA
{
    public class DNA
    {
        public int[] Genes { get; set; }
        public int SumDistances { get; set; }

        public DNA(int[] genes)
        {
            Genes = genes;
        }

        public void UpdateSumDistances(int[,] distances)
        {
            var sumDistance = 0;
            for (int i = 0; i < Genes.Length; i++)
            {
                var c1 = Genes[i];
                var c2 = Genes[(i+1) % Genes.Length];
                sumDistance += distances[c1,c2];
            }

            SumDistances = sumDistance;
        }

        private void Swap(int v1, int v2, int[] arr)
        {
            var id1 = -1;
            var id2 = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == v1) id1 = i;
                if (arr[i] == v2) id2 = i;
            }

            var tmp = arr[id1];
            arr[id1] = arr[id2];
            arr[id2] = tmp;
        }

        private bool Contains(int val, int[] ar, int p1, int p2)
        {
            for (int i = p1; i < p2; i++)
            {
                if (ar[i] == val) return true;
            }
            return false;
        }

        public DNA CrossOver(DNA dna, int splitPoint, int[,] distances)
        {
            var c = Genes[splitPoint];
            var lst = new List<int>();
            var p1 = Genes.ToList();
            var p2 = dna.Genes.ToList();

            lst.Add(c);
            while (p1.Count() > 1)
            {
                var id1 = p1.IndexOf(c);
                var c1 = p1[(id1 + 1) % p1.Count()];
                var id2 = p2.IndexOf(c);
                var c2 = p2[(id2 + 1) % p2.Count()];
                p1.Remove(c);
                p2.Remove(c);
                c = distances[c,c1] < distances[c,c2] ? c1 : c2;
                lst.Add(c);
            }
            return new DNA(lst.ToArray());
        }
    }
}
