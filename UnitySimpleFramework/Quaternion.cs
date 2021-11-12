using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine {

	public class Quaternion {
		public float x, y, z, w;

		public Quaternion() {
			x = y = z = 0;
			w = 1;
		}

		public Quaternion(float x, float y, float z, float w) {
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		private static readonly Quaternion identityQuaternion = new Quaternion(0F, 0F, 0F, 1F);
		public static Quaternion identity {
			get {
				return identityQuaternion;
			}
		}

		public const float kEpsilon = 0.000001F;
		private static bool IsEqualUsingDot(float dot) {
			// Returns false in the presence of NaN values.
			return dot > 1.0f - kEpsilon;
		}

		public static float Dot(Quaternion a, Quaternion b) {
			return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
		}

		public static bool operator ==(Quaternion lhs, Quaternion rhs) {
			return IsEqualUsingDot(Dot(lhs, rhs));
		}

		public static bool operator !=(Quaternion lhs, Quaternion rhs) {
			// Returns true in the presence of NaN values.
			return !(lhs == rhs);
		}
		public override int GetHashCode() {
			return x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2) ^ (w.GetHashCode() >> 1);
		}
		public override bool Equals(object other) {
			if(!(other is Quaternion))
				return false;

			return Equals((Quaternion)other);
		}
		public bool Equals(Quaternion other) {
			return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z) && w.Equals(other.w);
		}
		public override string ToString() {
			return String.Format("({0}, {1}, {2}, {3})", x, y, z, w);
		}


	}
}
