namespace GeneticAlgorithmShowcase
{
    public class Individual
    {
        public List<byte> Genotype { get; private set; }
        public double Fitness { get; private set; }

        public Individual(int geneLength, FitnessEvaluator fitnessEvaluator)
        {
            Genotype = new List<byte>(geneLength);
            randomizeGenes();
            CalculateFitness(fitnessEvaluator);
        }

        public Individual(List<byte> genotype, FitnessEvaluator fitnessEvaluator)
        {
            Genotype = genotype;
            CalculateFitness(fitnessEvaluator);
        }

        private void randomizeGenes()
        {
            Random random = new Random();
            for (int i = 0; i < Genotype.Capacity; i++)
            {
                Genotype.Add((byte)random.Next(0, 2));
            }
        }
        public void CalculateFitness(FitnessEvaluator fitnessEvaluator)
        {
            Fitness = fitnessEvaluator.CalculateFitness(Genotype);
        }

        public override string ToString()
        {
            // return string.Join("", Genotype) + " | Fitness: " + Fitness;
            // return Math.Round(Fitness, 2).ToString() + " | " + parameters[0].ToString() + " | " + parameters[1].ToString();
            return Math.Round(Fitness, 5).ToString();
        }
    }
}