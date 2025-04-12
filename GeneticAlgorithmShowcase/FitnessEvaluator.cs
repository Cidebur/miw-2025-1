namespace GeneticAlgorithmShowcase
{
    public abstract class FitnessEvaluator
    {
        protected CoderDecoder coderDecoder;
        public FitnessEvaluator(CoderDecoder coderDecoder)
        {
            this.coderDecoder = coderDecoder;
        }
        public abstract double CalculateFitness(List<byte> genotype);
    }

    public class MutatedCarpetFitnessEvaluator : FitnessEvaluator
    {
        public MutatedCarpetFitnessEvaluator(CoderDecoder coderDecoder) : base(coderDecoder) { }

        public override double CalculateFitness(List<byte> genotype)
        {
            List<double> parameters = coderDecoder.Decode(genotype);
            return Math.Sin(parameters[0] * 0.05) + Math.Sin(parameters[1] * 0.05) + 0.4 * Math.Sin(parameters[0] * 0.15) * Math.Sin(parameters[1] * 0.15);
        }
    }
}