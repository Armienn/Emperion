﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoEmperion.World.Areas;

namespace NeoEmperion.World {
	public class Planet {
		public Area[, ,] Map;
		public Continent[] Continents;

		public int X { get { return Map.GetLength(0); } }
		public int Y { get { return Map.GetLength(1); } }
		public int Z { get { return Map.GetLength(2); } }

		public Planet(Parameters parameters) {
			Map = new Area[parameters.X, parameters.Y, parameters.Z];
		}
	}
}
