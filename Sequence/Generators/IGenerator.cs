namespace Sequence.Generators
{
    /// <summary>
    /// Интерфейс генератора значений последовательности.
    /// Представляет значение последовательности по индексу
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// Метод для получения значения последовательности по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Значение последовательности по индексу</returns>
        string GetValue(int index);
    }
}
