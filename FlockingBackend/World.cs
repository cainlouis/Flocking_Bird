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
        public static int InitialCount{
            get;
        } //number of sparrows
        public static int Width{
            get;
        } //Width of the canvas (“world”)
        public static int Height{
            get;
        } //Height of the canvas
        public static int MaxSpeed{
            get;
        } //Max speed of the birds
        public static int NeighbourRadius{
            get;
        } //Radius used to determine if a bird is a neighbour
        public static int AvoidanceRadius{
            get;
        } //Radius used to determine if a bird is too close

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
            Flock = new Flock();
            //create sparrow list
            Sparrows = new List<Sparrow>();
            //create sparrows and add them to the list
            for (int i = 0; i < InitialCount; i++)
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