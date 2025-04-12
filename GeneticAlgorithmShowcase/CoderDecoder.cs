namespace GeneticAlgorithmShowcase
{
    public class CoderDecoder
    {
        private int lengthPerParameter;
        private int numberOfParameters;
        private int genotypeLength {get {return lengthPerParameter * numberOfParameters;}}
        private double lowerBound;
        private double upperBound;
        public CoderDecoder(int lengthPerParameter, int numberOfParameters, double lowerBound, double upperBound)
        {
            this.lengthPerParameter = lengthPerParameter;
            this.numberOfParameters = numberOfParameters;
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
        }
        public List<double> Decode(string genotype)
        {
            if(genotype.Length != lengthPerParameter * numberOfParameters)
            {
                throw new ArgumentException("Wrong genotype length.");
            }

            var parameters = new List<string>();
            for (int i = 0; i < numberOfParameters; i++)
            {
                parameters.Add(genotype.Substring(i * lengthPerParameter, lengthPerParameter));
            }

            var result = new List<double>();
            foreach (string parameter in parameters)
            {
                double ctmp = Convert.ToInt32(parameter, 2);
                double value = lowerBound + ctmp / (Math.Pow(2, lengthPerParameter) - 1) * (upperBound - lowerBound);
                result.Add(value);
                
            }
            return result;
        }
        
        public List<double> Decode(List<byte> genotype)
        {
            return Decode(string.Join("", genotype));
        }

        public List<byte> Encode(List<double> values)
        {
            if(values.Count != numberOfParameters)
            {
                throw new ArgumentException("Number of parameters does not match the number of values.");
            }
            var result = new List<byte>(genotypeLength);
            foreach (double value in values)
            {
                double boundValue = Math.Max(value, lowerBound);
                boundValue = Math.Min(boundValue, upperBound);
                double ctmp = Math.Round((boundValue - lowerBound)/(upperBound - lowerBound) * (Math.Pow(2, lengthPerParameter) - 1));
                for (int i = lengthPerParameter - 1; i >= 0; i--)
                {
                    result.Add((byte)(Math.Floor(ctmp/Math.Pow(2,i)) % 2));
                }
            }
            return result;
        }
    }
}