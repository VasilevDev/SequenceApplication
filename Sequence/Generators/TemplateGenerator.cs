using System;

namespace Sequence.Generators
{
    /// <summary>
    /// Генератор последовательнослей вида: "[PREFIX][YEAR][NUMBER]"
    /// </summary>
    public class TemplateGenerator : IGenerator
    {
        public string GetValue(int index)
        {
            return $"ABC{DateTime.Now.Year}{string.Format("{0:D5}", index)}";
        }
    }
}
