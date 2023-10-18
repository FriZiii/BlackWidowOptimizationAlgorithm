namespace BlackWidowOptimizationAlgorithm.FitnessFunctions.Functions
{
    public class HimmelblausFunction : IFitnessFunction
    {
        public int NumberOfEvaluationFitnessFunction { get; set; }

        public FunctionDomain Domain { get; set; }

        public HimmelblausFunction(FunctionDomain domain)
        {
            Domain = domain;
        }

        public double Function(Chromosome chromosome)
        {
            if (chromosome.Genes.Length > 2)
                throw new Exception("HimmelblausFunction works only for 2 parameters function");
            NumberOfEvaluationFitnessFunction++;

            return Math.Pow(chromosome.Genes[0] * chromosome.Genes[0] + chromosome.Genes[1] - 11d, 2.0) +
                Math.Pow(chromosome.Genes[0] + chromosome.Genes[1] * chromosome.Genes[1] - 7d, 2.0);
        }
    }
}
