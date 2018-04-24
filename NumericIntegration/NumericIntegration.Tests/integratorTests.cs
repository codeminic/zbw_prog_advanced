using Xunit;

namespace NumericIntegration.Tests
{
    public class IntegratorTests
    {
        [Theory]
        [InlineData(100, 10, 11)]
        [InlineData(0, 6, 0)]
        [InlineData(0, 0, 15)]
        public void Integrate_WithConstantFunction_ReturnsCorrectArea(double expectedArea, int c, int steps)
        {
            var area = Integrator.Integrate(x => c, steps);
            Assert.Equal(expectedArea, area);
        }

        [Theory]
        [InlineData(50, 1, 0, 11)]
        [InlineData(100, 2, 0, 11)]
        [InlineData(150, 2, 5, 11)]
        [InlineData(0, 2, 5, 0)]
        [InlineData(0, 0, 0, 5)]
        public void Integrate_WithLinearFunction_ReturnsCorrectArea(double expectedArea, int a, int b, int steps)
        {
            var area = Integrator.Integrate(x => x*a + b, steps);
            Assert.Equal(expectedArea, area);
        }
    }
}
