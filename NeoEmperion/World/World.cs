using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoEmperion.World.Generation;

namespace NeoEmperion.World {
	public class World {
		public Parameters Parameters;
		//public Random random;
		public Planet planet;

		public World(int x, int y, int z) : this(x, y, z, new Random().Next()) { }

		public World(int x, int y, int z, int seed) {
			Random random = new Random(seed);
			Parameters.Continents = 8;
			Parameters.EonSeed = random.Next();
			Parameters.X = x;
			Parameters.Y = y;
			Parameters.Z = z;
			planet = new Planet(x, y, z);
			//generere verden
			Eon.GenerateContinents(planet, Parameters);
		}
	}
}
