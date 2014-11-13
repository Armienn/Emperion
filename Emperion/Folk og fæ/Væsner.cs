using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperion
{
	/// <summary>
	/// Base klasse for alskens væsner. Alt fra Mænd til Køer arver herfra. Her i 
	/// bliver deklareret skrevet alle de ting vi har brug for at vide om levende
	/// væsner, f.eks. deres madbehov, deres bærekapacitet, deres antal, osv.
	/// </summary>
	abstract class Væsner
	{
		protected int antal;
		public int Antal {
			get {
				return antal;
			}
			set {
				if (value < 0) {
					antal = 0;
				}
				else {
					antal = value;
				}
			}
		}
		public abstract double Kapacitet{
			get;
		}
		public abstract double Kød {
			get;
		}
		public abstract double MadBehov {
			get;
		}
		public abstract double VandBehov {
			get;
		}
		public abstract bool SpiserKød {
			get;
		}
		public abstract bool SpiserFrugt {
			get;
		}
		public abstract bool SpiserGræs {
			get;
		}
		public abstract bool SpiserTilberedt {
			get;
		}
	}

	class Børn : Væsner
	{
		static double kapacitet = 3;
		static double kød = 2;
		static double madBehov = 5;
		static double vandBehov = 5;
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

		public Børn(int antal) {
			Antal = antal;
		}
	}

	class Gamle : Væsner
	{
		static double kapacitet = 16;
		static double kød = 5;
		static double madBehov = 8;
		static double vandBehov = 8;
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

		public Gamle(int antal) {
			Antal = antal;
		}
	}

	class Heste : Væsner
	{
		static double kapacitet = 100;
		static double kød = 30;
		static double madBehov = 10;
		static double vandBehov = 10;
		static bool spiserKød = false;
		static bool spiserFrugt = true;
		static bool spiserGræs = true;
		static bool spiserTilberedt = false;

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

		public Heste(int antal) {
			Antal = antal;
		}
	}

	class Køer : Væsner
	{
		static double kapacitet = 100;
		static double kød = 50;
		static double madBehov = 10;
		static double vandBehov = 10;
		static bool spiserKød = false;
		static bool spiserFrugt = true;
		static bool spiserGræs = true;
		static bool spiserTilberedt = false;

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

		public Køer(int antal) {
			Antal = antal;
		}
	}

	class Grise : Væsner
	{
		static double kapacitet = 2;
		static double kød = 20;
		static double madBehov = 10;
		static double vandBehov = 10;
		static bool spiserKød = false;
		static bool spiserFrugt = true;
		static bool spiserGræs = true;
		static bool spiserTilberedt = false;

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

		public Grise(int antal) {
			Antal = antal;
		}
	}
}
