using Sequence.Generators;
using Sequence.Providers;

namespace Sequence
{
    /// <summary>
    /// Базовый класс для последовательностей.
    /// Реализует простую последовательность, выдающую значение некоторой функции для определенного индекса.
    /// Индекс увеличивается на единицу при каждом запросе следующего значения.
    /// </summary>
    public class Sequence
    {
        protected IProvider _provider;
        protected IGenerator _generator;

        // Объект синхронизации доступа
        protected static object locker = new object();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="generator">Генератор значений последовательности</param>
        /// <param name="provider">Объект, предоставляющий доступ к текущему индексу последовательности</param>
        public Sequence(IGenerator generator, IProvider provider)
        {
            _provider = provider;
            _generator = generator;
        }

        /// <summary>
        /// Метод для получения текущего значения последовательности
        /// </summary>
        /// <returns>Текущее значение последовательности</returns>
        public virtual string Current()
        {
            return _generator.GetValue(_provider.Index);
        }

        /// <summary>
        /// Метод увеличивает внутренний индекс последовательности на единицу и возвращает новое значение
        /// </summary>
        /// <returns>Следующее значение последовательности</returns>
        public virtual string Next()
        {
            lock (locker)
            {
                _provider.Index++;
                return Current();
            }
        }
    }
}
