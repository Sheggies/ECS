using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystem
{
    /// <summary>
    /// This interface constitutes the basis for any component within this ECS framework
    /// </summary>
    public interface IComponent : IEquatable<IComponent>, ICloneable
    {
    }
}
