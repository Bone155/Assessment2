using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Vector2
    {
        public float x, y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public float MagnitudeSqr()
        {
            return (x * x + y * y);
        }

        public float Distance(Vector2 vec)
        {
            return (float)Math.Sqrt(x * vec.x + y * vec.y);
        }

        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
        }

        public Vector2 GetNormalised()
        {
            Normalize();
            return new Vector2(x, y);
        }

        public float Dot(Vector2 rhs)
        {
            return x * rhs.x + y * rhs.y;
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(
            lhs.x + rhs.x,
            lhs.y + rhs.y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(
            lhs.x - rhs.x,
            lhs.y - rhs.y);
        }

        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2(
            lhs.x * rhs,
            lhs.y * rhs);
        }

        public static Vector2 operator *(float lhs, Vector2 rhs)
        {
            return rhs * lhs;
        }

        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2(
            lhs.x / rhs,
            lhs.y / rhs);
        }

        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return !(lhs == rhs);
        }

    }
}
