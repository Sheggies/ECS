using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystem.Example
{
    public abstract class BaseSystem<T> : ISystem<T>
        where T : class, IComponent
    {
        protected IEngine engine;

        protected BaseSystem()
        {

        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                BaseSystem<T> b = (BaseSystem<T>)obj;
                return this.GetType() == b.GetType();
            }
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }

        public bool Equals(ISystem<T> other)
        {
            return this.GetType() == other.GetType();
        }

        public virtual void Awake(IEngine engine)
        {
            this.engine = engine;
        }

        public abstract void Update(IEntity entity, TimeSpan deltaTime);
        public abstract void Stop();

        public static bool operator == (BaseSystem<T> a, BaseSystem<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator != (BaseSystem<T> a, BaseSystem<T> b)
        {
            return !a.Equals(b);
        }
    }
}
