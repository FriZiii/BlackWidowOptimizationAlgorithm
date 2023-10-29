using BlackWidowOptimizationAlgorithm.FitnessFunctions.Functions;
using BlackWidowOptimizationAlgorithm.FitnessFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tests;

namespace BlackWidowOptimizationAlgorithm.tests
{
    class RosenbrockFunctionTest : IFunctionTest
    {
        public RosenbrockFunctionTest(List<TestCase> testCases_t)
        {
            FunctionDomain domain = new FunctionDomain(-10000, 10000);
            Name = "Rosenbrock Function";
            numberOfGenes = 30;
            fitnessFunction = new RosenbrockFunction(domain);
            testCases = testCases_t;
        }
    }
}
