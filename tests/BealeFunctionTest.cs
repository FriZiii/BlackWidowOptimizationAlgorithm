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
    class BealeFunctionTest : IFunctionTest
    {

        public BealeFunctionTest(List<TestCase> testCases_t)
        {
            FunctionDomain domain = new FunctionDomain(-4.5, 4.5);
            Name = " Beale Function";
            numberOfGenes = 2;
            fitnessFunction = new BealeFunction(domain);
            testCases = testCases_t;
        }

    }
}
