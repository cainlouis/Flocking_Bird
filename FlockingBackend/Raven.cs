using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    ///<summary>
    ///This class is used to represent a single raven. 
    ///</summary>
    public class Raven : Bird
    {
        /// <summary>
        /// Constructor used by the frontend
        /// </summary>
        public Raven() : base()
        {
        }

        /// <summary>
        /// Constructor used for tests
        /// </summary>
        /// <param name="P1">Value of the Position on the x-axis</param>
        /// <param name="P2">Value of the Position on the y-axis</param>
        /// <param name="V1">Value of the Velocity on the x-axis</param>
        /// <param name="V2">Value of the Velocity on the y-axis</param>
        public Raven(float P1, float P2, float V1, float V2) : base(P1, P2, V1, V2)
        {
        }

        ///<summary>
        ///This method is an event handler that updates the velocity and position of a raven.
        ///</summary>
        public override void Move()
        {
            //Add the amount to steer to this velocity
            this.Velocity += base.amountToSteer;
            //Normalize result vector and multiply by MaxSpeed
            this.Velocity = Vector2.Normalize(this.Velocity) * World.MaxSpeed;
            //Add velocity to this Position
            this.Position += this.Velocity;
            //Call AppearOnOppositeSide so raven does not disappear
            this.AppearOnOppositeSide();
        }

        ///<summary>
        ///This method is an event handler to calculate and set amountToSteer vector
        ///</summary>
        ///<param name="sparrows">List of sparrows</param>
        public override void CalculateBehaviour(List<Sparrow> sparrows)
        {
            base.amountToSteer = ChaseSparrow(sparrows);
        }

        /// <summary>
        /// Calculate how much this raven should adjusts its position to chase the nearest sparrow.
        /// </summary>
        /// <param name="sparrows">List of sparrows from World</param>
        /// <returns>A vector that determines how much this raven should adjusts its position</returns>
        public Vector2 ChaseSparrow(List<Sparrow> sparrows)
        {
            float smallestDistance = float.MaxValue;
            float distance;
            Sparrow closestSparrow = null;
            foreach (Sparrow sparrow in sparrows)
            {
                //Calculate the distance between sparrow and the raven
                distance = Vector2.DistanceSquared(sparrow.Position, this.Position);
                //If the distance is less than avoidanceRadius and is smaller than the previous closest sparrow
                if (distance < Math.Pow(World.AvoidanceRadius, 2) && distance < smallestDistance)
                {
                    //SmallestDistance equal the distance between sparrow and raven
                    smallestDistance = distance;
                    //And closest sparrow is this sparrow
                    closestSparrow = sparrow;
                }
            }
            Vector2 result = new Vector2(0, 0);
            //If there is a sparrow in the avoidance radius
            if (closestSparrow != null)
            {
                //Substract the this position to the sparrow position
                result = closestSparrow.Position - this.Position;
            }
            return result;
        }
    }
}