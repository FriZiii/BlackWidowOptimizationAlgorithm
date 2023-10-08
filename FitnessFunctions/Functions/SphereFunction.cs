namespace BlackWidowOptimizationAlgorithm.FitnessFunctions.Functions
{
    public class SphereFunction : IFitnessFunction
    {
        public int NumberOfEvaluationFitnessFunction { get; set ; }

        public double Function(Chromosome chromosome)
        {
            double result = 0;
            foreach (var gene in chromosome.Genes)
            {
                result += gene * gene;
            }
            NumberOfEvaluationFitnessFunction += 1;
            return result;
        }
    }
}
