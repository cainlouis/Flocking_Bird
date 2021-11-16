using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    ///<summary>
    ///This class is used to represent a single sparrow. 
    ///</summary>
    public class Sparrow : Bird
    {
        /// <summary>
        /// Constructor used by the frontend
        /// </summary>
        public Sparrow() : base()
        {
        }

        /// <summary>
        /// Constructor used for tests
        /// </summary>
        /// <param name="P1">Value of the Position on the x-axis</param>
        /// <param name="P2">Value of the Position on the y-axis</param>
        /// <param name="V1">Value of the Velocity on the x-axis</param>
        /// <param name="V2">Value of the Velocity on the y-axis</param>
        public Sparrow(float P1, float P2, float V1, float V2) : base(P1, P2, V1, V2)
        {
        }

        ///<summary>
        ///This method is an event handler to calculate and set amountToSteer vector using the flocking algorithm rules
        ///</summary>
        ///<param name="sparrows">List of sparrows from World</param>
        public override void CalculateBehaviour(List<Sparrow> sparrows)
        {
            base.amountToSteer = this.Alignment(sparrows) + this.Cohesion(sparrows) + this.Avoidance(sparrows);
        }

        ///<summary>
        ///This method is an event handler to calculate and update amountToSteer vector with the amount to steer to flee a chasing raven
        ///</summary>
        ///<param name="raven">A Raven object</param>
        public void CalculateRavenAvoidance(Raven raven)
        {
            base.amountToSteer += FleeRaven(raven);
        }

        /// <summary>
        /// Calculate how much this sparrow should adjust its velocity to align itself with the nearby sparrows. 
        /// </summary>
        /// <param name="sparrows">List of sparrows from World</param>
        /// <returns>A vector that determines how much the sparrow should adjust its velocity</returns>
        public Vector2 Alignment(List<Sparrow> sparrows)
        {
            Vector2 align = new Vector2(0, 0);
            //Find all the Sparrows that are within this sparrow’s neighbour radius 
            List<Sparrow> neighbours = GetNeighbours(sparrows);
            //if there is neighbours
            if (neighbours.Count > 0)
            {
                foreach (Sparrow sparrow in neighbours)
                {
                    //Add sparrow’s velocity to the result vector 
                    align += sparrow.Velocity;
                }
                //Calculate the average velocity, normalize, multiply by MaxSpeed, substract this velocity and normalize again
                align = GetVector2(align, neighbours.Count, "alignment");
            }
            return align;
        }

        /// <summary>
        /// Calculate how much this sparrow should adjusts its position to match the average position of the neighbouring sparrows
        /// </summary>
        /// <param name="sparrows">List of Sparrows from World</param>
        /// <returns>A vector that determines how much the sparrow should adjust its position</returns>
        public Vector2 Cohesion(List<Sparrow> sparrows)
        {
            Vector2 displacement = new Vector2(0, 0);
            //Find all the Sparrows that are within this sparrow’s neighbour radius 
            List<Sparrow> neighbours = GetNeighbours(sparrows);
            //if there is neighbours
            if (neighbours.Count > 0)
            {
                foreach (Sparrow sparrow in neighbours)
                {
                    //Add sparrow’s position to the result vector
                    displacement += sparrow.Position;
                }
                //Calculate the average velocity,substract this.Position, normalize, multiply by MaxSpeed, substract this velocity and normalize again
                displacement = GetVector2(displacement, neighbours.Count, "cohesion");
            }
            return displacement;
        }

        /// <summary>
        /// Calculate how much this sparrow adjust its velocity to avoid converging into the sparrows near it. 
        /// </summary>
        /// <param name="sparrows">List of Sparrows from World</param>
        /// <returns>A vector that determines how much the sparrow should adjust its velocity to avoid converging into the sparrows near it. </returns>
        public Vector2 Avoidance(List<Sparrow> sparrows)
        {
            float distance;
            int radius = World.avoidanceRadius;
            Vector2 difference;
            Vector2 result = new Vector2(0, 0);
            int count = 0;
            //For each sparrow in the list of Sparrows, calculate the squared distance between this Sparrow’s position 
            //and a sparrow in the list.
            foreach (Sparrow sparrow in sparrows)
            {
                distance = Vector2.DistanceSquared(this.Position, sparrow.Position);
                //If the calculated squared distance is less than the squared avoidance and not itself
                if (distance < Math.Pow(radius, 2) && !this.Equals(sparrow))
                {
                    //Calculate the difference between the two positions 
                    difference = this.Position - sparrow.Position;
                    //Then divide the difference by the distance
                    difference /= distance;
                    //Add this difference to a result vector 
                    result += difference;
                    //Count to calculate the average
                    count++;
                }
            }
            //If the count is not zero
            if (count > 0)
            {
                //Calculate the average velocity, normalize, multiply by MaxSpeed, substract this velocity and normalize again
                result = GetVector2(result, count, "avoidance");
            }
            return result;
        }

        /// <summary>
        /// Calculate how much this sparrow should adjust the amount to steer to flee the raven.
        /// </summary>
        /// <param name="raven">Raven from the World</param>
        /// <returns>A vector that determines how much the sparrow should adjust the amount to steer</returns>
        public Vector2 FleeRaven(Raven raven)
        {
            Vector2 toSteer = new Vector2(0, 0);
            //Calculate the squared distance between this Sparrow’s position and the raven
            float distance = Vector2.DistanceSquared(this.Position, raven.Position);
            //If the calculated squared distance is less than the squared avoidance radius, 
            if (distance < Math.Pow(World.AvoidanceRadius, 2))
            {
                //Calculate the difference between the two positions 
                toSteer = this.Position - raven.Position;
                //Then divide the difference by the distance
                toSteer /= distance;
                //Normalize the difference you just calculated and multiply by Max speed
                toSteer = Vector2.Normalize(toSteer) * World.MaxSpeed;
            }
            return toSteer;
        }

        /// <summary>
        /// Get the neighbouring sparrows to this sparrow.
        /// </summary>
        /// <param name="sparrows">List of Sparrows</param>
        /// <returns>List of neighbouring sparrows</returns>
        public List<Sparrow> GetNeighbours(List<Sparrow> sparrows)
        {
            List<Sparrow> neighbours = new List<Sparrow>();
            int radius = World.neighbourRadius;
            float distance;
            foreach (Sparrow sparrow in sparrows)
            {
                //Calculate the squared distance between this Sparrow’s position and the sparrow from the list
                distance = Vector2.DistanceSquared(this.Position, sparrow.Position);
                //If the squared distance is less than the squared neighbour radius 
                //and if the sparrow in the list is not equal to this sparrow object 
                if (distance < Math.Pow(radius, 2) && !this.Equals(sparrow))
                {
                    //add to the list
                    neighbours.Add(sparrow);
                }
            }
            return neighbours;
        }

        /// <summary>
        /// This method does the calculation for the 3 algorithms and returns the result
        /// </summary>
        /// <param name="toModify">The vector from the algorithm</param>
        /// <param name="count">The number of neighbours hence the number used to get the average</param>
        /// <param name="whichFunction">String used to determine if the step for cohesion should be done</param>
        /// <returns>The result vector from all the calculation</returns>
        private Vector2 GetVector2(Vector2 toModify, int count, string whichFunction)
        {
            //Calculate the average of the vector gotten as input
            toModify = toModify / count;
            if (whichFunction.Equals("cohesion"))
            {
                //Only for cohesion, substract this position from the vector
                toModify -= this.Position;
            }
            //Normalize and multiply by MaxSpeed
            toModify = Vector2.Normalize(toModify) * World.MaxSpeed;
            //Substract this velocity from vector
            toModify -= this.Velocity;
            //Normalize again
            toModify = Vector2.Normalize(toModify);
            return toModify;
        }
    }
}