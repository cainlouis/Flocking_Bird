using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    /// <summary>
    /// A list of the delegates that will be used to subscribe the sparrows 
    /// and raven to the flock.
    /// </summary>
    public class Delegates
    {
        /// <summary>
        /// Delegate used to raise the event to calculate the movement vector
        /// for each sparrow and the raven,
        /// </summary>
        /// <param name="sparrows">A list of Sparrows objects</param>
        public delegate void CalculateMoveVector(List<Sparrow> sparrows);

        /// <summary>
        /// Delegate used to raise the event required to move the sparrows and the 
        /// raven.
        /// </summary>
        public delegate void MoveBird();

        /// <summary>
        /// Delegate used to raise the event required to calculate the vector amount to
        /// steer to flee that chasing raven
        /// </summary>
        /// <param name="raven">Raven object</param>
        public delegate void CalculateRavenAvoidance(Raven raven);
    }
}