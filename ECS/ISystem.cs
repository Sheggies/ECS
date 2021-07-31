using System;

namespace EntityComponentSystem
{
    /// <summary>
    /// A system represents the main behavioural object of the ECS framework. It acts on all the entities that are composed of a component of concern
    /// </summary>
    /// <typeparam name="T">The component to act upon</typeparam>
    public interface ISystem<T> : IEquatable<ISystem<T>>
        where T : class, IComponent
    {
        /// <summary>
        /// Awakes the system. This gets called in the initialisation phase of the system
        /// </summary>
        void Awake(IEngine engine);

        /// <summary>
        /// The update method is called once every tick after the initialisation phase
        /// </summary>
        /// <param name="entity">The entity to act upon</param>
        /// <param name="deltaTime">Elapsed time since last call</param>
        void Update(IEntity entity, TimeSpan deltaTime);

        /// <summary>
        /// Stops the system. This method gets called when the system is supposed to shut down
        /// </summary>
        void Stop();
    }
}
