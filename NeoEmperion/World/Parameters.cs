using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoEmperion.World {
	public struct Parameters {
		public int EonSeed;
		public int X;
		public int Y;
		public int Z;
		public int Continents;

		public Parameters(int seed = 0) {
			Random random = new Random(seed);
			EonSeed = random.Next();
			X = 100;
			Y = 100;
			Z = 30;
			Continents = 8;
		}
	}
}
