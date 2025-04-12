namespace GeneticAlgorithmShowcase
{
    abstract class Population
    {
        protected List<Individual> individuals;
        protected List<Individual> nextIndividuals = new List<Individual>();
        protected int populationSize;
        private int geneLength;
        private int tournamentSize;
        private FitnessEvaluator fitnessEvaluator;
        private List<int> crossoverPoints;
        public Population(int populationSize, int geneLength, FitnessEvaluator fitnessEvaluator, int tournamentSize = 3, List<int>? crossoverPoints = null)

        {
            this.tournamentSize = tournamentSize;
            this.populationSize = populationSize;
            this.geneLength = geneLength;
            this.fitnessEvaluator = fitnessEvaluator;
            if (crossoverPoints == null) this.crossoverPoints = new List<int> {geneLength / 2};
            else this.crossoverPoints = crossoverPoints;
            individuals = new List<Individual>(populationSize);
            for (int i = 0; i < populationSize; i++)
            {
                individuals.Add(new Individual(geneLength, this.fitnessEvaluator));
            }
        }
        public abstract void Evolve();

        public void Start(int generations)
        {
            System.Console.WriteLine("Generation 0:");
            System.Console.WriteLine(this);
            for (int i = 0; i < generations; i++)
            {
                Evolve();
                System.Console.WriteLine($"Generation {i + 1}:");
                System.Console.WriteLine(this);
            }
        }

        protected Individual tournamentSelection()
        {
            Random random = new Random();
            List<Individual> tournamentIndividuals = new List<Individual>(tournamentSize);
            for (int i = 0; i < tournamentSize; i++)
            {
                int index = random.Next(0, populationSize);
                tournamentIndividuals.Add(individuals[index]);
            }
            return tournamentIndividuals.OrderByDescending(i => i.Fitness).First();
        }
        protected Individual hotDeckSelection()
        {
            return individuals.OrderByDescending(i => i.Fitness).First();
        }
        protected (Individual, Individual) crossover(Individual parent1, Individual parent2)
        {
            // System.Console.WriteLine("Crossover between:");
            // System.Console.WriteLine(parent1);
            // System.Console.WriteLine(parent2);
            List<byte> child1Genotype = [.. parent1.Genotype];
            List<byte> child2Genotype = [.. parent2.Genotype];
            foreach (var crossoverPoint in crossoverPoints)
            {
                List<byte> temp = child1Genotype.Skip(crossoverPoint).ToList();
                child1Genotype.RemoveRange(crossoverPoint, child1Genotype.Count - crossoverPoint);
                child1Genotype.AddRange(child2Genotype.Skip(crossoverPoint));
                child2Genotype.RemoveRange(crossoverPoint, child2Genotype.Count - crossoverPoint);
                child2Genotype.AddRange(temp);
            }
            
            // System.Console.WriteLine("Children:");
            // System.Console.WriteLine(new Individual(child1Genotype, coderDecoder));
            // System.Console.WriteLine(new Individual(child2Genotype, coderDecoder));
            return (new Individual(child1Genotype, fitnessEvaluator), new Individual(child2Genotype, fitnessEvaluator));
        }
        protected void mutate(Individual individual)
        {
            Random random = new Random();
            int mutationPoint = random.Next(0, geneLength);
            individual.Genotype[mutationPoint] = (byte)(1 - individual.Genotype[mutationPoint]);
            individual.CalculateFitness(fitnessEvaluator);
        }
        public override string ToString()
        {
            // return string.Join("\n", individuals);
            return $"Best individual: {individuals.MaxBy(i => i.Fitness) } | Average fitness: {Math.Round(individuals.Average(x => x.Fitness), 5)}";
        }
    }

    class Population1: Population
    {
        public Population1(int populationSize, int geneLength, FitnessEvaluator fitnessEvaluator, int tournamentSize = 3, List<int>? crossoverPoints = null) : base(populationSize, geneLength, fitnessEvaluator, tournamentSize, crossoverPoints)
        {
        }

        public override void Evolve()
        {
            for (int i = 0; i < populationSize - 1; i += 2)
            {
                Individual parent1 = tournamentSelection();
                Individual parent2 = tournamentSelection();
                (var child1, var child2) = crossover(parent1, parent2);
                nextIndividuals.Add(child1);
                nextIndividuals.Add(child2);
            }
            foreach (var individual in nextIndividuals)
            {
                mutate(individual);
            }
            nextIndividuals.Add(hotDeckSelection());
            individuals.Clear();
            individuals.AddRange(nextIndividuals);
            nextIndividuals.Clear();
        }
    }
    class Population2: Population
    {
        public Population2(int populationSize, int geneLength, FitnessEvaluator fitnessEvaluator, int tournamentSize = 3, List<int>? crossoverPoints = null) : base(populationSize, geneLength, fitnessEvaluator, tournamentSize, crossoverPoints)
        {
        }

        public override void Evolve()
        {
            for (int i = 0; i < 4; i += 2)
            {
                Individual parent1 = tournamentSelection();
                Individual parent2 = tournamentSelection();
                (var child1, var child2) = crossover(parent1, parent2);
                nextIndividuals.Add(child1);
                nextIndividuals.Add(child2);
            }
            for (int i = 0; i < 4; i++)
            {
                Individual individual = tournamentSelection();
                mutate(individual);
                nextIndividuals.Add(individual);
            }
            for (int i = 0; i < 4; i += 2)
            {
                Individual parent1 = tournamentSelection();
                Individual parent2 = tournamentSelection();
                (var child1, var child2) = crossover(parent1, parent2);
                mutate(child1);
                mutate(child2);
                nextIndividuals.Add(child1);
                nextIndividuals.Add(child2);
            }
            nextIndividuals.Add(hotDeckSelection());
            individuals.Clear();
            individuals.AddRange(nextIndividuals);
            nextIndividuals.Clear();
            
        }
    }
}