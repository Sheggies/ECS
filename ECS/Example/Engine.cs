using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystem.Example
{
    public class Engine : IEngine
    {
        private readonly IDictionary<Guid, IEntity> entities;
        private readonly IDictionary<Type, ISystem<IComponent>> systems;
        private readonly Stopwatch stopwatch;

        public Engine()
        {
            this.entities = new Dictionary<Guid, IEntity>();
            this.systems = new Dictionary<Type, ISystem<IComponent>>();
            this.stopwatch = new Stopwatch();
            this.CurrentTick = 0;
        }

        public void NextTick()
        {
            TimeSpan deltaTime = this.stopwatch.Elapsed;
            this.CurrentTick++;
            this.stopwatch.Restart();

            foreach (var systemKvp in this.systems)
            {
                foreach (var entity in this.entities.Values)
                {
                    if (entity.HasComponent(systemKvp.Key.GetGenericArguments()[0]))
                    {
                        systemKvp.Value.Update(entity, deltaTime);
                    }
                }
            }

            this.stopwatch.Stop();
        }

        public int CurrentTick
        {
            get;
            private set;
        }

        public IEntity CreateEntity()
        {
            var entity = new Entity(Guid.NewGuid());
            this.entities.Add(entity.Guid, entity);

            return entity;
        }

        public ICollection<IEntity> GetEntities()
        {
            return this.entities.Values;
        }

        public bool RemoveEntity(Guid entityGuid)
        {
            return this.entities.Remove(entityGuid);
        }

        public bool RemoveEntity(IEntity entity)
        {
            return this.entities.Remove(entity.Guid);
        }

        public bool AddSystem<T>()
            where T : class, ISystem<IComponent>, new()
        {
            return this.AddSystem<T>(new T());
        }

        public bool AddSystem<T>(T system)
            where T : class, ISystem<IComponent>
        {
            if (!this.systems.ContainsKey(typeof(T)))
            {
                this.systems.Add(typeof(T), system);
                system.Awake(this);

                return true;
            }

            return false;
        }

        public bool RemoveSystem<T>()
            where T : class, ISystem<IComponent>
        {
            if (this.systems.ContainsKey(typeof(T)))
            {
                this.systems[typeof(T)].Stop();
            }

            return this.systems.Remove(typeof(T));
        }
    }
}
