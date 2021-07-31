using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystem
{
    /// <summary>
    /// An engine object is the main workhorse. It provides the main entry point for the ECS framework
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Triggers the next tick
        /// </summary>
        void NextTick();

        /// <summary>
        /// Returns the current computation tick
        /// </summary>
        /// <returns>The current tick</returns>
        int CurrentTick
        {
            get;
        }

        /// <summary>
        /// Returns a collection of all the existing entities within the current runtime
        /// </summary>
        /// <returns>The collection of all the entities</returns>
        ICollection<IEntity> GetEntities();

        /// <summary>
        /// Creates a new entity adds it to the runtime and returns it
        /// </summary>
        /// <returns>The newly created entity</returns>
        IEntity CreateEntity();

        /// <summary>
        /// Removes the entity that is saved with the specified Guid
        /// </summary>
        /// <param name="entityGuid">The entity's Guid</param>
        /// <returns>True if the entity could be removed, otherwise false</returns>
        bool RemoveEntity(Guid entityGuid);

        /// <summary>
        /// Removes the given entity
        /// </summary>
        /// <param name="entity">The entity to remove</param>
        /// <returns>True if the entity could be removed, otherwise false</returns>
        bool RemoveEntity(IEntity entity);

        /// <summary>
        /// Adds a new system object, which acts upon 
        /// </summary>
        /// <typeparam name="T">The system to register</typeparam>
        /// <returns>Whether the system has been added and created</returns>
        bool AddSystem<T>()
            where T : class, ISystem<IComponent>, new();

        /// <summary>
        /// Adds the passed system object to the engine
        /// </summary>
        /// <typeparam name="T">The type of the system</typeparam>
        /// <param name="system">The system instance</param>
        /// <returns>Whether the system has been added</returns>
        bool AddSystem<T>(T system)
            where T : class, ISystem<IComponent>;

        /// <summary>
        /// Removes a system object from the engine, if it exists
        /// </summary>
        /// <typeparam name="T">The system to remove</typeparam>
        /// <returns>True if the system could be removed, otherwise false</returns>
        bool RemoveSystem<T>()
            where T : class, ISystem<IComponent>;
    }
}
