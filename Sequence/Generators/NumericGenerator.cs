namespace Sequence.Generators
{
    /// <summary>
    /// Генератор простой числовой последовательности
    /// </summary>
    public class NumericGenerator : IGenerator
    {
        public string GetValue(int index)
        {
            return index.ToString();
        }
    }
}
