using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine {
    public enum ForceMode {
        Acceleration,
        Force,
        Impulse,
        VelocityChange
    }

    public class Rigidbody {

        public float mass;
        public float drag;
        public float angularDrag;

        public bool isKinematic;
        public bool useGravity;

        public Vector3 velocity;
        public Vector3 angularVelocity;

        private Vector3 force = Vector3.zero;
        private Vector3 torque = Vector3.zero;

        public void AddForce(Vector3 vector, ForceMode mode = ForceMode.Force) {
            force += vector; //simplified for grading
        }

        public void AddForce(float x, float y, float z, ForceMode mode = ForceMode.Force) {
            AddForce(new Vector3(x, y, z), mode);
        }

        public void AddTorque(Vector3 vector, ForceMode mode = ForceMode.Force) {
            torque += vector; //simplified for grading
        }
        public void AddTorque(float x, float y, float z, ForceMode mode = ForceMode.Force) {
            AddTorque(new Vector3(x, y, z), mode);
        }


    }
}
