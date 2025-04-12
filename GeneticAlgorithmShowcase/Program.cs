namespace GeneticAlgorithmShowcase
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Choose scenario:");
            System.Console.WriteLine("1. Mutated Carpet");
            System.Console.WriteLine("2. Sinusoidal Function Approximation");
            System.Console.WriteLine("3. XOR Neural Network");
            string choice = Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("\n");
            switch (choice)
            {
                case "1":
                    const int MIN_VALUE = 0;
                    const int MAX_VALUE = 100;
                    const int NUMBER_OF_PARAMETERS = 2;
                    const int LENGTH_PER_PARAMETER = 5;
                    const int POPULATION_SIZE = 19;
                    const int GENERATIONS = 20;
                    const int TOURNAMENT_SIZE = 3;
                    var coderDecoder1 = new CoderDecoder(LENGTH_PER_PARAMETER, NUMBER_OF_PARAMETERS, MIN_VALUE, MAX_VALUE);
                    var fitnessEvaluator1 = new MutatedCarpetFitnessEvaluator(coderDecoder1);
                    var population1 = new Population1(POPULATION_SIZE, NUMBER_OF_PARAMETERS * LENGTH_PER_PARAMETER, fitnessEvaluator1, TOURNAMENT_SIZE);
                    population1.Start(GENERATIONS);
                    break;
                case "2":
                    const int MIN_VALUE2 = 0;
                    const int MAX_VALUE2 = 3;
                    const int NUMBER_OF_PARAMETERS2 = 3;
                    const int LENGTH_PER_PARAMETER2 = 4;
                    const int POPULATION_SIZE2 = 13;
                    const int GENERATIONS2 = 100;
                    const int TOURNAMENT_SIZE2 = 3;
                    var coderDecoder2 = new CoderDecoder(LENGTH_PER_PARAMETER2, NUMBER_OF_PARAMETERS2, MIN_VALUE2, MAX_VALUE2);
                    var fitnessEvaluator2 = new FunctionApproximationFitnessEvaluator(coderDecoder2);
                    var population2 = new Population2(POPULATION_SIZE2, NUMBER_OF_PARAMETERS2 * LENGTH_PER_PARAMETER2, fitnessEvaluator2, TOURNAMENT_SIZE2, crossoverPoints: new List<int> { 4, 8 });
                    population2.Start(GENERATIONS2);
                    break;
                case "3":
                    const int MIN_VALUE3 = -10;
                    const int MAX_VALUE3 = 10;
                    const int NUMBER_OF_PARAMETERS3 = 9;
                    const int LENGTH_PER_PARAMETER3 = 4;
                    const int POPULATION_SIZE3 = 13;
                    const int GENERATIONS3 = 100;
                    const int TOURNAMENT_SIZE3 = 3;
                    var coderDecoder3 = new CoderDecoder(LENGTH_PER_PARAMETER3, NUMBER_OF_PARAMETERS3, MIN_VALUE3, MAX_VALUE3);
                    var fitnessEvaluator3 = new XORNeuralNetworkFitnessEvaluator(coderDecoder3);
                    var population3 = new Population2(POPULATION_SIZE3, NUMBER_OF_PARAMETERS3 * LENGTH_PER_PARAMETER3, fitnessEvaluator3, TOURNAMENT_SIZE3, crossoverPoints: new List<int> { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33 });
                    population3.Start(GENERATIONS3);
                    break;
                default:
                    System.Console.WriteLine("Invalid choice. Please choose 1, 2, or 3.");
                    break;
            }
        }
    }
}