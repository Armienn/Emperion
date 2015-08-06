using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoEmperion.World.Generation;

namespace NeoEmperion.World {
	public class World {
		public Parameters Parameters;
		public Planet planet;

		public World() : this(new Parameters(new Random().Next())) { }

		public World(Parameters parameters) {
			Parameters = parameters;
			planet = new Planet(Parameters); // should this be here?
		}

		public void StartGeneration() {
			Eon.GenerateContinents(planet, Parameters);
		}
	}
}
