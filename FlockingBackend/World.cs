using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    public class World
    {
        private Flock Flock;
        public List<Sparrow> Sparrows
        {
            get;
        }
        public Raven Raven
        {
            get;
        }
        public static int initialCount; //number of sparrows
        public static int width; //Width of the canvas (“world”)
        public static int height; //Height of the canvas
        public static int maxSpeed; //Max speed of the birds
        public static int neighbourRadius; //Radius used to determine if a bird is a neighbour
        public static int avoidanceRadius; //Radius used to determine if a bird is too close

        static World()
        {
            initialCount = 150; //number of sparrows
            width = 1000; //Width of the canvas (“world”)
            height = 500; //Height of the canvas
            maxSpeed = 4; //Max speed of the birds
            neighbourRadius = 100; //Radius used to determine if a bird is a neighbour
            avoidanceRadius = 50; //Radius used to determine if a bird is too close
        }

        ///<summary>
        ///This method is a parameterless constructor that creates the flock and adds the sparrows to the list
        //as well as subscribing them to the events.
        ///</summary>
        public World()
        {
            Flock = new Flock();
            //create sparrow list
            Sparrows = new List<Sparrow>();
            //create sparrows and add them to the list
            for (int i = 0; i < initialCount; i++)
            {
                Sparrow sparrow = new Sparrow();
                Sparrows.Add(sparrow);
                //subscribe the flock
                Flock.Subscribe(sparrow.CalculateBehaviour, sparrow.Move, sparrow.CalculateRavenAvoidance);
            }
            //create a raven and subscribe it to the flock
            Raven = new Raven();

            Flock.Subscribe(Raven.CalculateBehaviour, Raven.Move);
        }
        ///<summary>
        ///This method raises the moe events that move the raven and the sparrow
        ///</summary>
        public void Update()
        {
            Flock.RaiseMoveEvents(this.Sparrows, this.Raven);
        }

    }
}