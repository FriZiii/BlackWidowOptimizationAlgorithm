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
    class BukinFunctionTest : IFunctionTest
    {
        public BukinFunctionTest(List<TestCase> testCases_t)
        {
            FunctionDomain domainx = new FunctionDomain(-15, -5);
            FunctionDomain domainy = new FunctionDomain(-3, 3);
            Name = "Bukin Function";
            numberOfGenes = 2;
            fitnessFunction = new BukinFunction(domainx, domainy);
            testCases = testCases_t;
        }

    }
}
