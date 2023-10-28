﻿using BlackWidowOptimizationAlgorithm.OptimalizationAlgorithms.BlackWidow;
using tests;
using System.Collections.Generic;
using BlackWidowOptimizationAlgorithm.tests;

List<TestCase> generateTestCases(List<int> populationSizes, List<int> maxIterations)
{
    var result = new List<TestCase>();
    foreach (var populationSize in populationSizes)
    {
        foreach (var maxIteration in maxIterations)
        {
            var testCase = new TestCase
            {
                populationSize = populationSize,
                blackWidowAlgorithmParameters = new BlackWidowAlgorithmParameters
                {
                    MaxIterations = maxIteration,
                    ProcreatingRate = 0.6,
                    MutationRate = 0.5,
                    CanibalismRate = 0.44
                }
            };
            result.Add(testCase);
        }
    }
    return result;
}

var populationSizes = new List<int> { 10, 20, 40, 80 };
var maxIterations = new List<int> { 10, 20, 40, 60, 80 };

var testCases = generateTestCases(populationSizes, maxIterations);

//var testFunction = new HimmelblauFunctionTest(testCases);
//testFunction.TestsToCsv();

var testFunction = new RastriginFuncionTest(testCases);
testFunction.TestsToCsv();

//var testFunction = new HimmelblauFunctionTest(testCases);
//testFunction.TestsToCsv();
