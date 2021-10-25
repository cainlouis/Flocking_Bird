using System;

namespace FlockingBackend
{
    public struct Vector2
    {
        public float Vx { get; }

        public float Vy { get; }

        public Vector2(float vx, float vy)
        {
            this.Vx = vx;
            this.Vy = vy;
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.Vx - b.Vx, a.Vy - b.Vy);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.Vx + b.Vx, a.Vy + b.Vy);
        }

        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a.Vx / b, a.Vy / b);
        }

        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.Vx * b, a.Vy * b);
        }

        public static float DistanceSquared(Vector2 a, Vector2 b)
        {
            return (float)(Math.Pow(a.Vx - b.Vx, 2) + Math.Pow(a.Vy - b.Vy, 2));
        }

        public static Vector2 Normalize(Vector2 a)
        {
            float norm = (float)Math.Sqrt(Math.Pow(a.Vx, 2) + Math.Pow(a.Vy, 2));
            return new Vector2(a.Vx / norm, a.Vy / norm);
        }
    }
}