using System;

namespace FlockingBackend
{
    /// <summary>
    /// A structure containing two points for the vector and a method for all
    /// the operation that can be done to it.
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        /// Property representing the position of the vector on the x axis
        /// only return the value
        /// </summary>
        public float Vx { get; }

        /// <summary>
        /// Property representing the position of the vector on the y axis
        /// only return the value
        /// </summary>
        public float Vy { get; }

        /// <summary>
        /// Parameterized constructor, set the Vx and the Vy properties to the 
        /// values received as inputs
        /// </summary>
        /// <param name="vx">Scalar (Float) number received as input, is set as Vx</param>
        /// <param name="vy">Scalar (Float) number received as input, is set as Vy</param>
        public Vector2(float vx, float vy)
        {
            this.Vx = vx;
            this.Vy = vy;
        }

        /// <summary>
        /// Overload the - operator to create a new vector by substracting each of the
        /// properties of the first vector by the second's same property
        /// </summary>
        /// <param name="a">The first vector object</param>
        /// <param name="b">The second vector object</param>
        /// <returns>The result of the operation done, a new vector</returns>
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.Vx - b.Vx, a.Vy - b.Vy);
        }

        /// <summary>
        /// Overload the + operator to create a new vector by adding each of the
        /// properties of the first vector by the second's same property
        /// </summary>
        /// <param name="a">First vector object</param>
        /// <param name="b">Second vector object</param>
        /// <returns>The result of the operation done, a new vector</returns>
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.Vx + b.Vx, a.Vy + b.Vy);
        }

        /// <summary>
        /// Overload the / operator to create a new vector by dividing each of the 
        /// properties of the vector we get as input by the float parameter we get
        /// as input.
        /// </summary>
        /// <param name="a">A vector object</param>
        /// <param name="b">A scalar (float) number</param>
        /// <returns>The result of the operation done, a new vector</returns>
        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a.Vx / b, a.Vy / b);
        }

        /// <summary>
        /// Overload the * operator to create a new vector by multiplying each of the 
        /// properties of the vector we get as input by the float parameter we get
        /// as input.
        /// </summary>
        /// <param name="a">A vector object</param>
        /// <param name="b">A scalar (float) number</param>
        /// <returns>The result of the operation done, a new vector</returns>
        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.Vx * b, a.Vy * b);
        }

        /// <summary>
        /// Calculate the distance between each properties of both vectors and add the 
        /// squared result of each substraction together.
        /// </summary>
        /// <param name="a">The first vector object</param>
        /// <param name="b">The second vector object</param>
        /// <returns>The squared product of the distance between the 2 vectors</returns>
        public static float DistanceSquared(Vector2 a, Vector2 b)
        {
            return (float)(Math.Pow(a.Vx - b.Vx, 2) + Math.Pow(a.Vy - b.Vy, 2));
        }

        /// <summary>
        /// Calculate the normalized vector created by the division of the vector we
        /// get as input by the norm of that same vector
        /// </summary>
        /// <param name="a">The vector we are calculating</param>
        /// <returns>A vector created by the division of its properties by the norm of the
        /// vector we get as input</returns>
        public static Vector2 Normalize(Vector2 a)
        {
            float norm = (float)Math.Sqrt(Math.Pow(a.Vx, 2) + Math.Pow(a.Vy, 2));
            return new Vector2(a.Vx / norm, a.Vy / norm);
        }
    }
}