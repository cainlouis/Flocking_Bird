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

        public Sparrow(float P1, float P2, float V1, float V2) : base()
        {
        }

        ///<summary>
        ///This method is an event handler to calculate and set amountToSteer vector using the flocking algorithm rules
        ///</summary>
        ///<param name="sparrows">List of sparrows</param>
        public override void CalculateBehaviour(List<Sparrow> sparrows)
        {
            //TODO: Set the amountToSteer vector with the vectors returned by 
            //Cohesion, Alignment, Avoidance methods
            Vector2 alignmentAndCohesion = Alignment(sparrows) + Cohesion(sparrows);
            Vector2 sum = Avoidance(sparrows) + alignmentAndCohesion;
            amountToSteer += sum;
        }

        ///<summary>
        ///This method is an event handler to calculate and update amountToSteer vector with the amount to steer to flee a chasing raven
        ///</summary>
        ///<param name="raven">A Raven object</param>
        public void CalculateRavenAvoidance(Raven raven)
        {
            //TODO: Add the vector returned by FleeRaven to the amountToSteer vector.
            amountToSteer += FleeRaven(raven);
        }

        //TODO: Code the following private helper methods to implement the flocking algorithm rules. 
        //The method headers are declared below:
        private Vector2 Alignment(List<Sparrow> sparrows)
        {

        }
        private Vector2 Cohesion(List<Sparrow> sparrows);
        private Vector2 Avoidance(List<Sparrow> sparrows);
        private Vector2 FleeRaven(Raven raven);

    }
}