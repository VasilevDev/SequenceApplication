using System;
using Sequence;
using Sequence.Generators;
using Sequence.Providers;
using System.Threading;

namespace SequenceApplication
{
    public static class Tests
    {
        private static string _connectionString = @"
            Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=D:\Work\SequenceApplication\SequenceApplication\Data\Sequence.mdf;
            Integrated Security=True";

        public static void TestNumeric()
        {
            TestMemoryProvider(new NumericGenerator());
        }

        public static void TestTemplate()
        {
            TestMemoryProvider(new TemplateGenerator());
        }

        public static void TestCyclic()
        {
            var generator = new NumericGenerator();
            var provider = new InMemoryProvider();

            var sequence = new CyclicSequence(generator, provider);

            ShowSequence(sequence);
        }

        public static void TestDatabaseNumeric()
        {
            var provider = new DatabaseProvider(_connectionString, 1);
            var generator = new NumericGenerator();

            var sequence = new Sequence.Sequence(generator, provider);

            ShowSequence(sequence);
        }

        public static void TestDatabaseTemplate()
        {
            var provider = new DatabaseProvider(_connectionString, 2);
            var generator = new TemplateGenerator();

            var sequence = new Sequence.Sequence(generator, provider);

            ShowSequence(sequence);
        }

        public static void TestMultiThread()
        {
            var generator = new NumericGenerator();
            var provider = new InMemoryProvider();

            var sequence = new Sequence.Sequence(generator, provider);

            ShowSequenceMultiThread(sequence);
        }

        public static void TestDatabaseMultiThread()
        {
            var provider = new DatabaseProvider(_connectionString, 1);
            var generator = new NumericGenerator();

            var sequence = new Sequence.Sequence(generator, provider);

            ShowSequenceMultiThread(sequence);
        }
        private static void ShowSequence(Sequence.Sequence s)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine($"Value: {s.Next()}");
            }
        }

        private static void ShowSequenceMultiThread(Sequence.Sequence s)
        {
            for (int i = 0; i < 50; i++)
            {
                new Thread(() =>
                {
                    for (int j = 0; j < 20; j++)
                    {
                        Console.WriteLine($"Thread: {Thread.CurrentThread.GetHashCode()}, Value: {s.Next()}");
                    }
                }).Start();
            }
        }

        private static void TestMemoryProvider(IGenerator generator)
        {
            var provider = new InMemoryProvider();
            var sequence = new Sequence.Sequence(generator, provider);

            ShowSequence(sequence);
        }
    }
}
