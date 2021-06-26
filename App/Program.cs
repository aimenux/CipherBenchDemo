using App.Benchmarks;
using BenchmarkDotNet.Running;

namespace App
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var benchmarks = new[]
            {
                typeof(EncryptionBench),
                typeof(DecryptionBench)
            };

            var switcher = new BenchmarkSwitcher(benchmarks);
            switcher.Run(args);
        }
    }
}
