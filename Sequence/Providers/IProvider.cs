namespace Sequence.Providers
{
    /// <summary>
    /// Интерфейс для доступа к текущему индексу последовательности
    /// </summary>
    public interface IProvider
    {
        /// <summary>
        /// Индекс значения последовательности
        /// </summary>
        int Index { get; set; }
    }
}
