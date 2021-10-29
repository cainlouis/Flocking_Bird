using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    ///<summary>
    ///This class is used to represent a single raven. 
    ///This class is just a starting point. Complete the TODO sections
    ///</summary>
    public class Raven
    {
        //TODO: Add the constructor, properties and fields as specified in the instructions document.

        ///<value> Property <c>Rotation</c> to rotate the raven to face the direction it is moving toward.</value>
        public float Rotation
        {
            get 
            {
                return (float)Math.Atan2(this.velocity.Y, this.velocity.X); 
            }
        }

        ///<summary>
        ///This method is an event handler that updates the velocity and position of a raven.
        ///</summary>
        public void Move()
        {
            //TODO: 
        }
        ///<summary>
        ///This method is an event handler to calculate and set amountToSteer vector
        ///</summary>
        ///<param name="sparrows">List of sparrows</param>
        public void CalculateBehaviour(List<Sparrow> sparrows) 
        {
            //TODO: Set the amountToSteer vector with the vector returned by the ChaseSparrow.
        }

        //TODO: Code the following private helper methods to implement chase sparrows.
        //The method header are declared below:
        private Vector2 ChaseSparrow (List<Sparrow> sparrows);
        
       
       ///<summary>
        ///This method is a private helper method to make sparrows reappear on the opposite edge if they go outside the bounds of the screen
        ///</summary>
       private void AppearOnOppositeSide()
       {
           if (this.Position.X > World.Width)
            {
                this.Position = new Vector2(0, this.Position.Y);
            }
            else if(this.Position.X < 0)
            {
                 this.Position = new Vector2(World.Width, this.Position.Y);
            }
            if (this.Position.Y > World.Height)
            {
                this.Position = new Vector2(this.Position.X, 0);
            }
            else if(this.position.Y < 0)
            {
                this.Position= new Vector2(this.Position.X, World.Height);
            }
       }
    }
}