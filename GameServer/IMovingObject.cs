using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public interface IMovingObject
    {
        Vector Position { get; set; }
        Vector Velocity { get; }
    }
}
