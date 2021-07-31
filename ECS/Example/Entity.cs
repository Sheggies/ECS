using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystem.Example
{
    public sealed class Entity : IEntity
    {
        private readonly Guid guid;
        private readonly IDictionary<Type, ICollection<IComponent>> components;

        public Entity(Guid guid)
        {
            this.guid = guid;
            this.components = new Dictionary<Type, ICollection<IComponent>>();
        }

        public Entity(Guid guid, IEntity prototype) : this(guid)
        {
            foreach (var c in prototype.GetComponents<IComponent>())
            {
                if (this.components.TryGetValue(c.GetType(), out ICollection<IComponent> collection))
                {
                    collection.Add(c);
                }
                else
                {
                    this.components.Add(c.GetType(), new HashSet<IComponent>
                    {
                        (IComponent)c.Clone()
                    });
                }
            }
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Entity e = (Entity)obj;
                return this.guid == e.guid;
            }
        }

        public override int GetHashCode()
        {
            return this.guid.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool Equals(IEntity other)
        {
            return this.Guid == other.Guid;
        }

        public T AddComponent<T>()
            where T : IComponent, new()
        {
            var component = new T();
            this.AddComponent<T>(component);

            return component;
        }

        public bool AddComponent<T>(T component)
            where T : IComponent
        {
            bool success;

            if (this.components.TryGetValue(typeof(T), out ICollection<IComponent> collection))
            {
                collection.Add(component);
                success = true;
            }
            else
            {
                this.components.Add(typeof(T), new HashSet<IComponent>
                {
                    component
                });
                success = true;
            }

            return success;
        }

        public ICollection<T> GetComponents<T>()
            where T : IComponent
        {
            return (ICollection<T>)this.components[typeof(T)];
        }

        public Guid Guid
        {
            get { return this.guid; }
        }

        public bool HasComponent<T>()
            where T : IComponent
        {
            return this.components.ContainsKey(typeof(T));
        }

        public bool HasComponent(Type t)
        {
            return this.components.ContainsKey(t);
        }

        public bool RemoveComponent(IComponent c)
        {
            var removed = false;

            if (this.components.TryGetValue(c.GetType(), out ICollection<IComponent> collection))
            {
                removed = collection.Remove(c);

                if (collection.Count == 0)
                {
                    this.components.Remove(c.GetType());
                }
            }

            return removed;
        }

        public static bool operator == (Entity a, Entity b)
        {
            return a.Equals(b);
        }

        public static bool operator != (Entity a, Entity b)
        {
            return !a.Equals(b);
        }
    }
}
