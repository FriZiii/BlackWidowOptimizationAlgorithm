namespace BlackWidowOptimizationAlgorithm.FitnessFunctions.Functions
{
    public class BealeFunction : IFitnessFunction
    {
        public int NumberOfEvaluationFitnessFunction { get; set ; }

        public FunctionDomain Domain { get; set; }

        public BealeFunction(FunctionDomain domain)
        {
            Domain = domain;
        }

        public double Function(Chromosome chromosome)
        {
            if(chromosome.Genes.Length > 2) 
                throw new Exception("BealeFunction works only for 2 parameters function");

            NumberOfEvaluationFitnessFunction++;

            return Math.Pow(1.5 - chromosome.Genes[0] + chromosome.Genes[0] * chromosome.Genes[1], 2.0)
                + Math.Pow(2.25 - chromosome.Genes[0] + chromosome.Genes[0] * (chromosome.Genes[1] * chromosome.Genes[1]), 2.0)
                + Math.Pow(2.625 - chromosome.Genes[0] + chromosome.Genes[0] * (chromosome.Genes[1] * chromosome.Genes[1] * chromosome.Genes[1]), 2.0);

        }
    }
}
