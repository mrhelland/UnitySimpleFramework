using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine {

    public enum KeyCode {
        W,
        A,
        S,
        D,
        Enter,
        LeftShift,
        LeftControl,
        Left,
        Right,
        Up,
        Down,
        Tab,
        LeftAlt
    }

    public class Input {
        public enum KeyStates {
            Down = -1,
            Up = 1,
            None = 0
        }
        private static Vector3 mousePosition;
        private static KeyStates[] keyStates = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

        public bool GetKeyUp(KeyCode key) {
            return keyStates[(int)key] == KeyStates.Up;
        }
        
        public bool GetKeyDown(KeyCode key) {
            return keyStates[(int)key] == KeyStates.Down;
        }


        public static void GraderSetKeys(KeyCode key, KeyStates state) {
            keyStates[(int)key] = state;
        }

        public static void GraderSetMouse(Vector3 position) {
            mousePosition = position;
        }


    }
}
