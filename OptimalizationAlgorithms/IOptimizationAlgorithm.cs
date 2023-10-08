namespace BlackWidowOptimizationAlgorithm.OptimalizationAlgorithms
{
    public interface IOptimizationAlgorithm
    {
        string Name { get; set; }
        double Solve();
        double[] XBest { get; set; }
        double FBest { get; set; }
        int NumberOfEvaluationFitnessFunction { get; set; }
    }
}
