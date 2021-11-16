using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    public abstract class Bird
    {

        //Position property to get and set the position of the bird
        public Vector2 Position
        {
            get;
            protected set;
        }

        //Velocity property to get and set the position of the bird
        public Vector2 Velocity
        {
            get;
            protected set;
        }
        //AmountToSteer variable used to make the birds follow other birds
        protected Vector2 amountToSteer;

        //Bird constructor that puts the bird in a random positon and gives it a random velocity.
        //Also sets amount to steer to 0
        public Bird()
        {
            Random rnd = new Random();
            int Px = rnd.Next(0, World.Width);
            int Py = rnd.Next(0, World.Height);
            Position = new Vector2(Px, Py);
            int VelX = rnd.Next(0, 9) - 4;
            int VelY = rnd.Next(0, 9) - 4;
            Velocity = new Vector2(VelX, VelY);
            amountToSteer = new Vector2(0, 0);
        }

        //another bird constructor used for testing purposes
        public Bird(float P1, float P2, float V1, float V2)
        {
            Position = new Vector2(P1, P2);
            Velocity = new Vector2(V1, V2);
            amountToSteer = new Vector2(0, 0);
        }

        ///<value> Property <c>Rotation</c> to rotate the raven to face the direction it is moving toward.</value>
        public float Rotation
        {
            get
            {
                return (float)Math.Atan2(this.Velocity.Vy, this.Velocity.Vx);
            }
        }

         
        protected void AppearOnOppositeSide()
        {
            if (this.Position.Vx > World.Width)
            {
                this.Position = new Vector2(0, this.Position.Vy);
            }
            else if (this.Position.Vx < 0)
            {
                this.Position = new Vector2(World.Width, this.Position.Vy);
            }
            if (this.Position.Vy > World.Height)
            {
                this.Position = new Vector2(this.Position.Vx, 0);
            }
            else if (this.Position.Vy < 0)
            {
                this.Position = new Vector2(this.Position.Vx, World.Height);
            }
        }

        public abstract void CalculateBehaviour(List<Sparrow> Sparrows);

        ///<summary>
        ///This method is a public helper method to takes care of the behavior of the birds
        ///</summary>
        public virtual void Move()
        {
            //Update velocity by adding amount to steer to it
            Velocity = Velocity + amountToSteer;
            //Updating the position of the bird
            Position = Position + Velocity;
            this.AppearOnOppositeSide();
        }
    }
}