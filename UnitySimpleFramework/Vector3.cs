using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEngine {
	public class Vector3 {
		public const float kEpsilon = 0.00001F;
		public const float kEpsilonNormalSqrt = 1e-15F;
		public float x, y, z;
		public Vector3() {
			x = 0;
			y = 0;
			z = 0;
		}
		public Vector3(float x, float y, float z) {
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public static Vector3 Lerp(Vector3 a, Vector3 b, float t) {
			t = Math.Min(t, 1);
			t = Math.Max(t, 0);
			return new Vector3(
				a.x + (b.x - a.x) * t,
				a.y + (b.y - a.y) * t,
				a.z + (b.z - a.z) * t
			);
		}
		public static Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta) {
			// avoid vector ops because current scripting backends are terrible at inlining
			float toVector_x = target.x - current.x;
			float toVector_y = target.y - current.y;
			float toVector_z = target.z - current.z;

			float sqdist = toVector_x * toVector_x + toVector_y * toVector_y + toVector_z * toVector_z;

			if(sqdist == 0 || (maxDistanceDelta >= 0 && sqdist <= maxDistanceDelta * maxDistanceDelta))
				return target;
			var dist = (float)Math.Sqrt(sqdist);

			return new Vector3(current.x + toVector_x / dist * maxDistanceDelta,
				current.y + toVector_y / dist * maxDistanceDelta,
				current.z + toVector_z / dist * maxDistanceDelta);
		}
		public override int GetHashCode() {
			return x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2);
		}
		public override bool Equals(object other) {
			if(!(other is Vector3))
				return false;

			return Equals((Vector3)other);
		}
		public bool Equals(Vector3 other) {
			return x == other.x && y == other.y && z == other.z;
		}
		public void Normalize() {
			float mag = Magnitude(this);
			if(mag > kEpsilon) {
				x /= mag;
				y /= mag;
				z /= mag;
			} else {
				x = y = z = 0;
			}
		}

		public static float Dot(Vector3 lhs, Vector3 rhs) {
			return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
		}

		public static float Distance(Vector3 a, Vector3 b) {
			float diff_x = a.x - b.x;
			float diff_y = a.y - b.y;
			float diff_z = a.z - b.z;
			return (float)Math.Sqrt(diff_x * diff_x + diff_y * diff_y + diff_z * diff_z);
		}

		public static float Angle(Vector3 from, Vector3 to) {
			// sqrt(a) * sqrt(b) = sqrt(a * b) -- valid for real numbers
			float denominator = (float)Math.Sqrt(from.sqrMagnitude * to.sqrMagnitude);
			if(denominator < kEpsilonNormalSqrt)
				return 0F;

			float dot = Mathf.Clamp(Dot(from, to) / denominator, -1, 1);
			return ((float)Math.Acos(dot)) * Mathf.Rad2Deg;
		}

		public float magnitude {
			get {
				return (float)Math.Sqrt(x * x + y * y + z * z);
			}
		}
		public static float Magnitude(Vector3 vector) {
			return (float)Math.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
		}

		public float sqrMagnitude {
			get {
				return x * x + y * y + z * z;
			}
		}
		public static float SqrMagnitude(Vector3 vector) {
			return vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
		}

		static readonly Vector3 zeroVector = new Vector3(0F, 0F, 0F);
		static readonly Vector3 oneVector = new Vector3(1F, 1F, 1F);
		static readonly Vector3 upVector = new Vector3(0F, 1F, 0F);
		static readonly Vector3 downVector = new Vector3(0F, -1F, 0F);
		static readonly Vector3 leftVector = new Vector3(-1F, 0F, 0F);
		static readonly Vector3 rightVector = new Vector3(1F, 0F, 0F);
		static readonly Vector3 forwardVector = new Vector3(0F, 0F, 1F);
		static readonly Vector3 backVector = new Vector3(0F, 0F, -1F);
		public static Vector3 zero {
			get {
				return zeroVector;
			}
		}
		// Shorthand for writing @@Vector3(1, 1, 1)@@
		public static Vector3 one {
			get {
				return oneVector;
			}
		}
		// Shorthand for writing @@Vector3(0, 0, 1)@@
		public static Vector3 forward {
			get {
				return forwardVector;
			}
		}
		public static Vector3 back {
			get {
				return backVector;
			}
		}
		// Shorthand for writing @@Vector3(0, 1, 0)@@
		public static Vector3 up {
			get {
				return upVector;
			}
		}
		public static Vector3 down {
			get {
				return downVector;
			}
		}
		public static Vector3 left {
			get {
				return leftVector;
			}
		}
		// Shorthand for writing @@Vector3(1, 0, 0)@@
		public static Vector3 right {
			get {
				return rightVector;
			}
		}

		// Adds two vectors.
		public static Vector3 operator +(Vector3 a, Vector3 b) {
			return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
		}
		// Subtracts one vector from another.
		public static Vector3 operator -(Vector3 a, Vector3 b) {
			return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
		}
		// Negates a vector.
		public static Vector3 operator -(Vector3 a) {
			return new Vector3(-a.x, -a.y, -a.z);
		}
		// Multiplies a vector by a number.
		public static Vector3 operator *(Vector3 a, float d) {
			return new Vector3(a.x * d, a.y * d, a.z * d);
		}
		// Multiplies a vector by a number.
		public static Vector3 operator *(float d, Vector3 a) {
			return new Vector3(a.x * d, a.y * d, a.z * d);
		}
		// Divides a vector by a number.
		public static Vector3 operator /(Vector3 a, float d) {
			return new Vector3(a.x / d, a.y / d, a.z / d);
		}

		public static bool operator ==(Vector3 lhs, Vector3 rhs) {
			// Returns false in the presence of NaN values.
			float diff_x = lhs.x - rhs.x;
			float diff_y = lhs.y - rhs.y;
			float diff_z = lhs.z - rhs.z;
			float sqrmag = diff_x * diff_x + diff_y * diff_y + diff_z * diff_z;
			return sqrmag < kEpsilon * kEpsilon;
		}
		public static bool operator !=(Vector3 lhs, Vector3 rhs) {
			// Returns true in the presence of NaN values.
			return !(lhs == rhs);
		}

		public override string ToString() {
			return String.Format("({0}, {1}, {2})", x, y, z);
		}
	}
}
