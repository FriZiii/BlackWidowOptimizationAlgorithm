namespace BlackWidowOptimizationAlgorithm.FitnessFunctions.Functions
{
    public class RosenbrockFunction : IFitnessFunction
    {
        public int NumberOfEvaluationFitnessFunction { get; set; }

        public FunctionDomain Domain { get; set; }

        public RosenbrockFunction(FunctionDomain domain)
        {
            Domain = domain;
        }

        public double Function(Chromosome chromosome)
        {
            double result = 0;
            for (int i = 0; i < chromosome.Genes.Length - 1; i++)
            {
                var x = 100 * Math.Pow(chromosome.Genes[i + 1] - chromosome.Genes[i] * chromosome.Genes[i], 2.0);
                var y = Math.Pow(1 - chromosome.Genes[i], 2.0);
                result += x + y;
            }
            NumberOfEvaluationFitnessFunction += 1;
            return result;
        }
    }
}
