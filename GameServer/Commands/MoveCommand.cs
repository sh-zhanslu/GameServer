#nullable disable
using System;

namespace GameServer.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly IMovingObject _movingObject;

        public MoveCommand(IMovingObject movingObject)
        {
            _movingObject = movingObject;
        }

        public void Execute()
        {
            if (_movingObject.Position == null)
                throw new InvalidOperationException("Cannot determine position.");
            if (_movingObject.Velocity == null)
                throw new InvalidOperationException("Cannot determine velocity.");

            try
            {
                _movingObject.Position = _movingObject.Position.Add(_movingObject.Velocity);
            }
            catch
            {
                throw new InvalidOperationException("Cannot set new position.");
            }
        }
    }
}