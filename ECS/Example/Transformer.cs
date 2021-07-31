using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystem.Example
{
    public sealed class Transformer : BaseSystem<Transformable>
    {
        public Transformer() : base()
        {

        }

        public override void Awake(IEngine engine)
        {
            base.Awake(engine);
            Console.WriteLine("Awoken");
            // throw new NotImplementedException();
        }

        public override void Stop()
        {
            Console.WriteLine("Stopped");
            // throw new NotImplementedException();
        }

        public override void Update(IEntity entity, TimeSpan deltaTime)
        {
            Console.WriteLine("Updated");
            Console.WriteLine(entity.GetComponents<Transformable>().ToString());
        }
    }
}
