namespace Sequence.Providers
{
    /// <summary>
    /// Класс для хранения значения индекса последовательности в оперативной памяти
    /// </summary>
    public class InMemoryProvider : IProvider
    {
        private int _index = -1;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
    }
}
