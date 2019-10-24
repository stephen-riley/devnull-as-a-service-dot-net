using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DevNullService.Contracts;
using FluentAssertions;
using Xunit;

namespace DevNullService.Tests
{
    public class GetTests : TestsBase
    {
        [Fact]
        public async Task GetNulls_DefaultHappyPath()
        {
            // Arrange
            var reference = CreateNullArray(Constants.DefaultNullsLength);

            // Act
            var (status, content) = await ExecuteGetAsync();

            // Assert
            status.Should().Be(HttpStatusCode.OK);
            content.Length.Should().Be(Constants.DefaultNullsLength);
            content.Should().BeEquivalentTo(reference);
        }

        [Fact]
        public async Task GetNulls_VariableLengthHappyPath()
        {
            // Arrange
            const int length = 100;
            var reference = CreateNullArray(length);

            // Act
            var (status, content) = await ExecuteGetAsync(length);

            // Assert
            status.Should().Be(HttpStatusCode.OK);
            content.Length.Should().Be(length);
            content.Should().BeEquivalentTo(reference);
        }

        [Fact]
        public async Task GetNulls_NegativeLength()
        {
            // Arrange

            // Act
            var (status, content) = await ExecuteGetAsync(-1);

            // Assert
            status.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GetNulls_ZeroLength()
        {
            // Arrange

            // Act
            var (status, content) = await ExecuteGetAsync(0);

            // Assert
            status.Should().Be(HttpStatusCode.OK);
            content.Length.Should().Be(0);
        }

        /// <summary>
        /// Utility function to create a `byte[]` of `NUL`s for comparison with results from the `GET` endpoint
        /// </summary>
        /// <param name="length">Desired number of `NUL`s in the array</param>
        /// <returns>A `byte[]` of `NUL`s</returns>
        protected byte[] CreateNullArray(int length)
        {
            return Enumerable.Repeat((byte)0x00, length).ToArray();
        }
    }
}