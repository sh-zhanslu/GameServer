using System;

namespace GameServer
{
    public struct Angle
    {
        private readonly int _numerator;
        public static int Denominator { get; set; } = 360;

        public Angle(int numerator)
        {
            numerator %= Denominator;
            if (numerator < 0) numerator += Denominator;
            _numerator = numerator;
        }

        public int Numerator => _numerator;

        public Angle Add(Angle other) => new Angle(_numerator + other._numerator);

        public double ToRadians() => (_numerator / (double)Denominator) * 2 * Math.PI;

        public static implicit operator double(Angle angle) => angle.ToRadians();

        public static Angle operator +(Angle a, Angle b) => a.Add(b);
        public static bool operator ==(Angle a, Angle b) => a._numerator == b._numerator && Angle.Denominator == Angle.Denominator;
        public static bool operator !=(Angle a, Angle b) => !(a == b);

        public override bool Equals(object? obj) => obj is Angle other && this == other;
        public override int GetHashCode() => _numerator.GetHashCode() ^ Denominator.GetHashCode();
    }
}