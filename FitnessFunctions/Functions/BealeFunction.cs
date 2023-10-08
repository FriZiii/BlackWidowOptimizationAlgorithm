namespace BlackWidowOptimizationAlgorithm.FitnessFunctions.Functions
{
    public class BealeFunction : IFitnessFunction
    {
        public int NumberOfEvaluationFitnessFunction { get; set ; }

        public double Function(Chromosome chromosome)
        {
            if(chromosome.Genes.Length > 2) 
                throw new Exception("BealeFunction works only for 2 parameters function");
            if (chromosome.Genes[0] >= -4.5 && chromosome.Genes[0] <= 4.5 && chromosome.Genes[1] >= -4.5 && chromosome.Genes[1] <= 4.5)
                return Math.Pow(1.5 - chromosome.Genes[0] + chromosome.Genes[0] * chromosome.Genes[1], 2.0)
                    + Math.Pow(2.25 - chromosome.Genes[0] + chromosome.Genes[0] * (chromosome.Genes[1] * chromosome.Genes[1]), 2.0)
                    + Math.Pow(2.65 - chromosome.Genes[0] + chromosome.Genes[0] * (chromosome.Genes[1] * chromosome.Genes[1] * chromosome.Genes[1]), 2.0);
            else
                return double.MaxValue;
        }
    }
}
