using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    ///<summary>
    ///This class is used to represent a single sparrow. 
    ///This class is just a starting point. Complete the TODO sections
    ///</summary>
    public class Sparrow : Bird
    {
        //TODO: Add the constructor, properties and fields as specified in the instructions document.
        public Sparrow() : base()
        {
        }

        public Sparrow(float P1, float P2, float V1, float V2) : base(P1, P2, V1, V2)
        {
        }

        ///<summary>
        ///This method is an event handler to calculate and set amountToSteer vector using the flocking algorithm rules
        ///</summary>
        ///<param name="sparrows">List of sparrows</param>
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

        //TODO: Code the following private helper methods to implement the flocking algorithm rules. 
        //The method headers are declared below:
        public Vector2 Alignment(List<Sparrow> sparrows)
        {
            Vector2 align = new Vector2(0, 0);
            List<Sparrow> neighbours = GetNeighbours(sparrows);
            if (neighbours.Count > 0)
            {
                foreach (Sparrow sparrow in neighbours)
                {
                    align += sparrow.Velocity;
                }
                align = GetVector2(align, neighbours.Count, "alignment");
            }
            return align;
        }

        public Vector2 Cohesion(List<Sparrow> sparrows)
        {
            Vector2 displacement = new Vector2(0, 0);
            List<Sparrow> neighbours = GetNeighbours(sparrows);
            if (neighbours.Count > 0)
            {
                foreach (Sparrow sparrow in neighbours)
                {
                    displacement += sparrow.Position;
                }
                displacement = GetVector2(displacement, neighbours.Count, "cohesion");
            }
            return displacement;
        }
        public Vector2 Avoidance(List<Sparrow> sparrows)
        {
            float distance;
            int radius = World.AvoidanceRadius;
            Vector2 difference;
            Vector2 result = new Vector2(0, 0);
            int count = 0;
            foreach (Sparrow sparrow in sparrows)
            {
                distance = Vector2.DistanceSquared(this.Position, sparrow.Position);
                if (distance < Math.Pow(radius, 2) && !this.Equals(sparrow))
                {
                    difference = this.Position - sparrow.Position;
                    difference /= distance;
                    result += difference;
                    count++;
                }
            }
            if (count > 0)
            {
                result = GetVector2(result, count, "avoidance");
            }
            return result;
        }
        public Vector2 FleeRaven(Raven raven)
        {
            Vector2 toSteer = new Vector2(0, 0);
            float distance = Vector2.DistanceSquared(this.Position, raven.Position);
            if (distance < Math.Pow(World.AvoidanceRadius, 2))
            {
                toSteer = this.Position - raven.Position;
                toSteer /= distance;
                toSteer = Vector2.Normalize(toSteer) * World.MaxSpeed;
            }
            return toSteer;
        }

        public List<Sparrow> GetNeighbours(List<Sparrow> sparrows)
        {
            List<Sparrow> neighbours = new List<Sparrow>();
            int radius = World.NeighbourRadius;
            float distance;
            foreach (Sparrow sparrow in sparrows)
            {
                distance = Vector2.DistanceSquared(this.Position, sparrow.Position);
                if (distance < Math.Pow(radius, 2) && !this.Equals(sparrow))
                {
                    neighbours.Add(sparrow);
                }
            }
            return neighbours;
        }

        private Vector2 GetVector2(Vector2 toModify, int count, string whichFunction)
        {
            toModify = toModify / count;
            if (whichFunction.Equals("cohesion"))
            {
                toModify -= this.Position;
            }
            toModify = Vector2.Normalize(toModify) * World.MaxSpeed;
            toModify -= this.Velocity;
            toModify = Vector2.Normalize(toModify);
            return toModify;
        }
    }
}