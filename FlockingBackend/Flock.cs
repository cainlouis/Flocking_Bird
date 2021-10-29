using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    ///<summary>
    ///This class is the subscriber class that each bird subscribes to. The class also raises the events to calculate movement vector and move the birds.
    ///This class is just a starting point. Complete the TODO sections
    ///</summary>
    public class Flock
    {
        //TODO: Add the events. See instructions for details

        //TODO: Add a Subscribe method that takes as input a CalculateMoveVector delegate instance, 
        //a MoveBird delegate instance and an optional CalculateRavenAvoidance delegate instance and
        // subscribes them to the corresponding events

        ///<summary>
        ///This method raises the calculate and move events
        ///</summary>
        ///<param name="sparrows">List of Sparrow objects</param>
        ///<param name="raven">A Raven object</param>
        public void RaiseMoveEvents(List<Sparrow> sparrows, Raven raven)
        {
            //TODO
        }

        
    }
}