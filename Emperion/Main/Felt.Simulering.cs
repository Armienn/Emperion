using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperion
{
	partial class Felt
	{
		public void AddLayer(Lag lag) {
			this.lag.Add(lag.Kopier());
		}

		public void AddLayer(String type, Lag l) {
			AddLayer(type);
			switch (type) {
				case "bund":
				case "vulkanbred":
				case "vulkansmal":
					lag[0].Tilføj(l);
					lag[0].UdJord(0.5);
					break;
				case "top":
				case "dalfyld":
				case "vandhulfyld":
					lag[Højde - 1].Tilføj(l);
					lag[Højde - 1].UdJord(0.5);
					break;
			}
		}

		public void AddLayer(String type) {
			double modheavy = (Højde - 1) * 0.2 + 1;
			double modlight = (Højde - 1) * 0.1 + 1;
			switch (type) {
				case "bund":
					lag.Insert(0, new Lag(
						Sten.Granit,
						0.0001 * modheavy,	//guld
						0.001 * modheavy,	//sølv
						4 * modlight,	//jern
						2 * modlight,	//kobber
						1 * modheavy,	//bly
						2 * modlight,	//tin
						0,	//diamant
						0,	//rubin
						0,	//safir
						0	//smaragd
						));
					break;
				case "vulkanbred":
					lag.Insert(0, new Lag(
						Sten.Granit,
						0.0001 * modheavy,	//guld
						0.001 * modheavy,	//sølv
						4 * modlight,	//jern
						2 * modlight,	//kobber
						1 * modheavy,	//bly
						2 * modlight,	//tin
						0,	//diamant
						0,	//rubin
						0,	//safir
						0	//smaragd
						));
					break;
				case "vulkansmal":
					lag.Insert(0, new Lag(
						Sten.Granit,
						0.0001 * modheavy,	//guld
						0.001 * modheavy,	//sølv
						4 * modlight,	//jern
						2 * modlight,	//kobber
						1 * modheavy,	//bly
						2 * modlight,	//tin
						0.001,	//diamant
						0,	//rubin
						0,	//safir
						0	//smaragd
						));
					break;
				case "top":
					lag.Add(new Lag(
						Sten.Granit,
						0.0001,	//guld
						0.001,	//sølv
						2,	//jern
						1,	//kobber
						1,	//bly
						1,	//tin
						0,	//diamant
						0,	//rubin
						0,	//safir
						0	//smaragd
						));
					break;
				case "dalfyld":
					lag.Add(new Lag(
						Sten.Granit,
						0.0001,	//guld
						0.001,	//sølv
						50,	//jern
						1,	//kobber
						1,	//bly
						1,	//tin
						0,	//diamant
						0,	//rubin
						0,	//safir
						0	//smaragd
						));
					break;
				case "vandhulfyld":
					lag.Add(new Lag(
						Sten.Granit,
						0.0001,	//guld
						0.001,	//sølv
						10,	//jern
						1,	//kobber
						1,	//bly
						1,	//tin
						0,	//diamant
						0,	//rubin
						0,	//safir
						0	//smaragd
						));
					break;
			}


			Vandhøjde--;
		}

		public void RemoveLayer(String sted) {
			if (Højde > 1) {
				switch (sted) {
					case "bund":
						lag.RemoveAt(Højde - 1);
						break;
					case "midt":
						lag.RemoveAt(Højde / 2);
						break;
					case "top":
						lag.RemoveAt(0);
						break;
				}
			}
		}


	}
}
