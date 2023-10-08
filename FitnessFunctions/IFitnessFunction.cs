namespace BlackWidowOptimizationAlgorithm.FitnessFunctions
{
    public interface IFitnessFunction
    {
        int NumberOfEvaluationFitnessFunction { get; set; }
        double Function(Chromosome chromosome);
        FunctionDomain Domain { get; }
    }
}
