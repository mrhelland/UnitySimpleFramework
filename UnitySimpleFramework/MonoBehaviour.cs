using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine {
    public interface MonoBehaviour {
        void Start();
        void Update();
        void FixedUpdate();
        void OnTriggerEnter(Collider collider);
    }

    public class Collider {
        
    }
}
