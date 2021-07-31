using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystem.Example
{
    public sealed class Transformable : IComponent
    {
        public double X, Y, Z;

        public Transformable() : this(0, 0, 0)
        {

        }

        public Transformable(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Transformable t = (Transformable)obj;
                return this.GetHashCode() == t.GetHashCode();
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public bool Equals(IComponent other)
        {
            return this.Equals((object)other);
        }

        public object Clone()
        {
            return new Transformable(this.X, this.Y, this.Z);
        }

        public static bool operator == (Transformable a, Transformable b)
        {
            return a.Equals(b);
        }

        public static bool operator != (Transformable a, Transformable b)
        {
            return !a.Equals(b);
        }
    }
}
