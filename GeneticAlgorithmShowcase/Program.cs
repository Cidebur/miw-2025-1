namespace GeneticAlgorithmShowcase
{
    class Program
    {
        // const int MIN_VALUE = 0;
        // const int MAX_VALUE = 100;
        // const int NUMBER_OF_PARAMETERS = 2;
        // const int LENGTH_PER_PARAMETER = 5;
        // const int POPULATION_SIZE = 19;
        // const int GENERATIONS = 20;
        // const int TOURNAMENT_SIZE = 3;
        // static void Main(string[] args)
        // {
        //     var coderDecoder = new CoderDecoder(LENGTH_PER_PARAMETER, NUMBER_OF_PARAMETERS, MIN_VALUE, MAX_VALUE);
        //     var fitnessEvaluator = new MutatedCarpetFitnessEvaluator(coderDecoder);
        //     var population = new Population1(POPULATION_SIZE, NUMBER_OF_PARAMETERS * LENGTH_PER_PARAMETER, fitnessEvaluator, TOURNAMENT_SIZE);
        //     population.Start(GENERATIONS);
        // }

        const int MIN_VALUE = 0;
        const int MAX_VALUE = 3;
        const int NUMBER_OF_PARAMETERS = 3;
        const int LENGTH_PER_PARAMETER = 4;
        const int POPULATION_SIZE = 13;
        const int GENERATIONS = 100;
        const int TOURNAMENT_SIZE = 3;
        static void Main(string[] args)
        {
            var coderDecoder = new CoderDecoder(LENGTH_PER_PARAMETER, NUMBER_OF_PARAMETERS, MIN_VALUE, MAX_VALUE);
            var fitnessEvaluator = new FunctionApproximationFitnessEvaluator(coderDecoder);
            var population = new Population2(POPULATION_SIZE, NUMBER_OF_PARAMETERS * LENGTH_PER_PARAMETER, fitnessEvaluator, TOURNAMENT_SIZE, crossoverPoints: new List<int> { 4, 8 });
            population.Start(GENERATIONS);
        }
    }
}