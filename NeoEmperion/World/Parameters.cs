using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoEmperion.World {
	public struct Parameters {
		public int EonSeed = 0;
		public int X = 100;
		public int Y = 100;
		public int Z = 30;
		public int Continents = 8;

		public Parameters();

		public Parameters(int seed) {
			Random random = new Random(seed);
			EonSeed = random.Next();
		}
	}
}
