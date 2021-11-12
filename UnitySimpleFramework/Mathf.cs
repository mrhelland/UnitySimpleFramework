using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine {
    public class Mathf {

        public const float Infinity = Single.PositiveInfinity;
        public const float NegativeInfinity = Single.NegativeInfinity;
        public const float PI = (float)Math.PI;
        public const float Deg2Rad = PI * 2F / 360F;
        public const float Rad2Deg = 1F / Deg2Rad;

        public static float Clamp(float value, float min, float max) {
            if(value < min)
                value = min;
            else if(value > max)
                value = max;
            return value;
        }

        public static float Clamp01(float value) {
            if(value < 0F)
                return 0F;
            else if(value > 1F)
                return 1F;
            else
                return value;
        }
    }
}
