using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    public abstract class World
    {
        private Flock flock;
        public List<Sparrow> sparrows
        {
            get;
        }
        public Raven raven
        {
            get;
        }
        public static int InitialCount; //number of sparrows
        public static int Width; //Width of the canvas (“world”)
        public static int Height; //Height of the canvas
        public static int MaxSpeed; //Max speed of the birds
        public static int NeighbourRadius; //Radius used to determine if a bird is a neighbour
        public static int AvoidanceRadius; //Radius used to determine if a bird is too close

        static World()
        {
            InitialCount = 150; //number of sparrows
            Width = 1000; //Width of the canvas (“world”)
            Height = 500; //Height of the canvas
            MaxSpeed = 4; //Max speed of the birds
            NeighbourRadius = 100; //Radius used to determine if a bird is a neighbour
            AvoidanceRadius = 50; //Radius used to determine if a bird is too close
        }

        ///<summary>
        ///This method is a parameterless constructor that creates the flock and adds the sparrows to the list
        //as well as subscribing them to the events.
        ///</summary>
        public World()
        {
            flock = new Flock();
            //create sparrow list
            sparrows = new List<Sparrow>();
            //create sparrows and add them to the list
            for (int i = 0; i < InitialCount; i++)
            {
                Sparrow sparrow = new Sparrow();
                sparrows.Add(sparrow);
                //subscribe the flock
                flock.Subscribe(sparrow.CalculateBehaviour, sparrow.Move, sparrow.CalculateRavenAvoidance);
            }
            //create a raven and subscribe it to the flock
            raven = new Raven();
            flock.Subscribe(raven.CalculateBehaviour, raven.Move);
        }
        ///<summary>
        ///This method raises the moe events that move the raven and the sparrow
        ///</summary>
        public void Update()
        {
            flock.RaiseMoveEvents(this.sparrows, this.raven);
        }

    }
}