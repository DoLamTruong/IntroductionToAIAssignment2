using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPGA
{
    public class GA
    {
        private Random _rnd;
        private int[,] _distances;

        public City[] Cities { get; set; }
        public double MutationRate { get; set; }
        public DNA[] Population { get; set; }

        public GA(int nCities, int nPopulation, double mutationRate)
        {
            _rnd = new Random();

            Cities = new City[nCities];
            MutationRate = mutationRate;

            Population = new DNA[nPopulation];
        }

        public void InitCities(int width, int height)
        {
            for (int i = 0; i < Cities.Length; i++)
            {
                var x = _rnd.Next(width);
                var y = _rnd.Next(height);
                Cities[i] = new City { X = x, Y = y };
            }

            _distances = new int[Cities.Length, Cities.Length];
            for (int i = 0; i < Cities.Length; i++)
            {
                for (int j = 0; j < Cities.Length; j++)
                {
                    if (i != j)
                        _distances[i, j] = City.Distance(Cities[i], Cities[j]);
                }
            }
        }

        private DNA GenerateDNA()
        {
            var gn = new int[Cities.Length];
            for (int i = 0; i < Cities.Length; i++)
            {
                gn[i] = i;
            }

            for (int i = 0; i < Cities.Length / 3; i++)
            {
                var i1 = _rnd.Next(0, Cities.Length);
                var i2 = _rnd.Next(0, Cities.Length);

                var tmp = gn[i1];
                gn[i1] = gn[i2];
                gn[i2] = tmp;
            }

            return new DNA(gn);
        }

        public void InitPopulation()
        {
            for (int i = 0; i < Population.Length; i++)
            {
                Population[i] = GenerateDNA();
            }
        }

        private DNA GetBestDNA()
        {
            var minDistance = int.MaxValue;
            var idx = 0;
            for (int i = 0; i < Population.Length; i++)
            {
                Population[i].UpdateSumDistances(_distances);
                if (minDistance > Population[i].SumDistances)
                {
                    minDistance = Population[i].SumDistances;
                    idx = i;
                }
            }

            return Population[idx];
        }

        private List<int> CreateMatingPool()
        {
            List<int> fProportion = new List<int>();

            var bestDNA = GetBestDNA();

            for (int i = 0; i < Population.Length; i++)
            {
                int p = (int)Math.Floor(bestDNA.SumDistances * 100.0 / Population[i].SumDistances);
                for (int j = 0; j < p; j++)
                {
                    fProportion.Add(i);
                }
            }

            return fProportion;
        }

        private void Mutate(DNA dna)
        {
            for (int i = 0; i < dna.Genes.Length; i++)
            {
                var r = _rnd.NextDouble();
                if (r < MutationRate)
                {
                    var i1 = _rnd.Next(0, Cities.Length);
                    var i2 = _rnd.Next(0, Cities.Length);

                    var tmp = dna.Genes[i1];
                    dna.Genes[i1] = dna.Genes[i2];
                    dna.Genes[i2] = tmp;
                }
            }
        }

        private void EvolOnce()
        {
            // update fitness
            var pool = CreateMatingPool();

            // a little trick
            // to make sure the best element
            // will remain in the next generation
            Population[0] = GetBestDNA();

            for (int i = 1; i < Population.Length; i++)
            {
                // randomly select 2 parents in the polulation
                // based on the fitness pool
                var pIdx1 = _rnd.Next(pool.Count);
                var pIdx2 = _rnd.Next(pool.Count);
                var p1 = Population[pool[pIdx1]];
                var p2 = Population[pool[pIdx2]];

                // to make sure the split point 
                // will always fall in valid range 
                var splitPoint = _rnd.Next(Cities.Length - 1) + 1;
                // crossover to create new DNA
                var newDNA = p1.CrossOver(p2, splitPoint, _distances);

                // mutate
                Mutate(newDNA);

                Population[i] = newDNA;
            }
        }

        public DNA Evolution(int times)
        {              
            var i = 0;
            do
            {
                i++;
                EvolOnce();
            } while (i < times);

            DNA dna = GetBestDNA();
            Console.WriteLine("Evolution {0}: New DNA = '{1}'", i, string.Join(" ", dna.Genes));

            return dna;
        }

    }
}
