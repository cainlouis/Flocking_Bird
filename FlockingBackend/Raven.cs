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
        //TODO: Add the constructor, properties and fields as specified in the instructions document.

        ///<summary>
        ///This method is an event handler that updates the velocity and position of a raven.
        ///</summary>
        public void Move()
        {
            //TODO: 
            this.Velocity += amountToSteer;
            this.Velocity /= World.MaxSpeed;
            this.Position += this.Velocity;
        }
        ///<summary>
        ///This method is an event handler to calculate and set amountToSteer vector
        ///</summary>
        ///<param name="sparrows">List of sparrows</param>
        public override void CalculateBehaviour(List<Sparrow> sparrows) 
        {
            amountToSteer = ChaseSparrow(sparrows);
        }

        //TODO: Code the following private helper methods to implement chase sparrows.
        //The method header are declared below:
        private Vector2 ChaseSparrow (List<Sparrow> sparrows) {
            float smallestDistance= World.AvoidanceRadius;
            float distance;
            Sparrow closestSparrow = null;
            foreach (Sparrow sparrow in sparrows) {
                distance = Vector2.DistanceSquared(sparrow.Position, this.Position);
                if (distance < smallestDistance){
                    smallestDistance = distance;
                    closestSparrow = sparrow;
                }
            }
            Vector2 result = new Vector2(0,0);
            if (closestSparrow != null) {
                result = closestSparrow.Position - this.Position;
            }
            return result;
        }  
    }
}