﻿namespace BlackWidowOptimizationAlgorithm.OptimalizationAlgorithms.BlackWidow
{
    public class BlackWidowAlgorithmParameters
    {
        public int MaxIterations { get; set; }
        public double ProcreatingRate { get; set; }
        public double CanibalismRate { get; set; }
        public double MutationRate { get; set; }
    }
}
