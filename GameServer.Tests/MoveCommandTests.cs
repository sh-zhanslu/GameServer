#nullable disable
using Xunit;
using Moq;
using System;
using GameServer.Commands;

namespace GameServer.Tests
{
    public class MoveCommandTests
    {
        [Fact]
        public void Execute_MovesObjectCorrectly()
        {
            // Arrange
            var initialPosition = new Vector(12, 5);
            var velocity = new Vector(-4, 1);
            var expectedPosition = new Vector(8, 6);

            var mock = new Mock<IMovingObject>();
            mock.Setup(m => m.Position).Returns(initialPosition);
            mock.Setup(m => m.Velocity).Returns(velocity);
            mock.SetupSet(m => m.Position = It.Is<Vector>(v => v.Equals(expectedPosition))).Verifiable();

            var command = new MoveCommand(mock.Object);

            // Act
            command.Execute();

            // Assert
            mock.Verify();
        }

        [Fact]
        public void Execute_WhenPositionIsNull_Throws()
        {
            var mock = new Mock<IMovingObject>();
            mock.Setup(m => m.Position).Returns((Vector)null);
            mock.Setup(m => m.Velocity).Returns(new Vector(1, 1));

            var command = new MoveCommand(mock.Object);

            Assert.Throws<InvalidOperationException>(() => command.Execute());
        }

        [Fact]
        public void Execute_WhenVelocityIsNull_Throws()
        {
            var mock = new Mock<IMovingObject>();
            mock.Setup(m => m.Position).Returns(new Vector(0, 0));
            mock.Setup(m => m.Velocity).Returns((Vector)null);

            var command = new MoveCommand(mock.Object);

            Assert.Throws<InvalidOperationException>(() => command.Execute());
        }

        [Fact]
        public void Execute_WhenCannotSetNewPosition_Throws()
        {
            var mock = new Mock<IMovingObject>();
            mock.Setup(m => m.Position).Returns(new Vector(0, 0));
            mock.Setup(m => m.Velocity).Returns(new Vector(1, 1));
            mock.SetupSet(m => m.Position = It.IsAny<Vector>()).Throws<Exception>();

            var command = new MoveCommand(mock.Object);

            Assert.Throws<InvalidOperationException>(() => command.Execute());
        }
    }
}