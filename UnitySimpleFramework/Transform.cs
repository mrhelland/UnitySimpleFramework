using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine {

	public class Transform {
		public Vector3 position;
		public Quaternion rotation;
		public Vector3 scale;
		public Transform() {
			position = new Vector3();
			rotation = new Quaternion();
			scale = new Vector3();
		}
	}

}
