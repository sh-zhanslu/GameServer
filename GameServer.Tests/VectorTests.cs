using Xunit;
using System;

namespace GameServer.Tests
{
    public class VectorTests
    {
        [Fact]
        public void Add_VectorsSameDimension_ReturnsSum()
        {
            var v1 = new Vector(1, -1, 2);
            var v2 = new Vector(-1, 1, -2);
            var result = v1.Add(v2);
            Assert.Equal(new Vector(0, 0, 0), result);
        }

        [Fact]
        public void Add_VectorsDifferentDimension_Throws()
        {
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(1, 2);
            Assert.Throws<ArgumentException>(() => v1.Add(v2));
            Assert.Throws<ArgumentException>(() => v2.Add(v1));
        }

        [Fact]
        public void Equals_SameCoordinates_ReturnsTrue()
        {
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(1, 2, 3);
            Assert.Equal(v1, v2);
            Assert.True(v1 == v2);
        }

        [Fact]
        public void Equals_DifferentCoordinates_ReturnsFalse()
        {
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(1, 2, 4);
            Assert.NotEqual(v1, v2);
            Assert.True(v1 != v2);
        }

        [Fact]
        public void GetHashCode_ReturnsHashCode()
        {
            var v = new Vector(1, 2, 3);
            Assert.IsType<int>(v.GetHashCode());
        }
    }
}
