namespace BlackWidowOptimizationAlgorithm.FitnessFunctions
{
    public class FunctionDomain
    {
        public FunctionDomain()
        {
        }

        public FunctionDomain(double lowerBound, double upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }
        public double LowerBound { get; set; } = -1_000_000.0;
        public double UpperBound { get; set;} = 1_000_000.0;
    }
}
