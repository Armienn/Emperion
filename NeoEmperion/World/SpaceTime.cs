using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoEmperion.World.Generation;

namespace NeoEmperion.World {
	public class SpaceTime {
		public Parameters Parameters;
		//public Random random;
		public World world;

		public SpaceTime(int x, int y, int z) : this(x, y, z, new Random().Next()) { }

		public SpaceTime(int x, int y, int z, int seed) {
			Random random = new Random(seed);
			Parameters.Continents = 8;
			Parameters.EonSeed = random.Next();
			Parameters.X = x;
			Parameters.Y = y;
			Parameters.Z = z;
			world = new World(x, y, z);
			//generere verden
			Eon.GenerateContinents(world, Parameters);
		}
	}
}
