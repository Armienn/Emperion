using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Emperion
{
	public partial class Verden
	{
		public Felt this[int x, int y] {
			get {
				return kort[x, y];
			}
		}
		Felt[,] kort;
		public readonly int X, Y;
		public int Måned {
			get {
				return måned;
			}
		}
		int måned = 0;
		
		public string Status { get; private set; }

		Random random;
		int vindvandsteps = 5;

		public Verden(int x, int y)
			: this(x, y, new Random().Next()) {	}

		public Verden(int x, int y, int seed) {
			Status = "Initialiserer";
			kort = new Felt[x, y];
			X = x;
			Y = y;
			kontinentevents = X * Y / kontinentevents;
			kontinentevents = kontinentevents < 2 ? 2 : kontinentevents;
			kontinentalplader = X * Y / kontinentalplader;
			kontinentalplader = kontinentalplader < 8 ? 8 : kontinentalplader;
			random = new Random(seed);

			Status = "Initialiseret";
		}

		public void Tur() {
			#region PC
			//TODO: load ordrer
			//TODO: udfør ordrer
			#endregion PC

			#region NPC
			//TODO: Udregn Gaia ordrer
			//TODO: udfør Gaia ordrer
			#endregion NPC

			SimulerNatur();
		}

		public void SimulerNatur() {
			if (måned > 11 || måned < 0 )
				return;

			//udregner temperatur
			double nordtemp, sydtemp;
			Temperatur(måned, out nordtemp, out sydtemp);

			#region Vindvand
			//nogle steps til vind og vand
			for (int n = 0; n < vindvandsteps; n++) {
				Vector[,] tempvind = new Vector[X, Y];
				double[,] temptemp = new double[X, Y];
				double[,] tempdamp = new double[X, Y];
				double[,] tempfugt = new double[X, Y];
				double[,] tempvand = new double[X, Y];

				for (int i = 0; i < X; i++) {
					for (int j = 0; j < Y; j++) {
						//vind
						Vector sum = kort[i, j].vind.Translate((random.NextDouble() * 4) - 0.5, (random.NextDouble()*1.5) + 0.5);
						Vector tempsum = new Vector(0, 0);
						Direction vindretning = Tools.DirectionFromAngle(kort[i, j].vind.Angle);
						double bjergmængde = 0;
						for (int nei = 0; nei < 6; nei++) {
							Felt neighbour = kort[i, j].GetNeighbour(nei);
							int højdeforskel = neighbour.Højde + neighbour.Vandhøjde - (kort[i, j].Højde + kort[i, j].Vandhøjde);
							double tempforskel = kort[i, j].Temperatur - neighbour.Temperatur;
							Vector tempvec = Tools.GetUnityVector(Tools.DirectionFromNumber(nei)).Multiply(-1);

							if (Tools.DirectionToNumber(vindretning) == nei) {
								if (højdeforskel > 1)
									bjergmængde = (højdeforskel - 1) / 6.0;
							}

							sum = sum.Add(neighbour.vind.Translate((random.NextDouble() * 4) - 0.5, (random.NextDouble()*1.5) + 0.5));

							tempsum = tempsum.Add(tempvec.Multiply((float)(tempforskel * 0.1 * ((float)X / (float)100))));
						}
						sum = sum.Multiply((float)1 / (float)7);
						sum = sum.Subtract(kort[i, j].vind);//forskellen i vinden her og gennemsnittet her omkring
						tempvind[i, j] = (kort[i, j].vind.Add(sum.Multiply((float)0.8))); //tilføjer noget af forskellen
						tempvind[i, j] = tempvind[i, j].Translate(bjergmængde * Math.PI / 3, bjergmængde == 0 ? 1 : 0.9); //ændrer på grund af bjerge
						tempvind[i, j] = tempvind[i, j].Add(tempsum);//tilføjer vind fra temperaturer
						float mag = (float) tempvind[i, j].Magnitude;
						if (mag > 1) {
							tempvind[i, j] = tempvind[i, j].Multiply(((float)1)/(mag));
						}
						//tempvind[i, j] = mag > 1 ? tempvind[i, j].Multiply((float)Math.Min(mag - 1, 0.5)) : tempvind[i, j];

						//temperatur
						// retningen der blæser fra:
						int dir = Tools.DirectionToNumber(vindretning);
						dir+=3;
						if (dir > 5)
							dir -= 6;
						double tempher = kort[i, j].Temperatur;
						double tempder = kort[i, j].GetNeighbour(dir).Temperatur;
						temptemp[i, j] = ((tempder - tempher) * kort[i,j].vind.Magnitude) + tempher;

						//fordamper vand
						double mængde = 0;
						/*if (kort[i, j].Vandhøjde > 0) {
							tempdamp[i, j] = (tempher + 40) / 400; // mellem 0 og 0.2
						}
						else if (kort[i, j].Flodretning == -1) {
							mængde = kort[i,j].Vandmængde * (tempher + 40) / 400;
							kort[i, j].Vandmængde -= mængde;
							//tempdamp[i, j] = mængde;
						}*/
						if (kort[i, j].Hav) {
							tempdamp[i, j] = (tempher + 40) / 400; // mellem 0 og 0.2
						}
						else if (kort[i, j].Vandhøjde > 0) {
							mængde = kort[i, j].Vandmængde * (tempher + 40) / 400;
							kort[i, j].Vandmængde -= mængde;
							//tempdamp[i, j] = mængde;
						}
						else {// if (kort[i, j].Flodretning == -1) {
							mængde = kort[i, j].Vandmængde * (tempher + 40) / 400;
							kort[i, j].Vandmængde -= mængde;
							//tempdamp[i, j] = mængde;
						}
						
						//regner
						double skyvand = kort[i, j].Skyer;
						if (n == 0)
							kort[i, j].Regn = 0; // tæller for regn den her måned
						if (kort[i, j].Hav)
							mængde = 0.2;
						else
							mængde = 0;
						if (skyvand > Math.Sqrt(random.NextDouble()) + 0.1 + mængde) { //skal det regne?
							kort[i, j].Regn++;
							mængde = random.NextDouble();
							mængde *= mængde;
							mængde *= skyvand;
							kort[i, j].Skyer -= mængde;
							kort[i, j].Fugtighed += mængde;
						}
						kort[i, j].Skyer += tempdamp[i, j];

						//blæser skyer
						Felt victim = kort[i, j].GetNeighbour(vindretning);
						double hast = kort[i, j].vind.Magnitude;
						hast = hast > 1 ? 1 : hast;
						mængde = kort[i, j].Skyer * hast * 0.4;
						kort[i, j].Skyer -= mængde;
						tempdamp[victim.x, victim.y] += mængde;
						mængde = kort[i, j].Skyer / 12;
						for (int mm = 0; mm < 6; mm++) {
							victim = kort[i, j].GetNeighbour(mm);
							tempdamp[victim.x, victim.y] += mængde;
							kort[i, j].Skyer -= mængde;
						}

						//spreder fugtighed
						double del = 0.4;
						if (kort[i, j].Hav)
							del = 0.8;
						mængde = (kort[i, j].Fugtighed * del) / 6;
						for (int mm = 0; mm < 6; mm++) {
							victim = kort[i, j].GetNeighbour(mm);
							tempfugt[victim.x, victim.y] += mængde;
							kort[i, j].Fugtighed -= mængde;
						}

						//fortætter
						if (kort[i, j].Hav) {
							mængde = kort[i, j].Fugtighed * 0.05;
						}
						else {
							mængde = kort[i, j].Fugtighed * ((((double)kort[i, j].Ujævnhed) * 0.1) + 0.4); // mellem 0.4 og 0.8 gange fugtighed
						}
						kort[i, j].Fugtighed -= mængde;
						kort[i, j].Vandmængde += mængde;

						//flyder
						if ((kort[i, j].Vandhøjde == 0) && (kort[i, j].Flodretning != -1)) {
							Felt nabo = kort[i, j].GetNeighbour(kort[i, j].Flodretning);
							mængde = kort[i, j].Vandmængde * 0.1;//((((double)kort[i, j].Ujævnhed) * 0.1) + 0.1)*0.1; // mellem 0.1 og 0.4 gange vandmængde
							kort[i, j].Vandmængde -= mængde;
							tempvand[nabo.x, nabo.y] = mængde;
						}
					}
				}

				#region Opdatering
				//applying changes
				for (int i = 0; i < X; i++) {
					for (int j = 0; j < Y; j++) {
						Felt her = kort[i, j];
						her.vind = tempvind[i, j];
						her.Temperatur = temptemp[i, j];
						if (!(her.Temperatur > -50 && her.Temperatur < 100)) {
							her.Temperatur = 0;
						}
						if (!((her.vind.x > -5 && her.vind.x < 5) && (her.vind.y > -5 && her.vind.y < 5))) {
							her.vind = new Vector(0, 0);
						}

						//flytter skyer
						her.Skyer += tempdamp[i, j];

						//flytter fugt
						her.Fugtighed += tempfugt[i, j];

						//flytter og opdaterer vand
						if (her.Flodretning == -1) {
							if (her.Vandhøjde == 0 && her.Vandmængde > 10) {
								int søhøjde = her.Højde + 1;
								her.Vandhøjde = 1;
								
								List<Point> tospread = new List<Point>();
								tospread.Add(new Point(i, j));

								while (tospread.Count > 0) {
									List<Point> temp = new List<Point>();
									foreach (Point p in tospread) {
										List<Point> list = p.GetNeighbours(X, Y);
										foreach (Point poi in list) {
											if (kort[poi.x, poi.y].Hav) {
												throw new Exception("En sø forsøgte at brede sig ud over havet");
											}
											if (kort[poi.x, poi.y].Vandhøjde + kort[poi.x, poi.y].Højde < søhøjde) {
												kort[poi.x, poi.y].Vandhøjde = søhøjde - kort[poi.x, poi.y].Højde;
												temp.Add(poi);
											}
										}
									}
									tospread = temp;
								}
							}
						}
						if (her.Vandhøjde > 0) {
							her.Vandmængde = 0;
							//her.Fugtighed = 0;
						}
						else {
							her.Vandmængde += tempvand[i, j];
						}
					}
				}
				#endregion Opdatering
			}
			#endregion Vindvand

			#region Bevoksning
			for (int i = 0; i < X; i++) {
				for (int j = 0; j < Y; j++) {
					if (kort[i, j].Vandhøjde == 0) {
						double mtrop = kort[i, j].Tropeskov;
						double mtemp = kort[i, j].Tempskov;
						double mnåle = kort[i, j].Nåleskov;

						double seed = (mtrop * 0.9) + 0.1;
						double konv = KonvergensSkov(kort[i, j], tropefugtmin, tropefugtlav, tropefugthøj, tropefugtmax, tropetempmin, tropetemplav, tropetemphøj, tropetempmax);
						mtrop += (konv - mtrop) * seed * 0.02;

						seed = (mtemp * 0.9) + 0.1;
						konv = KonvergensSkov(kort[i, j], tempfugtmin, tempfugtlav, tempfugthøj, tempfugtmax, temptempmin, temptemplav, temptemphøj, temptempmax);
						mtemp += (konv - mtemp) * seed * 0.02;

						seed = (mnåle * 0.9) + 0.1;
						konv = KonvergensSkov(kort[i, j], nålfugtmin, nålfugtlav, nålfugthøj, nålfugtmax, nåltempmin, nåltemplav, nåltemphøj, nåltempmax);
						mnåle += (konv - mnåle) * seed * 0.02;

						double mængde = mtrop + mtemp + mnåle;
						if (mængde > 1) {
							mtrop *= 1 / mængde;
							mtemp *= 1 / mængde;
							mnåle *= 1 / mængde;
						}
						kort[i, j].Tropeskov = 0;
						kort[i, j].Tempskov = 0;
						kort[i, j].Nåleskov = 0;
						kort[i, j].Tropeskov = mtrop;
						kort[i, j].Tempskov = mtemp;
						kort[i, j].Nåleskov = mnåle;
					}
				}
			}
			#endregion Bevoksning

			#region Vildt
			for (int i = 0; i < X; i++) {
				for (int j = 0; j < Y; j++) {
					if (kort[i, j].Vandhøjde == 0) {
						double skov = kort[i, j].Skov;
						double næring = kort[i, j].Næring;
						//skoven har mindre mad til rådighed for større planteædere, ikke-skov har mere, og vice versa for små dyr
						double behovstore = kort[i, j].Planteædere * 0.002; //brug for en femhundredendedel per dyr
						double behovsmå = kort[i, j].Småvildt * 0.0001;

						double tilgængeligtstore = næring * (skov * 0.25 + (1 - skov) * 0.75);
						double tilgængeligtsmå = næring * (skov * 0.75 + (1 - skov) * 0.25);

						double forskel = tilgængeligtstore - behovstore;

						if (forskel < 0){ //ikke nok til de store
							double hungrende = -forskel * 500;
							kort[i, j].Planteædere -= hungrende * 0.1; //en tiendedel dør
						}
						else { //hvis ingen hungrer
							if ((måned < 8) && (måned > 1)) { //og det er forår/sommer
								double seed = kort[i, j].Planteædere + 10;
								kort[i, j].Planteædere += seed * 0.1;
							}
						}

						forskel = tilgængeligtsmå - behovsmå;
						if (forskel < 0) { //ikke nok til de små
							double hungrende = -forskel * 10000;
							kort[i, j].Småvildt -= hungrende * 0.1; //en tiendedel dør
						}
						else { //hvis ingen hungrer
							double seed = kort[i, j].Småvildt + 200;
							kort[i, j].Småvildt += seed * 0.05;
						}

						//rovdyr
						double rovbehov = kort[i, j].Rovdyr;
						double tilgængeligt = (kort[i, j].Planteædere + kort[i, j].Småvildt * 0.1) * 0.1;
						forskel = tilgængeligt - rovbehov;

						if (forskel < 0) {
							double hungrende = -forskel;
							kort[i, j].Småvildt *= 0.95;
							kort[i, j].Planteædere *= 0.95;
							kort[i, j].Rovdyr -= hungrende * 0.1;
						}
						else {
							kort[i, j].Småvildt -= 0.05 * (rovbehov / tilgængeligt) * kort[i, j].Småvildt;
							kort[i, j].Planteædere -= 0.05 * (rovbehov / tilgængeligt) * kort[i, j].Planteædere;
							if (måned == 2 || måned == 3) {
								double seed = kort[i, j].Rovdyr + 4;
								kort[i, j].Rovdyr += seed * 0.1;
							}
						}
					}
				}
			}
			#endregion Vildt

			måned++;
			if (måned > 11)
				måned = 0;
		}

		void Temperatur(int måned, out double nordtemp, out double sydtemp) {
			int sommerhed = måned > 5 ? (11 - måned) : måned; //bliver et tal mellem 0 og 5. Høj er sommer, lav er vinter
			double tmpmod = sommerhed / 5.0;
			nordtemp = (nordtemperatursommer - nordtemperaturvinter) * tmpmod + nordtemperaturvinter;
			sydtemp = (sydtemperatursommer - sydtemperaturvinter) * tmpmod + sydtemperaturvinter;
			for (int j = 0; j < Y; j++) {
				double distrfunk = 0;
				double h = ((double)j) / (double)(Y - 1);
				if (h < 0.33) {
					distrfunk = 1.5 * j / (Y - 1);
				}
				else if (h > 0.66) {
					distrfunk = 1.5 * j / (Y - 1) - 0.5;
				}
				else {
					distrfunk = 0.5;
				}

				double lokaltemp = sydtemp + (nordtemp - sydtemp) * distrfunk;
				for (int i = 0; i < X; i++) {
					tmpmod = 0;
					if (kort[i, j].Vandhøjde > 3)
						tmpmod = (3 - sommerhed) * 2;
					else if (kort[i, j].Vandhøjde > 1)
						tmpmod = 3 - sommerhed;
					else if (kort[i, j].Vandhøjde == 0) {
						tmpmod = -(float)(kort[i, j].Højde - 8) / (float)4;
					}

					kort[i, j].Temperatur = tmpmod + ((kort[i, j].Temperatur + lokaltemp) / 2);

				}
			}
		}

		private double KonvergensSkov(Felt tile, 	double fugtmin,	double fugtlav,	double fugthøj,	double fugtmax,	double tempmin,	double templav,	double temphøj,	double tempmax) {
			double fugt = 1;
			double temp = 1;
			double terræn = 1;
			if (tile.Terræn == Terræn.Grus) {
				terræn = 0.6;
			}
			else if (tile.Terræn == Terræn.Klippe) {
				terræn = 0.2;
			}
			else if (tile.Terræn == Terræn.Vulkansk) {
				terræn = 0.9;
			}

			fugt = Tools.RhombusFunction(tile.Fugtighed, fugtmin, fugtlav, fugthøj, fugtmax);

			temp = Tools.RhombusFunction(tile.Temperatur, tempmin, templav, temphøj, tempmax);

			double result = fugt * temp;
			double hmod = ((((float)20 / (float)tile.Højde) - 1) * 0.5)+1;
			result = hmod * result;
			if (result < 0)
				result = 0;
			else if (result > 1)
				result = 1;
			return Math.Sqrt(result)*terræn;
		}
	}
}
