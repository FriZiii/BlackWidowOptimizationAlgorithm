using BlackWidowOptimizationAlgorithm.FitnessFunctions;

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

        public Chromosome(int nubmerOfGenes, IFitnessFunction fitnessFunction)
        {
            var randomizer = new Random();
            FitnessFunction = fitnessFunction.Function;

            Genes = new double[nubmerOfGenes];
            for (int i = 0; i < nubmerOfGenes; i++)
            {
                Genes[i] = (randomizer.NextDouble() * (fitnessFunction.Domain.UpperBound - fitnessFunction.Domain.LowerBound) + fitnessFunction.Domain.LowerBound);
            }
            CalculeteFitnessValue();
        }

        public void CalculeteFitnessValue()
        {
            _fitnessValue = FitnessFunction(this);
        }
    }
}