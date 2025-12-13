namespace Domain.Tests
{
    public class TargetWordTests
    {
        [Fact]
        public void HappyFlow()
        {
            // Arrange
            var word = new TargetWord("apple");
            word.AddSegments(["a", "b", "pp", "le", "app", "l", "e"]);

            // Act
            var result = word.GetAllCombinations().ToList();

            // Assert
            Assert.True(result.Count == 4);
            Assert.Contains("a+pp+le=apple", result);
            Assert.Contains("a+pp+l+e=apple", result);
            Assert.Contains("app+le=apple", result);
            Assert.Contains("app+l+e=apple", result);
        }
    }
}
