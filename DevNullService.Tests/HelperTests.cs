using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DevNullService.Tests
{
    public class HelperTests : TestsBase
    {
        [Fact]
        public async Task CreatePostAsString_NullString()
        {
            // Arrange

            // Act
            var (status, content) = await ExecutePostWithStringAsync(null);

            // Assert
            status.Should().Be(HttpStatusCode.OK);
            content.Length.Should().Be(0);
        }

        [Fact]
        public async Task CreatePostAsBinary_NullBinary()
        {
            // Arrange

            // Act
            var (status, content) = await ExecutePostWithBinaryAsync(null);

            // Assert
            status.Should().Be(HttpStatusCode.OK);
            content.Length.Should().Be(0);
        }
    }
}