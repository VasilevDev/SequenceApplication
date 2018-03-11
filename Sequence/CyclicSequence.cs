using Sequence.Generators;
using Sequence.Providers;

namespace Sequence
{
    /// <summary>
    /// Класс для представления циклических последовательностей.
    /// Индекс увеличивается на единицу при каждом запросе следующего значения.
    /// При достижении максимума индекс сбрасывается на минимальное значение.
    /// </summary>
    public class CyclicSequence : Sequence
    {
        private int _min = 0;
        private int _max = 10;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="provider"></param>
        /// <param name="range">Задает минимальное и максимальное значение индекса циклической последовательности</param>
        public CyclicSequence(IGenerator generator, IProvider provider, CycleRange range)
            : base(generator, provider)
        {
            _min = range.Min;
            _max = range.Max;
        }

        /// <summary>
        /// Перевызов конструктора базового класса
        /// </summary>
        public CyclicSequence(IGenerator generator, IProvider provider)
            : base(generator, provider)
        {

        }

        /// <summary>
        /// Метод для получения текущего значения последовательности.
        /// При достижении максимума индекс сбрасывается на минимальное значение.
        /// </summary>
        /// <returns>Текущее значение последовательности</returns>
        public override string Next()
        {
            lock (locker)
            {
                _provider.Index++;

                if (_provider.Index > _max)
                    _provider.Index = _min;

                return Current();
            }
        }
    }
}
