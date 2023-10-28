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
    class RastriginFuncionTest : IFunctionTest
    {
        public RastriginFuncionTest(List<TestCase> testCases_t)
        {
            FunctionDomain domain = new FunctionDomain(-5.12, 5.12);
            Name = "Rastrigin Funcion";
            numberOfGenes = 30;
            fitnessFunction = new RastriginFunction(domain);
            testCases = testCases_t;
        }
    }
}
