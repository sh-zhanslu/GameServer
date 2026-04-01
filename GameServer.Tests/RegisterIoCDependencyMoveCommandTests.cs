using Xunit;
using GameServer.Commands;
using System.Collections.Generic;

namespace GameServer.Tests
{
    public class RegisterIoCDependencyMoveCommandTests
    {
        [Fact]
        public void Execute_RegistersDependency()
        {
            var registerCommand = new RegisterIoCDependencyMoveCommand();

            registerCommand.Execute();

            var gameObject = new Dictionary<string, object>
            {
                ["Position"] = new Vector(0, 0),
                ["Velocity"] = new Vector(1, 1)
            };

            var command = IoC.Resolve<ICommand>("Commands.Move", gameObject);

            Assert.NotNull(command);
            Assert.IsType<MoveCommand>(command);
        }
    }
}