using EntityComponentSystem.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();
            var entity = engine.CreateEntity();
            var component = entity.AddComponent<Transformable>();
            component.X = 69;
            component.Y = 42;
            component.Z = 1337;
            engine.AddSystem<Transformer>();
            engine.NextTick();
        }
    }
}
