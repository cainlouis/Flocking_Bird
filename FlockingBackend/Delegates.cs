using System;
using System.Collections.Generic;

namespace FlockingBackend 
{
    public class Delegates
    {
        public delegate void CalculateMoveVector(List<Sparrow> sparrows);

        public delegate void MoveBird();

        public delegate void CalculateRavenAvoidance(Raven raven);
    }
}