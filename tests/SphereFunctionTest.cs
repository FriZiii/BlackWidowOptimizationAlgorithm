using BlackWidowOptimizationAlgorithm.FitnessFunctions.Functions;
using BlackWidowOptimizationAlgorithm.FitnessFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using tests;

namespace BlackWidowOptimizationAlgorithm.tests
{
    class SphereFunctionTest : IFunctionTest
    {
        public SphereFunctionTest(List<TestCase> testCases_t)
        {
            FunctionDomain domain = new FunctionDomain(-10000, 10000);
            Name = "Sphere Function";
            numberOfGenes = 50;
            fitnessFunction = new SphereFunction(domain);
            testCases = testCases_t;
        }
    }
}
