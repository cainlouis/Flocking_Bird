using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    ///<summary>
    ///This class is used to represent a single raven. 
    ///This class is just a starting point. Complete the TODO sections
    ///</summary>
    public class Raven : Bird
    {
        public Raven() : base()
        {
        }

        public Raven(float P1, float P2, float V1, float V2) : base(P1, P2, V1, V2)
        {
        }

        ///<summary>
        ///This method is an event handler that updates the velocity and position of a raven.
        ///</summary>
        public override void Move()
        {
            //TODO: 
            this.Velocity += base.amountToSteer;
            this.Velocity /= World.MaxSpeed;
            this.Position += this.Velocity;
            this.AppearOnOppositeSide();
        }

        ///<summary>
        ///This method is an event handler to calculate and set amountToSteer vector
        ///</summary>
        ///<param name="sparrows">List of sparrows</param>
        public override void CalculateBehaviour(List<Sparrow> sparrows)
        {
            base.amountToSteer += ChaseSparrow(sparrows);
        }

        //TODO: Code the following private helper methods to implement chase sparrows.
        //The method header are declared below:
        public Vector2 ChaseSparrow(List<Sparrow> sparrows)
        {
            float smallestDistance = World.AvoidanceRadius;
            float distance;
            Sparrow closestSparrow = null;
            foreach (Sparrow sparrow in sparrows)
            {
                distance = Vector2.DistanceSquared(sparrow.Position, this.Position);
                if (distance < smallestDistance)
                {
                    smallestDistance = distance;
                    closestSparrow = sparrow;
                }
            }
            Vector2 result = new Vector2(0, 0);
            if (closestSparrow != null)
            {
                result = closestSparrow.Position - this.Position;
            }
            return result;
        }
    }
}