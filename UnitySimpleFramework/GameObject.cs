using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine {
	public class GameObject  {
		public Transform transform;
		public GameObject() {
			transform = new Transform();
		}

		public T GetComponent<T>() where T : new() {
			return new T();
		}
	}
}
