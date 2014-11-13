using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperion
{
	class Mænd : Væsner
	{
		static double kapacitet = 20;
		static double kød = 5;
		static double madBehov = 10;
		static double vandBehov = 10;
		static bool spiserKød = true;
		static bool spiserFrugt = true;
		static bool spiserGræs = false;
		static bool spiserTilberedt = true;

		#region Fyld
		public override double Kapacitet {
			get {
				return kapacitet * Antal;
			}
		}
		public override double Kød {
			get {
				return kød * Antal;
			}
		}
		public override double MadBehov {
			get {
				return madBehov * Antal;
			}
		}
		public override double VandBehov {
			get {
				return vandBehov * Antal;
			}
		}
		public override bool SpiserKød {
			get {
				return spiserKød;
			}
		}
		public override bool SpiserFrugt {
			get {
				return spiserFrugt;
			}
		}
		public override bool SpiserGræs {
			get {
				return spiserGræs;
			}
		}
		public override bool SpiserTilberedt {
			get {
				return spiserTilberedt;
			}
		}
		#endregion

		public Mænd(int antal) {
			Antal = antal;
		}
	}
}
