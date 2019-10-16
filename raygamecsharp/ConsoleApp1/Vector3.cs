using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Vector3
    {
        public float x, y, z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
            lhs.x + rhs.x,
            lhs.y + rhs.y,
            lhs.z + rhs.z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
            lhs.x - rhs.x,
            lhs.y - rhs.y,
            lhs.z - rhs.z);
        }

        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(
            lhs.x * rhs,
            lhs.y * rhs,
            lhs.z * rhs);
        }

        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            return rhs * lhs;
        }

        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            return new Vector3(
            lhs.x / rhs,
            lhs.y / rhs,
            lhs.z / rhs);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z);
        }

        public float Distance(Vector3 vec)
        {
            return (float)Math.Sqrt(x * vec.x + y * vec.y + z * vec.z);
        }

        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            z /= m;
        }

        public Vector3 GetNormalised()
        {
            Normalize();
            return new Vector3(x, y, z);
        }

        public float Dot(Vector3 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z;
        }

        public static Vector3 Min(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Min(a.x, b.x), Math.Min(a.y, b.y), Math.Min(a.z, b.z));
        }

        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Max(a.x, b.x), Math.Max(a.y, b.y), Math.Max(a.z, b.z));
        }

        public static Vector3 Clamp(Vector3 t, Vector3 a, Vector3 b)
        {
            return Max(a, Min(a, t));
        }

    }
}
