using FluentAssertions;
using LibTwo;
using Microsoft.Extensions.Options;
using Xunit;

namespace Tests.LibTwo
{
    public class CipherProviderTests
    {
        [Theory]
        [InlineData("28050794748", "02D6324125562F3E087889A84554E877")]
        [InlineData("33072773867", "4C58584775C533D8EB1CBD0638DA4699")]
        [InlineData("14021859051", "87A0685BDEF63BA49DBBA3465E5D0351")]
        [InlineData("17060612297", "02DDFE69F9BCC6CA80296902437520FF")]
        public void Should_Encryption_Be_Valid(string input, string expected)
        {
            // arrange
            var options = Options.Create(GetCipherConfiguration());
            var converter = new CipherConverter();
            var provider = new CipherProvider(converter, options);

            // act
            var output = provider.Encrypt(input);

            // assert
            output.Should().Be(expected);
        }

        [Theory]
        [InlineData("02D6324125562F3E087889A84554E877", "28050794748")]
        [InlineData("4C58584775C533D8EB1CBD0638DA4699", "33072773867")]
        [InlineData("87A0685BDEF63BA49DBBA3465E5D0351", "14021859051")]
        [InlineData("02DDFE69F9BCC6CA80296902437520FF", "17060612297")]
        public void Should_Decryption_Be_Valid(string input, string expected)
        {
            // arrange
            var options = Options.Create(GetCipherConfiguration());
            var converter = new CipherConverter();
            var provider = new CipherProvider(converter, options);

            // act
            var output = provider.Decrypt(input);

            // assert
            output.Should().Be(expected);
        }

        private static CipherConfiguration GetCipherConfiguration()
        {
            return new()
            {
                Key = "98DAD7D5AFB3DB8A053183966CEE6A10"
            };
        }
    }
}
