using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperion
{
	public class Tools
	{
		public static Vector EnhedE = new Vector(1, 0);
		public static Vector EnhedNE = new Vector((float)0.5, (float)0.86602540378);
		public static Vector EnhedNW = new Vector((float)-0.5, (float)0.86602540378);
		public static Vector EnhedW = new Vector(-1, 0);
		public static Vector EnhedSW = new Vector((float)-0.5, -(float)0.86602540378);
		public static Vector EnhedSE = new Vector((float)0.5, -(float)0.86602540378);

		public static Vector GetUnityVector(Direction dir){
			switch(dir){
				case Direction.EAST:
					return EnhedE;
				case Direction.NORTHEAST:
					return EnhedNE;
				case Direction.NORTHWEST:
					return EnhedNW;
				case Direction.WEST:
					return EnhedW;
				case Direction.SOUTHWEST:
					return EnhedSW;
				case Direction.SOUTHEAST:
					return EnhedSE;
				default:
					return EnhedE;
			}
		}

		public static Direction DirectionFromAngle(double angle) {
			if (angle > Math.PI * (5.0 / 6.0))
				return Direction.WEST;
			if (angle > Math.PI * (3.0 / 6.0))
				return Direction.NORTHWEST;
			if (angle > Math.PI * (1.0 / 6.0))
				return Direction.NORTHEAST;
			if (angle > -Math.PI * (1.0 / 6.0))
				return Direction.EAST;
			if (angle > -Math.PI * (3.0 / 6.0))
				return Direction.SOUTHEAST;
			if (angle > -Math.PI * (5.0 / 6.0))
				return Direction.SOUTHWEST;
			return Direction.WEST;
		}

		public static void NewPosition(Direction dir, ref int x, ref int y) {
			switch (dir) {
				case Direction.WEST:
					x--;
					break;
				case Direction.NORTHWEST:
					y++;
					break;
				case Direction.NORTHEAST:
					x++;
					y++;
					break;
				case Direction.EAST:
					x++;
					break;
				case Direction.SOUTHEAST:
					y--;
					break;
				case Direction.SOUTHWEST:
					x--;
					y--;
					break;
			}
		}

		public static Direction DirectionFromString(String d) {
			switch (d) {
				case "W":
				case "WEST":
					return Direction.WEST;
				case "NW":
				case "NORTHWEST":
					return Direction.NORTHWEST;
				case "NE":
				case "NORTHEAST":
					return Direction.NORTHEAST;
				case "E":
				case "EAST":
					return Direction.EAST;
				case "SE":
				case "SOUTHEAST":
					return Direction.SOUTHEAST;
				case "SW":
				case "SOUTHWEST":
					return Direction.SOUTHWEST;
				default:
					throw new FormatException("No such direction.");
			}
		}

		public static String DirectionToString(Direction d) {
			switch (d) {
				case Direction.WEST:
					return "W";
				case Direction.NORTHWEST:
					return "NW";
				case Direction.NORTHEAST:
					return "NE";
				case Direction.EAST:
					return "E";
				case Direction.SOUTHEAST:
					return "SE";
				case Direction.SOUTHWEST:
					return "SW";
				default:
					throw new FormatException("No such direction.");
			}
		}

		public static Direction DirectionFromNumber(int d) {
			switch (d) {
				case 3:
					return Direction.WEST;
				case 2:
					return Direction.NORTHWEST;
				case 1:
					return Direction.NORTHEAST;
				case 0:
					return Direction.EAST;
				case 5:
					return Direction.SOUTHEAST;
				case 4:
					return Direction.SOUTHWEST;
				default:
					throw new FormatException("No such direction.");
			}
		}

		public static int DirectionToNumber(Direction d) {
			switch (d) {
				case Direction.WEST:
					return 3;
				case Direction.NORTHWEST:
					return 2;
				case Direction.NORTHEAST:
					return 1;
				case Direction.EAST:
					return 0;
				case Direction.SOUTHEAST:
					return 5;
				case Direction.SOUTHWEST:
					return 4;
				default:
					throw new FormatException("No such direction.");
			}
		}

		public static double RhombusFunction(double d, double min, double low, double high, double max) {
			double result = 0;
			if (d < low) {
				result = (d - min) / (low - min);
			}
			else {
				result = (max - d) / (max - high);
			}

			if (result < 0)
				result = 0;
			else if (result > 1)
				result = 1;
			return result;
		}
	}

	#region Other stuff
	public enum Direction { EAST = 0, NORTHEAST = 1, NORTHWEST = 2, WEST = 3, SOUTHWEST = 4, SOUTHEAST = 5 }

	public struct Point
	{
		public int x, y;
		public Point(int x, int y) {
			this.x = x;
			this.y = y;
		}

		public List<Point> GetNeighbours(int maxx, int maxy) {
			List<Point> result = new List<Point>();
			if (x + 1 < maxx)
				result.Add(new Point(x + 1, y));
			if ( (x + 1 < maxx) && (y + 1 < maxy) )
				result.Add(new Point(x + 1, y + 1));
			if (y + 1 < maxy)
				result.Add(new Point(x, y + 1));
			if (x - 1 >= 0)
				result.Add(new Point(x - 1, y));
			if ((x - 1 >= 0) && (y - 1 >= 0))
				result.Add(new Point(x - 1, y - 1));
			if (y - 1 >= 0)
				result.Add(new Point(x, y - 1));
			return result;
		}

		public List<Point> GetPointsInRange(int N, int maxx, int maxy) {
			List<Point> result = new List<Point>();

			for (int a = -N; a <= N; a++) {
				for (int b = a < 0 ? -N : a - N; b <= (a < 0 ? a + N : N); b++) {
					Point p = new Point(x + b, y + a);
					if (p.x >= 0 && p.x < maxx && p.y >= 0 && p.y < maxy) {
						result.Add(p);
					}
				}
			}
			return result;
		}

		public bool IsOnBorder(int maxx, int maxy) {
			if (x == 0 || x + 1 == maxx || y == 0 || y + 1 == maxy)
				return true;
			return false;
		}
	}

	public struct Vector
	{
		public double Angle {
			get {
				double length = Math.Sqrt(x * x + y * y);
				double angle = Math.Acos(x / length);
				if (x == 0)
					angle = Math.PI * 0.5;
				if (x < 0)
					angle = Math.PI - angle;
				if (y < 0)
					angle = -angle;
				return angle;
			}
		}
		public double Magnitude {
			get {
				return Math.Sqrt(x * x + y * y);
			}
		}
		public float x, y;
		public Vector(float x, float y) {
			this.x = x;
			this.y = y;
		}

		public Vector Add(Vector b){
			return new Vector(this.x + b.x, this.y + b.y);
		}

		public Vector Subtract(Vector b) {
			return new Vector(this.x - b.x, this.y - b.y);
		}

		public Vector Multiply(float k){
			return new Vector(this.x*k,this.y*k);
		}

		public Vector Translate(double anglemod, double lengthmod) {
			double length = Math.Sqrt(x * x + y * y);
			double angle = Math.Acos(x/length);
			if (x == 0)
				angle = Math.PI * 0.5;
			if (x < 0)
				angle = Math.PI - angle;
			if (y < 0)
				angle = -angle;
			angle += anglemod;
			while (angle < Math.PI) {
				angle += 2*Math.PI;
			}
			while (angle > Math.PI) {
				angle -= 2*Math.PI;
			}
			return new Vector((float)(length * lengthmod * Math.Cos(angle)), (float)(length * lengthmod * Math.Sin(angle)));
		}
	}

	#endregion
}
