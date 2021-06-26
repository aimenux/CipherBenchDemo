using App.Helpers;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Options;

namespace App.Benchmarks
{
    [Config(typeof(BenchConfig))]
    [BenchmarkCategory(nameof(BenchCategory.Encryption))]
    public class EncryptionBench
    {
        private string _clearText;
        
        private const string Key = "98DAD7D5AFB3DB8A053183966CEE6A10";
        private static readonly LibOne.CipherProvider CipherOne = GetCipherProviderOne();
        private static readonly LibTwo.CipherProvider CipherTwo = GetCipherProviderTwo();

        [Params(16, 32, 64, 128, 256)]
        public int Length { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _clearText = RandomHelper.RandomString(Length);
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            CipherOne.Dispose();
        }

        [Benchmark]
        public string EncryptWithLibOne()
        {
            return CipherOne.Encrypt(_clearText);
        }

        [Benchmark]
        public string EncryptWithLibTwo()
        {
            return CipherTwo.Encrypt(_clearText);
        }

        private static LibOne.CipherProvider GetCipherProviderOne()
        {
            var converter = new LibOne.CipherConverter();
            var configuration = new LibOne.CipherConfiguration
            {
                Key = Key
            };
            var options = Options.Create(configuration);
            return new LibOne.CipherProvider(converter, options);
        }

        private static LibTwo.CipherProvider GetCipherProviderTwo()
        {
            var converter = new LibTwo.CipherConverter();
            var configuration = new LibTwo.CipherConfiguration
            {
                Key = Key
            };
            var options = Options.Create(configuration);
            return new LibTwo.CipherProvider(converter, options);
        }
    }
}