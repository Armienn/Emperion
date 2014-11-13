using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperion
{
	public partial class Felt
	{
		Verden world;
		public readonly int x, y;
		public Vector vind = new Vector(0, 0);
		
		#region Properties
		/// <summary>
		/// Returnerer laget i den givne dybde (nul er i toppen)
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public Lag this[int index] {
			get {
				if (index < 0 || index >= Højde) {
					throw new IndexOutOfRangeException();
				}
				return lag[Højde - 1 - index];
			}
		}
		public int Højde {
			get {
				return lag.Count;
			}
		}

		public double Temperatur {
			get { return temperatur; }
			set {
				if (value < -50)
					temperatur = -50;
				else if (value > 50)
					temperatur = 50;
				else
					temperatur = value;
			}
		}
		public double Skyer {
			get { return skyer; }
			set {
				if (value < 0)
					skyer = 0;
				else
					skyer = value;
			}
		}
		public double Fugtighed {
			get { return fugtighed; }
			set {
				if (value < 0)
					fugtighed = 0;
				else
					fugtighed = value;
			}
		}
		public int Regn {
			get { return regn; }
			set {
				if (value < 0)
					regn = 0;
				else
					regn = value;
			}
		}
		public int Ujævnhed {
			get { return ujævnhed; }
			set {
				if (value < 0)
					ujævnhed = 0;
				else if (value > 4)
					ujævnhed = 4;
				else
					ujævnhed = value;
			}
		}
		public Terræn Terræn {
			get { return terræn; }
			set { terræn = value; }
		}
		public int Flodretning {
			get { return flodretning; }
			set {
				if (value < -1)
					flodretning = -1;
				else if (value > 5)
					flodretning = -1;
				else
					flodretning = value;
			}
		}
		public double Vandmængde {
			get { return vandmængde; }
			set {
				if (value < 0)
					vandmængde = 0;
				else
					vandmængde = value;
			}
		}
		public int Vandhøjde {
			get {	return vandhøjde;	}
			set {
				if (value < 0)
					vandhøjde = 0;
				else
					vandhøjde = value;
			}
		}
		public bool Hav {
			get { return hav; }
			set { hav = value; }
		}
		public int Magmatryk {
			get { return magmatryk; }
			set { magmatryk = value; }
		}

		public double Tropeskov {
			get { return tropeskov; }
			set {
				if (value < 0) {
					tropeskov = 0;
				}
				tropeskov = value;

				double samlet = tropeskov + tempskov + nåleskov;
				if (samlet > 1) {
					tropeskov *= 1 / samlet;
					tempskov *= 1 / samlet;
					nåleskov *= 1 / samlet;
				}
			}
		}
		public double Tempskov {
			get { return tempskov; }
			set {
				if (value < 0) {
					tempskov = 0;
				}
				tempskov = value;

				double samlet = tropeskov + tempskov + nåleskov;
				if (samlet > 1) {
					tropeskov *= 1 / samlet;
					tempskov *= 1 / samlet;
					nåleskov *= 1 / samlet;
				}
			}
		}
		public double Nåleskov {
			get { return nåleskov; }
			set {
				if (value < 0) {
					nåleskov = 0;
				}
				nåleskov = value;

				double samlet = tropeskov + tempskov + nåleskov;
				if (samlet > 1) {
					tropeskov *= 1 / samlet;
					tempskov *= 1 / samlet;
					nåleskov *= 1 / samlet;
				}
			}
		}
		public double Skov {
			get {
				return tropeskov + tempskov + nåleskov;
			}
		}
		public double Næring {
			get {
				double næring = 0;
				if (temperatur < 0) {
					næring = (temperatur / 10.0) + 1;
				}
				else {
					næring = (50 - temperatur) / (10);
				}

				if (næring < 0)
					næring = 0;
				else if (næring > 1)
					næring = 1;

				næring *= fugtighed > 1 ? 1 : fugtighed;
				double h = Højde - 10;
				if (h < 0)
					h = 0;
				if (h > 30)
					h = 30;

				næring *= (30 - h) / 30.0;
				if (næring < 0)
					næring = 0;
				else if (næring > 1)
					næring = 1;
				return næring;
			}
		}
		public double Småvildt {
			get { return småvildt; }
			set {
				if (value < 0) {
					småvildt = 0;
				}
				else {
					småvildt = value;
				}
			}
		}
		public double Planteædere {
			get { return planteædere; }
			set {
				if (value < 0) {
					planteædere = 0;
				}
				else {
					planteædere = value;
				}
			}
		}
		public double Rovdyr {
			get { return rovdyr; }
			set {
				if (value < 0) {
					rovdyr = 0;
				}
				else {
					rovdyr = value;
				}
			}
		}
		#endregion

		#region Variables
		private List<Lag> lag;

		private double temperatur = 10;
		private double skyer = 1;
		private double fugtighed = 1;
		private int regn = 0;
		private int ujævnhed = 1;
		private Terræn terræn = Terræn.Klippe;
		private int flodretning = -1;
		private double vandmængde = 0;
		private int vandhøjde = 0;
		private bool hav = false;
		private int magmatryk = 1;
		
		private double tropeskov = 0;
		private double tempskov = 0;
		private double nåleskov = 0;
		private double småvildt = 0;
		private double planteædere = 0;
		private double rovdyr = 0;
		#endregion

		//folk og fæ
		//ting og sager
		//bygninger and shizzle

		public Felt(Verden world, int x, int y){
			this.world = world;
			this.x = x;
			this.y = y;
			lag = new List<Lag>();
		}

		

		public Felt GetNeighbour(int n) {
			if (n < 0 || n > 5)
				throw new ArgumentOutOfRangeException();
			int a = x;
			int b = y;
			Tools.NewPosition(Tools.DirectionFromNumber(n), ref a, ref b);
			if (a < 0)
				a = world.X - 1;
			if (a >= world.X)
				a = 0;
			if (b < 0 || b >= world.Y) {
				a = x;
				b = y;
			}
			return world[a, b];
		}

		public Felt GetNeighbour(Direction dir) {
			int a = x;
			int b = y;
			Tools.NewPosition(dir, ref a, ref b);
			if (a < 0)
				a = world.X - 1;
			if (a >= world.X)
				a = 0;
			if (b < 0 || b >= world.Y) {
				a = x;
				b = y;
			}
			return world[a, b];
		}
	}

	public enum Terræn { Klippe, Grus, Jord, Sand, Vulkansk }
	public enum Sten { Marmor, Kalk, Basalt, Granit, Sandsten }
	
	public struct Flod
	{
		public Direction retning;
		public double vandmængde;
		public Flod(Direction dir, double vand) {
			retning = dir;
			vandmængde = vand;
		}
	}

	public class Lag
	{
		public Sten stentype;
		
		//talene er i ton
		public double guld;
		public double sølv;
		public double jern;
		public double kobber;
		public double bly;
		public double tin;

		//public double kul;
		public double diamant;
		public double rubin;
		public double safir;
		public double smaragd;

		public Lag(
			Sten stentype,
			double guld,
			double sølv,
			double jern,
			double kobber,
			double bly,
			double tin,
			double diamant,
			double rubin,
			double safir,
			double smaragd) 
		{
			this.stentype = stentype;
			this.guld = guld;
			this.sølv = sølv;
			this.jern = jern;
			this.kobber = kobber;
			this.bly = bly;
			this.tin = tin;
			this.diamant = diamant;
			this.rubin = rubin;
			this.safir = safir;
			this.smaragd = smaragd;
		}

		public void UdJord(double mod) {
			guld *= mod;
			sølv *= mod;
			jern *= mod;
			kobber *= mod;
			bly *= mod;
			tin *= mod;
			diamant *= mod;
			rubin *= mod;
			safir *= mod;
			smaragd *= mod;
		}

		public Lag Kopier() {
			return new Lag(stentype, guld, sølv, jern, kobber, bly, tin, diamant, rubin, safir, smaragd);
		}

		public void Tilføj(Lag lag) {
			guld += lag.guld;
			sølv += lag.sølv;
			jern += lag.jern;
			kobber += lag.kobber;
			bly += lag.bly;
			tin += lag.tin;
			diamant += lag.diamant;
			rubin += lag.rubin;
			safir += lag.safir;
			smaragd += lag.smaragd;
		}
	}
}
