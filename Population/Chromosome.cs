using BlackWidowOptimizationAlgorithm.FitnessFunctions;
using BlackWidowOptimizationAlgorithm.FitnessFunctions.Functions;

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
            if(fitnessFunction is BukinFunction)
            {
                FitnessFunction = fitnessFunction.Function;

                var bukinFuntion = fitnessFunction as BukinFunction;

                Genes = new double[nubmerOfGenes];
                Genes[0] = (randomizer.NextDouble() * (bukinFuntion!.Domain.UpperBound - bukinFuntion.Domain!.LowerBound) + bukinFuntion.Domain!.LowerBound);
                Genes[1] = (randomizer.NextDouble() * (bukinFuntion!.DomainY.UpperBound - bukinFuntion.DomainY!.LowerBound) + bukinFuntion.DomainY!.LowerBound);
                CalculeteFitnessValue();
            }
            else
            {
                FitnessFunction = fitnessFunction.Function;

                Genes = new double[nubmerOfGenes];
                for (int i = 0; i < nubmerOfGenes; i++)
                {
                    Genes[i] = (randomizer.NextDouble() * (fitnessFunction.Domain.UpperBound - fitnessFunction.Domain.LowerBound) + fitnessFunction.Domain.LowerBound);
                }
                CalculeteFitnessValue();
            }
        }

        public void CalculeteFitnessValue()
        {
            _fitnessValue = FitnessFunction(this);
        }
    }
}