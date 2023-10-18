using BlackWidowOptimizationAlgorithm.FitnessFunctions;
using BlackWidowOptimizationAlgorithm.OptimalizationAlgorithms.BlackWidow;
using BlackWidowOptimizationAlgorithm.FitnessFunctions.Functions;
namespace tests
{
    public class HimmelblauFunctionTest : IFunctionTest
    {
        
        public HimmelblauFunctionTest(List<TestCase> testCases_t)
        {
            FunctionDomain domain = new FunctionDomain(-5d, 5d);
            Name="HimmelblauFunctionTest";
            numberOfGenes=2;
            fitnessFunction=new HimmelblausFunction(domain);
            testCases = testCases_t;
        }

    }
}