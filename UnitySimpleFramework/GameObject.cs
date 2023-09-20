using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine {
	public class GameObject  {
		public Transform transform;

		public string tag;
		public bool active;


		public void SetActive(bool state) {
			active = state;
		}

		public GameObject() {
			transform = new Transform();
			tag = null;
			active = true;
		}

		public T GetComponent<T>() where T : new() {
			
			return new T();
		}

		public T[] GetComponents<T>() where T : new() {
			return new T[4];
		}

		public static GameObject FindWithTag(string tag) {
			return new GameObject();
		}

		public static GameObject Instantiate(GameObject prefab) {
			return new GameObject();
		}

		public static GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation) {
			GameObject g = new GameObject();
			g.transform.position = position;
			g.transform.rotation = rotation;
			return g;
		}


	}
}
