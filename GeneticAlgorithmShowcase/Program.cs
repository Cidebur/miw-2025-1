namespace GeneticAlgorithmShowcase
{
    class Program
    {
        const int MIN_VALUE = 0;
        const int MAX_VALUE = 100;
        const int NUMBER_OF_PARAMETERS = 2;
        const int LENGTH_PER_PARAMETER = 5;
        const int GENOTYPE_SIZE = 10;
        const int POPULATION_SIZE = 19;
        const int GENERATIONS = 20;
        const int TOURNAMENT_SIZE = 3;
        static void Main(string[] args)
        {
            var coderDecoder = new CoderDecoder(LENGTH_PER_PARAMETER, NUMBER_OF_PARAMETERS, MIN_VALUE, MAX_VALUE);
            var fitnessEvaluator = new MutatedCarpetFitnessEvaluator(coderDecoder);
            var population = new Population1(POPULATION_SIZE, GENOTYPE_SIZE, fitnessEvaluator, TOURNAMENT_SIZE);
            System.Console.WriteLine("Initial Population:");
            System.Console.WriteLine(population);
            for (int i = 0; i < GENERATIONS; i++)
            {
                population.Evolve();
                System.Console.WriteLine($"Generation {i + 1}:");
                System.Console.WriteLine(population);
            }
        }
    }
}