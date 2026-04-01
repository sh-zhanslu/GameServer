using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public class Vector
    {
        private readonly int[] _coordinates;

        public Vector(params int[] coordinates)
        {
            if (coordinates == null)
                throw new ArgumentNullException(nameof(coordinates));
            _coordinates = coordinates.ToArray();
        }

        public int Dimension => _coordinates.Length;

        public int this[int index] => _coordinates[index];

        public Vector Add(Vector other)
        {
            if (other.Dimension != Dimension)
                throw new ArgumentException("Dimensions must match.");
            var newCoords = new int[Dimension];
            for (int i = 0; i < Dimension; i++)
                newCoords[i] = _coordinates[i] + other._coordinates[i];
            return new Vector(newCoords);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Vector other)
            {
                if (Dimension != other.Dimension)
                    return false;
                for (int i = 0; i < Dimension; i++)
                    if (_coordinates[i] != other._coordinates[i])
                        return false;
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            foreach (var coord in _coordinates)
                hash = hash * 31 + coord.GetHashCode();
            return hash;
        }

        public static Vector operator +(Vector a, Vector b) => a.Add(b);
        public static bool operator ==(Vector a, Vector b) => Equals(a, b);
        public static bool operator !=(Vector a, Vector b) => !Equals(a, b);
    }
}