using BlackWidowOptimizationAlgorithm.FitnessFunctions;
using BlackWidowOptimizationAlgorithm.FitnessFunctions.Functions;
using BlackWidowOptimizationAlgorithm.OptimalizationAlgorithms.BlackWidow;

var parameters = new BlackWidowAlgorithmParameters()
{
    MaxIterations = 15,
    ProcreatingRate = 0.6,
    MutationRate = 0.4,
    CanibalismRate = 0.44,
};

var populationSize = 300;
var numberOfGenes = 2;

IFitnessFunction fitnessFunction = new BealeFunction();

var BWOA = new BlackWidowAlgorithm(parameters, fitnessFunction, populationSize, numberOfGenes);
var result = BWOA.Solve();

Console.WriteLine($"End with result {result}");
Console.WriteLine($"Parameters:");
foreach (var parametr in BWOA.XBest)
{
    Console.WriteLine(parametr);
}
Console.WriteLine($"Number of evaluations {BWOA.NumberOfEvaluationFitnessFunction}");