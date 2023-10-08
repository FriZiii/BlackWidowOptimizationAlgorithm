namespace BlackWidowOptimizationAlgorithm
{
    public class Chromosome
    {
        public double[] Genes { get; set; }

        private double _fitnessValue;
        public double FitnessValue
        {
            get => _fitnessValue;
            set => _fitnessValue = value;
        }
        public Func<Chromosome, double> FitnessFunction { get; }

        public Chromosome(int nubmerOfGenes, Func<Chromosome, double> fitnessFunction)
        {
            var randomizer = new Random();
            FitnessFunction = fitnessFunction;

            Genes = new double[nubmerOfGenes];
            for (int i = 0; i < nubmerOfGenes; i++)
            {
                Genes[i] = randomizer.NextDouble();
            }
            CalculeteFitnessValue();
        }

        public void CalculeteFitnessValue()
        {
            _fitnessValue = FitnessFunction(this);
        }
    }
}