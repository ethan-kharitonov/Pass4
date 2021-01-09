using System;
using System.Collections.Generic;
using System.Text;

namespace Pass4
{
    static class Helper
    {
        private static Random rng = new Random();

        public static int RandomInt(int min, int max) => rng.Next(min, max + 1);

        public static int Clamp(int value, int min, int max)
        {
            return Math.Min(max, Math.Max(min, value));
        }

        public static float Clamp(float value, float min, float max)
        {
            return Math.Min(max, Math.Max(min, value));
        }

        public static float GetRandomNum(float min, float max)
        {
            return (float)(rng.NextDouble() * (max - min)) + min;
        }

        public static bool IsBetween(int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        private static float MoveTowards(float value, float target, float speed)
        {
            if (Math.Abs(target - value) <= speed)
            {
                return target;
            }

            return value + Math.Sign(target - value) * speed;
        }
    }
}
