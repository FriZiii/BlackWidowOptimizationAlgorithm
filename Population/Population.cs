namespace BlackWidowOptimizationAlgorithm
{
    public class Population
    {
        public List<Chromosome> Chromosomes { get; set; }
        /// <summary>
        /// <para>
        /// NumberOfGenes means the number of parameters that our considered problem takes
        /// </para>
        /// <para>
        /// PopulationSize indicates the accuracy with which our algorithm will search for the optimum
        /// </para>
        /// </summary>
        /// <param name="populationSize"></param>
        /// <param name="numberOfGenes"></param>
        public Population(int populationSize, int numberOfGenes, Func<Chromosome, double> fitnessFunction)
        {
            Chromosomes = new List<Chromosome>();
            for (int i = 0; i < populationSize; i++)
            {
                var chromosome = new Chromosome(numberOfGenes, fitnessFunction);
                Chromosomes.Add(chromosome);
            }
        }

        public Population()
        {
            Chromosomes = new List<Chromosome>();
        }
    }
}
