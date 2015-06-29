using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoEmperion.World.Areas;

namespace NeoEmperion.World.Generation {
	static class Eon {
		public static void GenerateContinents(Planet planet, Parameters parameters){
			Random random = new Random(parameters.EonSeed);
			for (int i = 0; i < parameters.Continents; i++) {
				planet.Continents[i] = new Continent(random.Next(parameters.X), random.Next(parameters.Y));
			}
		}
	}
}
