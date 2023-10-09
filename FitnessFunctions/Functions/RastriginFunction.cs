namespace BlackWidowOptimizationAlgorithm.FitnessFunctions.Functions
{
    public class RastriginFunction : IFitnessFunction
    {
        public int NumberOfEvaluationFitnessFunction { get; set; }

        public FunctionDomain Domain { get; set; }

        public RastriginFunction(FunctionDomain domain)
        {
            Domain = domain;
        }

        public double Function(Chromosome chromosome)
        {
            NumberOfEvaluationFitnessFunction++;
            double result = 10.0 * chromosome.Genes.Count();
            for (int i = 0; i < chromosome.Genes.Count(); i++)
            {
                result += Math.Pow(chromosome.Genes[i], 2.0) - 10.0 * Math.Cos(Math.PI * chromosome.Genes[i] * 2.0);
            }
            return result;

        }
    }
}