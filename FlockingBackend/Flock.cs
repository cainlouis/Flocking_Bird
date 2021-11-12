using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    class Flock
    {
        //Creating all the delegate type events
        public event Delegates.CalculateMoveVector CalcMovementEvent;
        public event Delegates.CalculateRavenAvoidance CalcRavenFleeEvent;
        public event Delegates.MoveBird MoveEvent;

       ///<summary>
       ///This method subscribes the methods to the events.
       ///</summary>
       ///<param name="moveVector">Method that changes the behavioir</param>
       ///<param name="moveBird">Method that moves bird</param>
       ///<param name="ravenAvoidance">Method that makes the sparrow avoid the raven</param>
        public void Subscribe(Delegates.CalculateMoveVector moveVector ,Delegates.MoveBird moveBird,Delegates.CalculateRavenAvoidance ravenAvoidance = null){
            //adding the movement methods to the events
            CalcMovementEvent += moveVector;
            CalcRavenFleeEvent += ravenAvoidance;
            MoveEvent += moveBird;
        }

        public void RaiseMoveEvents(List<Sparrow> sparrows, Raven raven){
            //invoking the events
            CalcMovementEvent?.Invoke(sparrows);
            MoveEvent?.Invoke();
            CalcRavenFleeEvent?.Invoke(raven);
        }
    }
}