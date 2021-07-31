using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystem
{
    /// <summary>
    /// An entity serves as the general purpose object that contains all the components which get acted upon. Its behaviour is characterised by its components.
    /// </summary>
    public interface IEntity : IEquatable<IEntity>
    {
        /// <summary>
        /// An identifier that uniquely identifies the entity within the current runtime
        /// </summary>
        Guid Guid
        {
            get;
        }

        /// <summary>
        /// Returns a filtered collection of the components that the entity is composed of
        /// </summary>
        /// <typeparam name="T">The component to look for</typeparam>
        /// <returns>A collection of components</returns>
        ICollection<T> GetComponents<T>()
            where T : IComponent;

        /// <summary>
        /// Adds a new component of type T which implements the interface IComponent
        /// </summary>
        /// <typeparam name="T">The component to add to the entity</typeparam>
        /// <returns>The newly added component</returns>
        T AddComponent<T>()
            where T : IComponent, new();

        /// <summary>
        /// Adds a copy of the passed component to the entity
        /// </summary>
        /// <typeparam name="T">The component's type to add to the entity</typeparam>
        /// <param name="component">The component to add</param>
        /// <returns>True if the componend could be added, otherwise false</returns>
        bool AddComponent<T>(T component)
            where T : IComponent;

        /// <summary>
        /// Removes the specified component from the entity
        /// </summary>
        /// <param name="c">The component to remove</param>
        /// <returns>True if the component could be removed, otherwise false</returns>
        bool RemoveComponent(IComponent c);

        /// <summary>
        /// Checks whether the entity constitutes of at least one instance of the specified component
        /// </summary>
        /// <typeparam name="T">The component to look for</typeparam>
        /// <returns>True if the entity contains the specified component, otherwise false</returns>
        bool HasComponent<T>()
            where T : IComponent;

        /// <summary>
        /// Checks whether the entity constitutes of at least one instance of the specified component
        /// </summary>
        /// <param name="t">The component type to look for</param>
        /// <returns>True if the entity contains the specified component, otherwise false</returns>
        bool HasComponent(Type t);
    }
}
