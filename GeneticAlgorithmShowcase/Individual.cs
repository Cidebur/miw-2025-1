namespace GeneticAlgorithmShowcase
{
    public class Individual
    {
        public List<byte> Genotype { get; private set; }
        public double Fitness { get; private set; }
        private List<double> parameters;

        public Individual(int geneLength, CoderDecoder coderDecoder)
        {
            Genotype = new List<byte>(geneLength);
            randomizeGenes();
            parameters = coderDecoder.Decode(Genotype);
            CalculateFitness();
        }

        public Individual(List<byte> genotype, CoderDecoder coderDecoder)
        {
            Genotype = genotype;
            parameters = coderDecoder.Decode(Genotype);
            CalculateFitness();
        }

        private void randomizeGenes()
        {
            Random random = new Random();
            for (int i = 0; i < Genotype.Capacity; i++)
            {
                Genotype.Add((byte)random.Next(0, 2));
            }
        }

        public void CalculateFitness()
        {
            Fitness = Math.Sin(parameters[0] * 0.05) + Math.Sin(parameters[1] * 0.05) + 0.4 * Math.Sin(parameters[0] * 0.15) * Math.Sin(parameters[1] * 0.15);
        }

        public override string ToString()
        {
            // return string.Join("", Genotype) + " | Fitness: " + Fitness;
            // return Math.Round(Fitness, 2).ToString() + " | " + parameters[0].ToString() + " | " + parameters[1].ToString();
            return Math.Round(Fitness, 5).ToString();
        }
    }
}