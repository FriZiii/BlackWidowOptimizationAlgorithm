namespace BlackWidowOptimizationAlgorithm.FitnessFunctions.Functions
{
    public class BukinFunction : IFitnessFunction
    {
        public int NumberOfEvaluationFitnessFunction { get; set; }

        public FunctionDomain Domain { get; set; }
        public FunctionDomain DomainY { get; set; }

        public BukinFunction(FunctionDomain domainX, FunctionDomain domainY)
        {
            Domain = domainX;
            DomainY = domainY;
        }

        public double Function(Chromosome chromosome)
        {
            if (chromosome.Genes.Length > 2)
                throw new Exception("BukinFunction works only for 2 parameters function");
            NumberOfEvaluationFitnessFunction++;

            return 100 * Math.Sqrt(Math.Abs(chromosome.Genes[1] - 0.01 * chromosome.Genes[0] * chromosome.Genes[0]))
                    + 0.01 * Math.Abs(chromosome.Genes[0] + 10);
        }
    }
}
