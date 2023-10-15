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
            var initialPopulation = new Population(populationSize, numberOfGenes, fitnessFunction);

            var bestWidow = initialPopulation.Chromosomes.MinBy(x => x.FitnessValue);

            while (currentIteration < maxIterations)
            {
                population_1.Chromosomes.Clear();
                population_2.Chromosomes.Clear();
                population_3.Chromosomes.Clear();
                var numberOfReproduction = procreatingRate * initialPopulation.Chromosomes.Count;

                var bestChromosomes = initialPopulation.Chromosomes.OrderBy(chromosome => chromosome.FitnessValue).Take((int)Math.Floor(numberOfReproduction)).ToList();
                population_1.Chromosomes.AddRange(bestChromosomes);

                //Proceate
                var childerns = new List<Chromosome>();
                for (int i = 0; i < Math.Floor(numberOfReproduction) - 1; i++)
                {
                    SelectParents(out Chromosome women, out Chromosome men);
                    childerns.AddRange(Procreate(women, men));
                }

                    //Kiling childrens
                    var numberOfCannibalism = childerns.Count - Math.Floor(cannibalismRate * childerns.Count);
                    List<Chromosome> bestChirdlen = childerns.OrderBy(children => children.FitnessValue).Take((int)Math.Floor(numberOfCannibalism)).ToList();
                    population_2.Chromosomes.AddRange(bestChirdlen);
                    population_2.Chromosomes.AddRange(population_1.Chromosomes);

                Mutate();

                UpdatePopulation(ref initialPopulation);

                bestChromosomes = initialPopulation.Chromosomes.OrderBy(chromosome => chromosome.FitnessValue).ToList();

                var bestChromosome = bestChromosomes.First();

                XBest = bestChromosome.Genes;
                NumberOfEvaluationFitnessFunction = fitnessFunction.NumberOfEvaluationFitnessFunction;
                FBest = bestChromosome.FitnessValue;
                currentIteration++;
            }
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
        private IEnumerable<Chromosome> Procreate(Chromosome women, Chromosome men)
        {
            List<Chromosome> childrens = new();
            double[] alpha = new double[numberOfGenes];

            for (int k = 0; k < alpha.Length; k++)
            {
                alpha[k] = randomizer.NextDouble();
            }

            var firstChild = new Chromosome(numberOfGenes, fitnessFunction);
            for (int k = 0; k < numberOfGenes; k++)
            {
                firstChild.Genes[k] = alpha[k] * women.Genes[k] + (1 - alpha[k]) * men.Genes[k];
            }

            var secondChild = new Chromosome(numberOfGenes, fitnessFunction);
            for (int k = 0; k < numberOfGenes; k++)
            {
                secondChild.Genes[k] = alpha[k] * men.Genes[k] + (1 - alpha[k]) * women.Genes[k];
            }

            firstChild.CalculeteFitnessValue();
            secondChild.CalculeteFitnessValue();
            childrens.Add(firstChild);
            childrens.Add(secondChild);

            population_1.Chromosomes.Remove(men);

            return childrens;
        }
        private void Mutate()
        {
            var numberOfMutation = (int)Math.Floor(mutationRate * population_2.Chromosomes.Count);
            var randomizedPopulation_2 = population_2.Chromosomes.OrderBy(e => randomizer.Next(0, population_2.Chromosomes.Count)).ToList();
            Parallel.For(0, numberOfMutation, j =>
            {
                var currentChromosome = randomizedPopulation_2[j];
                int randomIndex1, randomIndex2;
                do
                {
                    randomIndex1 = randomizer.Next(0, currentChromosome.Genes.Length);
                    randomIndex2 = randomizer.Next(0, currentChromosome.Genes.Length);
                } while (randomIndex1 == randomIndex2);

                var temp = currentChromosome.Genes;
                currentChromosome.Genes[randomIndex1] = currentChromosome.Genes[randomIndex2];
                currentChromosome.Genes[randomIndex2] = temp[randomIndex1];

                currentChromosome.CalculeteFitnessValue();
                population_3.Chromosomes.Add(currentChromosome);
            });
        }

        private void UpdatePopulation(ref Population initialPopulation)
        {
            population_3.Chromosomes.AddRange(population_2.Chromosomes);
            initialPopulation.Chromosomes.Clear();
            initialPopulation.Chromosomes.AddRange(population_3.Chromosomes);
        }
    }
}
