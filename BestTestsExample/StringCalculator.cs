namespace BestTestsExample
{
    public class StringCalculator : IStringCalculator
    {
        private const int MAX_VALUE = 1000;
        private int _collector;

        public int Add(string value) 
        {
            if (int.TryParse(value, out int result))
                _collector += result;

            if (result > MAX_VALUE)
                throw new OverflowException();

            return _collector;
        }
    }
}
