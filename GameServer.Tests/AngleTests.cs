using Xunit;

namespace GameServer.Tests
{
    public class AngleTests
    {
        [Fact]
        public void Addition_ModuloDenominator()
        {
            Angle.Denominator = 8;
            var a = new Angle(5);
            var b = new Angle(7);
            var result = a + b;
            Assert.Equal(4, result.Numerator);
        }

        [Fact]
        public void Equals_SameAngle_Equal()
        {
            Angle.Denominator = 8;
            var a = new Angle(15);
            var b = new Angle(23);
            Assert.Equal(a, b);
            Assert.True(a == b);
        }

        [Fact]
        public void Equals_DifferentAngle_NotEqual()
        {
            Angle.Denominator = 8;
            var a = new Angle(1);
            var b = new Angle(2);
            Assert.NotEqual(a, b);
            Assert.True(a != b);
        }

        [Fact]
        public void GetHashCode_ReturnsHashCode()
        {
            Angle.Denominator = 360;
            var a = new Angle(45);
            Assert.IsType<int>(a.GetHashCode());
        }
    }
}