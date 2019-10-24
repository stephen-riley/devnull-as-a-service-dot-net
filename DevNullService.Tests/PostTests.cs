using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DevNullService.Tests
{
    public class PostTests : TestsBase
    {
        [Fact]
        public async Task PostData_StringHappyPath()
        {
            // Arrange
            var data = "this is data to delete";

            // Act
            var (status, content) = await ExecutePostWithStringAsync(data);

            // Assert
            status.Should().Be(HttpStatusCode.OK);
            content.Length.Should().Be(0);
        }

        [Fact]
        public async Task PostData_BinaryHappyPath()
        {
            // Arrange
            var data = Encoding.UTF8.GetBytes("this is data to delete");

            // Act
            var (status, content) = await ExecutePostWithBinaryAsync(data);

            // Assert
            status.Should().Be(HttpStatusCode.OK);
            content.Length.Should().Be(0);
        }

        [Fact]
        public async Task PostData_EmptyString()
        {
            // Arrange
            var data = "";

            // Act
            var (status, content) = await ExecutePostWithStringAsync(data);

            // Assert
            status.Should().Be(HttpStatusCode.OK);
            content.Length.Should().Be(0);
        }

        [Fact]
        public async Task PostData_EmptyByteArray()
        {
            // Arrange
            var data = new byte[0];

            // Act
            var (status, content) = await ExecutePostWithBinaryAsync(data);

            // Assert
            status.Should().Be(HttpStatusCode.OK);
            content.Length.Should().Be(0);
        }
    }
}