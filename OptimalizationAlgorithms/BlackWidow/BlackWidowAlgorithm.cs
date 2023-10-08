using BlackWidowOptimizationAlgorithm.FitnessFunctions;
namespace BlackWidowOptimizationAlgorithm.OptimalizationAlgorithms.BlackWidow
{
    public class BlackWidowAlgorithm : IOptimizationAlgorithm
    {
        private readonly int maxIterations;

        private readonly double procreatingRate;
        private readonly double cannibalismRate;
        private readonly double mutationRate;

        private readonly IFitnessFunction fitnessFunction;

        private readonly int populationSize;
        private readonly int numberOfGenes;

        private readonly Random randomizer;

        private readonly Population population_1;
        private readonly Population population_2;
        private readonly Population population_3;

        public string Name { get; set; } = "Black Widow Algorithm";
        public double[] XBest { get; set; } = default!;
        public double FBest { get; set; } = default!;
        public int NumberOfEvaluationFitnessFunction { get; set; } = default!;

        public BlackWidowAlgorithm(BlackWidowAlgorithmParameters parameters, IFitnessFunction fitnessFunction, int populationSize, int numberOfGenes)
        {
            maxIterations = parameters.MaxIterations;
            procreatingRate = parameters.ProcreatingRate;
            cannibalismRate = parameters.CanibalismRate;
            mutationRate = parameters.MutationRate;
            this.fitnessFunction = fitnessFunction;
            this.populationSize = populationSize;
            this.numberOfGenes = numberOfGenes;

            randomizer = new Random();

            population_1 = new Population();
            population_2 = new Population();
            population_3 = new Population();
        }

        public double Solve()
        {
            int currentIteration = 0;
            var initialPopulation = new Population(populationSize, numberOfGenes, fitnessFunction.Function);

            var numberOfReproduction = procreatingRate * populationSize;
            var bestChromosomes = initialPopulation.Chromosomes.OrderBy(chromosome => chromosome.FitnessValue).Take((int)Math.Floor(numberOfReproduction)).ToList();
            while (currentIteration < maxIterations)
            {
                foreach (var chromosome in bestChromosomes)
                {
                    population_1.Chromosomes.Add(chromosome);
                }

                for (int i = 0; i < Math.Floor(numberOfReproduction) - 1; i++)
                {
                    SelectParents(out Chromosome women, out Chromosome men);
                    Procreate(women, men);
                }

                Mutate();

                UpdatePopulation(ref initialPopulation);

                bestChromosomes.AddRange(initialPopulation.Chromosomes.OrderBy(chromosome => chromosome.FitnessValue).Take((int)Math.Floor(numberOfReproduction)));

                currentIteration++;
            }

            bestChromosomes = bestChromosomes.OrderBy(e => e.FitnessValue).ToList();
            XBest = bestChromosomes[0].Genes;
            FBest = bestChromosomes[0].FitnessValue;
            NumberOfEvaluationFitnessFunction = fitnessFunction.NumberOfEvaluationFitnessFunction;
            return FBest;
        }

        private void SelectParents(out Chromosome women, out Chromosome men)
        {
            int randomIndex1, randomIndex2;
            do
            {
                randomIndex1 = randomizer.Next(0, population_1.Chromosomes.Count);
                randomIndex2 = randomizer.Next(0, population_1.Chromosomes.Count);
            } while (randomIndex1 == randomIndex2);

            if (population_1.Chromosomes[randomIndex1].FitnessValue < population_1.Chromosomes[randomIndex2].FitnessValue)
            {
                women = population_1.Chromosomes[randomIndex1];
                men = population_1.Chromosomes[randomIndex2];
            }
            else
            {
                women = population_1.Chromosomes[randomIndex2];
                men = population_1.Chromosomes[randomIndex1];
            }
        }
        private void Procreate(Chromosome women, Chromosome men)
        {
            List<Chromosome> childrens = new();
            double[] alpha = new double[numberOfGenes];
            for (int j = 0; j < numberOfGenes; j++)
            {
                for (int k = 0; k < alpha.Length; k++)
                {
                    alpha[k] = randomizer.NextDouble();
                }

                var firstChild = new Chromosome(numberOfGenes, fitnessFunction.Function);
                for (int k = 0; k < numberOfGenes; k++)
                {
                    firstChild.Genes[k] = alpha[k] * women.Genes[k] + (1 - alpha[k]) * men.Genes[k];
                }

                var secondChild = new Chromosome(numberOfGenes, fitnessFunction.Function);
                for (int k = 0; k < numberOfGenes; k++)
                {
                    secondChild.Genes[k] = alpha[k] * men.Genes[k] + (1 - alpha[k]) * women.Genes[k];
                }
                firstChild.CalculeteFitnessValue();
                secondChild.CalculeteFitnessValue();
                childrens.Add(firstChild);
                childrens.Add(secondChild);
            }

            population_1.Chromosomes.Remove(men);

            //Kiling childrens
            var numberOfCannibalism = childrens.Count - Math.Floor(cannibalismRate * childrens.Count);

            List<Chromosome> bestChirdlen = childrens.OrderBy(children => children.FitnessValue).Take((int)Math.Floor(numberOfCannibalism)).ToList();
            population_2.Chromosomes.AddRange(bestChirdlen);
        }
        private void Mutate()
        {
            var numberOfMutation = Math.Floor(mutationRate * population_1.Chromosomes.Count);
            var randomizedPopulation_1 = population_1.Chromosomes.OrderBy(e => randomizer.Next(0, population_1.Chromosomes.Count)).ToList();
            for (int j = 0; j < numberOfMutation; j++)
            {
                int randomIndex1, randomIndex2;
                do
                {
                    randomIndex1 = randomizer.Next(0, randomizedPopulation_1[j].Genes.Length - 1);
                    randomIndex2 = randomizer.Next(0, randomizedPopulation_1[j].Genes.Length - 1);
                } while (randomIndex1 == randomIndex2);

                var temp = randomizedPopulation_1[j].Genes;
                randomizedPopulation_1[j].Genes[randomIndex1] = randomizedPopulation_1[j].Genes[randomIndex2];
                randomizedPopulation_1[j].Genes[randomIndex2] = temp[randomIndex1];

                randomizedPopulation_1[j].CalculeteFitnessValue();
                population_3.Chromosomes.Add(randomizedPopulation_1[j]);
            }
        }
        private void UpdatePopulation(ref Population initialPopulation)
        {
            population_3.Chromosomes.AddRange(population_2.Chromosomes);
            initialPopulation = population_3;
        }
    }
}
