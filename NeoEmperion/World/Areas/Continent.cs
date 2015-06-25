using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeaKit.Geometry2D.Hex;

namespace NeoEmperion.World.Areas {
	public struct Continent {
		public HexPoint Position;

		public Continent(int x, int y) {
			Position = new HexPoint(x, y);
		}
	}
}
