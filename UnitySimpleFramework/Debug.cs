using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine {
    public class Debug {
        private static int hour = 8;
        private static int minute = 17;
        private static int second = 39;

        public static void SetTime(int hour, int minute, int second) {
            Debug.hour = hour;
            Debug.minute = minute;
            Debug.second = second;
        }

        public static void Log(object message) {
            StringBuilder sb = new StringBuilder();
            string leadzero = "0#";
            sb.Append("[");
            sb.Append(Debug.hour.ToString(leadzero));
            sb.Append(":");
            sb.Append(Debug.minute.ToString(leadzero));
            sb.Append(":");
            sb.Append(Debug.second.ToString(leadzero));
            sb.Append("] ");
            sb.AppendLine(message.ToString());
            sb.AppendLine("UnityEngine.Debug:Log (object)");
            Console.WriteLine(sb.ToString());
            Debug.SetTime(hour, minute, second + 1);
        }
    }
}
