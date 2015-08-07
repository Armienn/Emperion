using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NeoEmperion.World.Generation;

namespace NeoEmperion.World {
	public class World {
		public Parameters Parameters;
		public Planet Planet;

		public string Status = "Not Started";

		public World() : this(new Parameters(new Random().Next())) { }

		public World(Parameters parameters) {
			Parameters = parameters;
			Planet = new Planet(Parameters); // should this be here?
		}

		public void StartGeneration() {
			Status = "Starting generation";
			Thread.Sleep(1000);
			Status = "Starting asgdf";
			Thread.Sleep(1000);
			Status = "gerg ads";
			Thread.Sleep(1000);
			Eon.GenerateContinents(Planet, Parameters);
			Status = "Finished generation";
		}
	}
}
