using GameServer.Adapters;
using System.Collections.Generic;

namespace GameServer.Commands
{
    public class RegisterIoCDependencyMoveCommand : ICommand
    {
        public void Execute()
        {
            IoC.Register("Adapters.IMovingObject", args =>
            {
                var obj = (IDictionary<string, object>)args[0];
                return new MovingObjectAdapter(obj);
            });

            IoC.Register("Commands.Move", args =>
            {
                var obj = (IDictionary<string, object>)args[0];
                var adapter = IoC.Resolve<IMovingObject>("Adapters.IMovingObject", obj);
                return new MoveCommand(adapter);
            });
        }
    }
}
