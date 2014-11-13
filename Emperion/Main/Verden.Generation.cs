using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperion
{
	public partial class Verden
	{
		int kontinentevents = 400; //kontinentevents bliver areal delt med den her værdi
		int kontinentalplader = 400; //kontinentplader bliver areal delt med den her værdi
		int havhøjde = 8;
		int starthøjde = 7;
		double nordtemperatursommer = -5;
		double nordtemperaturvinter = -25;
		double sydtemperatursommer = 55;
		double sydtemperaturvinter = 40;

		double nålfugtmin = 0.2;
		double nålfugtlav = 0.5;
		double nålfugthøj = 3.5;
		double nålfugtmax = 10;
		double nåltempmin = -15;
		double nåltemplav = -5;
		double nåltemphøj = 7;
		double nåltempmax = 10;
		double tempfugtmin = 0.5;
		double tempfugtlav = 0.8;
		double tempfugthøj = 20;
		double tempfugtmax = 30;
		double temptempmin = -5;
		double temptemplav = 10;
		double temptemphøj = 20;
		double temptempmax = 25;
		double tropefugtmin = 0.3;
		double tropefugtlav = 0.5;
		double tropefugthøj = 30;
		double tropefugtmax = 40;
		double tropetempmin = 20;
		double tropetemplav = 25;
		double tropetemphøj = 40;
		double tropetempmax = 50;

		int hævradius = 3;
		int hævoffset = 1;
		int hævrandom = 3;
		int sænkradius = 3;
		int sænkoffset = 1;
		int sænkrandom = 3;

		public void GenererVerden(int kontinentsteps = 400, int simuleringsår = 30) {
			if (Status != "Initialiseret") {
				return;
			}

			Status = "Starter kort";
			int[,] pladekort = new int[X, Y];
			KontinentVektor[] pladeretninger = new KontinentVektor[kontinentalplader];

			for (int i = 0; i < X; i++) {
				for (int j = 0; j < Y; j++) {
					kort[i, j] = new Felt(this, i, j);
					pladekort[i, j] = -1;
					for (int n = 0; n < starthøjde; n++) {
						kort[i, j].AddLayer("bund");
					}
				}
			}

			GenererKontinenter(pladekort, pladeretninger);

			for (int i = 0; i < kontinentsteps; i++) {
				Status = "Rykker kontinenter, step: " + i;
				KontinentStep(pladekort, pladeretninger);
			}

			Status = "Spreder havet";
			#region Havspredning
			kort[0, 0].Vandhøjde = havhøjde - kort[0, 0].Højde;
			kort[0, 0].Hav = true;
			List<Point> tospread = new List<Point>();
			tospread.Add(new Point(0, 0));

			while (tospread.Count > 0) {
				List<Point> temp = new List<Point>();
				foreach (Point p in tospread) {
					List<Point> list = p.GetNeighbours(X, Y);
					foreach (Point poi in list) {
						if (kort[poi.x, poi.y].Vandhøjde + kort[poi.x, poi.y].Højde < havhøjde) {
							kort[poi.x, poi.y].Vandhøjde = havhøjde - kort[poi.x, poi.y].Højde;
							kort[poi.x, poi.y].Hav = true;
							temp.Add(poi);
						}
					}
				}
				tospread = temp;
			}
			#endregion Havspredning

			Status = "Udregner flodretninger";
			//fylder dale lidt først
			#region Dalfyld
			for (int i = 0; i < X; i++) {
				for (int j = 0; j < Y; j++) {
					if (!kort[i, j].Hav) {
						int hher = kort[i, j].Højde;
						Lag lag = kort[i, j].GetNeighbour(0)[0].Kopier();
						bool dal = true;
						for (int n = 0; n < 6; n++) {
							Felt nabo = kort[i, j].GetNeighbour(n);
							if (n > 0)
								lag.Tilføj(kort[i, j].GetNeighbour(n)[0]);
							if (nabo.Højde >= hher) {
								dal = false;
								break;
							}
						}
						if (dal) {
							lag.UdJord(0.1666);
							kort[i, j].AddLayer("dalfyld", lag);
							kort[i, j].Terræn = Terræn.Jord;
						}
					}
				}
			}
			#endregion Dalfyld
			FlodRetninger();

			//simulerer vind, vand, varme og så videre
			for (int i = 0; i < simuleringsår/2; i++) {
				for (int m = 0; m < 12; m++) {
					Status = "Simulerer år " + i + ": måned " + m;
					SimulerNatur();
				}
			}

			//planter folkegrupper
			/*Status = "Tilføjer folk";
			for (int i = 0; i < X; i++) {
				for (int j = 0; j < Y; j++) {
					if ((!kort[i, j].Hav) && (0 == random.Next(10))) {
						kort[i, j].Add(new Flok(kort[i, j]));
					}
				}
			}*/

			//simulerer igen, nu med folk
			for (int i = simuleringsår/2; i < simuleringsår; i++) {
				for (int m = 0; m < 12; m++) {
					Status = "Simulerer år " + i + ": måned " + m;
					Tur();
				}
			}

			Status = "Klar";
		}

		private void GenererKontinenter(int[,] pladekort, KontinentVektor[] pladeretninger) {
			//init
			List<Point>[] kontinentgrænser = new List<Point>[kontinentalplader];
			bool[] kontudvidelig = new bool[kontinentalplader];
			Status = "Genererer kontinenter";

			//sætter startpunkter for hvert kontinent og lidt andre init ting
			for (int i = 0; i < kontinentalplader; i++) {
				int x = random.Next(X);
				int y = random.Next(Y);
				while (pladekort[x, y] != -1) {
					x = random.Next(X);
					y = random.Next(Y);
				}
				pladekort[x, y] = i;
				kontinentgrænser[i] = new List<Point>();
				kontinentgrænser[i].Add(new Point(x, y));
				kontudvidelig[i] = true;
			}

			//udvider kontinenter
			bool udvidelig = true;
			while (udvidelig) {
				int plade = random.Next(kontinentalplader);
				List<Point> temp = new List<Point>();

				foreach (Point p in kontinentgrænser[plade]) {
					List<Point> tocheck = p.GetNeighbours(X, Y);
					foreach (Point po in tocheck) {
						if (pladekort[po.x, po.y] == -1) {
							pladekort[po.x, po.y] = plade;
							temp.Add(new Point(po.x, po.y));
						}
					}
				}
				kontinentgrænser[plade] = temp;
				udvidelig = false;
				foreach (List<Point> l in kontinentgrænser) {
					if (l.Count != 0) {
						udvidelig = true;
						break;
					}
				}
			}

			//laver nogle tilfældige retninger til kontinenterne
			Status = "Skubber kontinenter";

			for (int i = 0; i < kontinentalplader; i++) {
				int a = random.Next(6);
				int b = random.Next(3);
				pladeretninger[i] = new KontinentVektor(Tools.DirectionFromNumber(a), b);
			}
		}

		private void KontinentStep(int[,] pladekort, KontinentVektor[] pladeretninger) {
			//Rykker kontinenter
			for (int i = 0; i < kontinentevents; i++) {
				KontinentBevægelse(pladekort, pladeretninger);
			}

			//Eroderer verden
			for (int i = 0; i < X; i++) {
				for (int j = 0; j < Y; j++) {
					//normal erosion
					int h = kort[i, j].Højde;
					h -= havhøjde;
					if (h > 0) {
						if (h > random.Next(32)) { //bjerge
							
							List<Point> list = new Point(i, j).GetNeighbours(X, Y);
							foreach (Point p in list) { //spred metaller og ædelsten
								if (kort[p.x, p.y].Højde < kort[i, j].Højde - 1) {
									if (random.Next(32) == 0) {
										Lag lag = kort[p.x, p.y][0];
										lag.diamant += kort[i, j][0].diamant / 2;
										lag.smaragd += kort[i, j][0].smaragd / 2;
										lag.safir += kort[i, j][0].safir / 2;
										lag.rubin += kort[i, j][0].rubin / 2;
										lag.guld += kort[i, j][0].guld / 2;
										lag.sølv += kort[i, j][0].sølv / 2;
										kort[p.x, p.y].Terræn = Terræn.Grus;
									}
									else {
										Lag lag = kort[p.x, p.y][0];
										lag.jern += kort[i, j][0].jern / 10;
										lag.kobber += kort[i, j][0].kobber / 10;
										lag.bly += kort[i, j][0].bly / 10;
										lag.tin += kort[i, j][0].tin / 10;
									}
								}
							}
							kort[i, j].RemoveLayer("top");

							list = new Point(i, j).GetPointsInRange(3, X, Y);
							foreach (Point p in list) { //spred de lettere jorddele
								if (kort[p.x, p.y].Højde < kort[i, j].Højde) {
									kort[p.x, p.y][0].UdJord(0.96);
								}
							}
						}
						else if (kort[i, j].Ujævnhed == 0 && (0 == random.Next(32))) { //lavlande
							List<Point> list = new Point(i, j).GetNeighbours(X, Y);
							foreach (Point p in list) {
								if (kort[p.x, p.y].Højde > 8) {
									kort[p.x, p.y].RemoveLayer("midt");
									kort[p.x, p.y].Terræn = Terræn.Jord;
								}
							}
							kort[i, j].RemoveLayer("midt");
							kort[i, j].Terræn = Terræn.Jord;
						}
					}
					//vulkansk jord
					if (kort[i, j].Terræn == Terræn.Vulkansk) {
						if (random.Next(16) == 0) {
							kort[i, j].Terræn = Terræn.Jord;
						}
					}
					//grus
					if (kort[i, j].Terræn == Terræn.Grus) {
						if (random.Next(16) == 0) {
							kort[i, j].Terræn = Terræn.Jord;
						}
					}

					//kant erosion
					int a = Math.Abs(i - X / 2);
					int b = Math.Abs(j - Y / 2);
					a = Math.Abs(a - X / 2);
					b = Math.Abs(b - Y / 2);
					if ((Math.Min(a, b) < random.Next(7)) && (0 == random.Next(Math.Min(a, b) + 1))) {
						if (kort[i, j].Højde > 4) {
							kort[i, j].RemoveLayer("midt");
						}
					}
				}
			}

			//Udbryder vulkaner
			for (int i = 1; i < X - 1; i++) {
				for (int j = 1; j < Y - 1; j++) {
					if (kort[i, j].Magmatryk - 8 > random.Next(24)) {
						if (0 == random.Next(8)) { //stort udbrud
							List<Point> list = new Point(i, j).GetNeighbours(X, Y);
							foreach (Point p in list) {
								kort[p.x, p.y].AddLayer("vulkanbred");
								kort[p.x, p.y].AddLayer("vulkanbred");
								kort[p.x, p.y].Terræn = Terræn.Vulkansk;
							}
							kort[i, j].Magmatryk -= 8;
						}
						else { //mindre udbrud
							kort[i, j].Magmatryk -= 4;
						}
						List<Point> temp = new Point(i, j).GetPointsInRange(1, X, Y);
						foreach (Point p in temp) {
							if (random.Next(2) == 0) {
								kort[p.x, p.y].AddLayer("vulkanbred");
								kort[p.x, p.y].Terræn = Terræn.Vulkansk;
							}
						}
						kort[i, j].AddLayer("vulkansmal");
						kort[i, j].AddLayer("vulkansmal");
						kort[i, j].Terræn = Terræn.Vulkansk;
					}
				}
			}

			//Fylder små (vand)huller
			for (int i = 1; i < X - 1; i++) {
				for (int j = 1; j < Y - 1; j++) {
					if (kort[i, j].Højde < havhøjde) {
						List<Point> list = new Point(i, j).GetNeighbours(X, Y);
						bool vand = false;
						foreach (Point p in list) {
							if (kort[p.x, p.y].Højde < havhøjde) {
								vand = true;
								break;
							}
						}
						if (!vand) {
							kort[i, j].AddLayer("vandhulfyld", kort[i, j].GetNeighbour(0)[0]);
						}
					}
				}
			}

			//Ændrer kontinenters retninger
			int plade = random.Next(kontinentalplader);
			int dir = Tools.DirectionToNumber(pladeretninger[plade].retning);
			dir += random.Next(3) - 1;
			if (dir > 5)
				dir = 0;
			if (dir < 0)
				dir = 5;
			int hast = pladeretninger[plade].hastighed;
			hast += random.Next(3) - 1;
			if (hast > 2)
				hast = 0;
			if (hast < 0)
				hast = 2;
			pladeretninger[plade] = new KontinentVektor(Tools.DirectionFromNumber(dir), hast);
		}

		private void KontinentBevægelse(int[,] pladekort, KontinentVektor[] pladeretninger) {
			bool grænse = false;
			int pladeA = -1;
			int pladeB = -1;
			Point point = new Point(random.Next(X), random.Next(Y));
			List<Point> list = point.GetNeighbours(X, Y);
			string retning = ""; //"imod" / "langs" / "fra"

			do {
				//vælger et vilkårligt punkt
				point = new Point(random.Next(X), random.Next(Y));
				if (point.IsOnBorder(X, Y))
					continue;
				//finder ud af om det er på en kontinentgrænse
				pladeA = pladekort[point.x, point.y];
				list = point.GetNeighbours(X, Y);
				foreach (Point p in list) {
					if (pladeA != pladekort[p.x, p.y]) {
						pladeB = pladekort[p.x, p.y];
						grænse = true;
						break;
					}
				}
			}	while (!grænse);
			

			//Nu burde det være ved en grænse, så vi gør en masse seje ting
			int bjergmængde = 0;
			int sænkning = 0;
			int hævning = 0;
			int magmatrykning = 0;

			//finder ud af hvilken retning kontinentet har i forhold til grænsen
			int ret = Tools.DirectionToNumber(pladeretninger[pladeA].retning);
			int venstre = (ret + 1 > 5) ? 0 : (ret + 1);
			int højre = (ret - 1 < 0) ? 5 : (ret - 1);
			if (pladekort[list[ret].x, list[ret].y] != pladeA) {
				retning = "imod";
			}
			else {
				int ens = pladekort[list[højre].x, list[højre].y] == pladeA ? 1 : 0;
				ens += pladekort[list[venstre].x, list[venstre].y] == pladeA ? 1 : 0;
				if (ens == 2)
					retning = "fra";
				else
					retning = "langs";
			}

			//finder ud af hvilke ændringer der skal laves ud fra retningerne og hastighederne
			int a = Tools.DirectionToNumber(pladeretninger[pladeA].retning);
			int b = Tools.DirectionToNumber(pladeretninger[pladeB].retning);
			int k = pladeretninger[pladeA].hastighed;
			int q = pladeretninger[pladeB].hastighed;

			if (a == b) { // kontinenterne har samme retning
				if (k - q == 0) { //de har samme hastighed

				}
				else if (k - q > 0) { // PladeA er hurtigere
					if (retning == "imod") {
						hævning = 1;
					}
					else if (retning == "fra") {
						sænkning = 1;
					}
				}
				else { // PladeB er hurtigere
					if (retning == "imod") {
						sænkning = 1;
					}
					else if (retning == "fra") {
						hævning = 1;
					}
				}
			}
			else if (Math.Abs(a - b) == 3) { // kontinenterne har modsat retning
				if (k + q == 0) { //de står stille

				}
				else if (k + q > 2) { // de er hurtige
					if (retning == "imod") {
						bjergmængde = 3;
						hævning = 3;
						magmatrykning = 1;
					}
					else if (retning == "fra") {
						sænkning = 2;
						magmatrykning = 3;
					}
					else {
						magmatrykning = 3;
						if (random.Next(2) == 0) {
							sænkning = 1;
						}
						else {
							hævning = 1;
						}
					}
				}
				else { // de er langsomme
					if (retning == "imod") {
						bjergmængde = 2;
						hævning = 2;
					}
					else if (retning == "fra") {
						sænkning = 2;
						magmatrykning = 2;
					}
					else {
						magmatrykning = 2;
						if (random.Next(2) == 0) {
							sænkning = 1;
						}
						else {
							hævning = 1;
						}
					}
				}
			}
			else { // kontinenterne har halvt på hinanden retninger
				if (k + q == 0) { //de står stille

				}
				else if (k + q > 2) { // de er hurtige
					if (retning == "imod") {
						hævning = 1;
						bjergmængde = 1;
					}
					else if (retning == "fra") {
						sænkning = 1;
						magmatrykning = 1;
					}
					else {
						magmatrykning = 1;
						if (random.Next(2) == 0) {
							sænkning = 1;
						}
						else {
							hævning = 1;
						}
					}
				}
				else { // de er langsomme
					if (retning == "imod") {
						hævning = 1;
					}
					else if (retning == "fra") {
						sænkning = 1;
					}
					else {
						if (random.Next(2) == 0) {
							sænkning = 1;
						}
						else {
							hævning = 1;
						}
					}
				}
			}

			// har fundet ud af hvilke ændringer vi vil have, så skal de bare udføres
			if (hævning != 0) {
				//vælger et tilfældigt punkt i nærheden
				Point hævcenter = new Point(
					point.x + random.Next((hævoffset + hævning) * hævradius * 2) - ((hævoffset + hævning) * hævradius),
					point.y + random.Next((hævoffset + hævning) * hævradius * 2) - ((hævoffset + hævning) * hævradius));
				list = hævcenter.GetPointsInRange(((hævoffset + hævning) * hævradius) - hævrandom + random.Next(hævrandom * 2), X, Y);
				foreach (Point poi in list) {
					kort[poi.x, poi.y].AddLayer("bund");
					if (kort[poi.x, poi.y].Ujævnhed > 1) {
						if (random.Next(16) == 0) {
							kort[poi.x, poi.y].Ujævnhed--;
						}
					}
					else {
						if (random.Next(32) == 0) {
							kort[poi.x, poi.y].Ujævnhed--;
						}
					}
				}
			}
			if (sænkning != 0) {
				Point sænkcenter = new Point(
					point.x + random.Next((sænkoffset + sænkning) * sænkradius * 2) - ((sænkoffset + sænkning) * sænkradius),
					point.y + random.Next((sænkoffset + sænkning) * sænkradius * 2) - ((sænkoffset + sænkning) * sænkradius));
				list = sænkcenter.GetPointsInRange(((sænkoffset + sænkning) * sænkradius) - sænkrandom + random.Next(sænkrandom * 2), X, Y);
				foreach (Point poi in list) {
					if (kort[poi.x, poi.y].Højde > 1) {
						List<Point> temp = poi.GetNeighbours(X, Y);
						int under = 0;
						foreach (Point poin in temp) {
							if (kort[poin.x, poin.y].Højde < 8)
								under++;
						}
						if (under > random.Next(2)) {
							if (kort[poi.x, poi.y].Højde > 8) {
								kort[poi.x, poi.y].RemoveLayer("bund");
							}
							else {
								kort[poi.x, poi.y].RemoveLayer("midt");
							}
						}
					}
				}
			}
			if (magmatrykning != 0) {
				kort[point.x, point.y].Magmatryk += magmatrykning * 4;
			}
			if (bjergmængde != 0) {
				Point bjergcenter = new Point(
					point.x + random.Next(3 + (bjergmængde > 1 ? 2 : 0)) - (bjergmængde > 1 ? 2 : 1),
					point.y + random.Next(3 + (bjergmængde > 1 ? 2 : 0)) - (bjergmængde > 1 ? 2 : 1));
				list = bjergcenter.GetPointsInRange(bjergmængde - 1, X, Y);
				foreach (Point poi in list) {
					if (random.Next(2) == 0) {
						kort[poi.x, poi.y].AddLayer("bund");
						kort[poi.x, poi.y].Terræn = Terræn.Klippe;
						kort[poi.x, poi.y].Ujævnhed++;
					}
					if (bjergmængde > 1) {
						if (random.Next(2) == 0) {
							kort[poi.x, poi.y].AddLayer("bund");
							kort[poi.x, poi.y].Terræn = Terræn.Klippe;
							kort[poi.x, poi.y].Ujævnhed++;
						}
					}
				}
			}
		}

		private void FlodRetninger() {
			bool[,] færdig = new bool[X, Y];
			for (int i = 0; i < X; i++) {
				for (int j = 0; j < Y; j++) {
					if (kort[i, j].Hav) {
						færdig[i, j] = true;
					}
					if (!færdig[i, j]) {
						int hher = kort[i, j].Højde;
						int hmin = kort[i, j].Højde;
						List<int> minnabo = new List<int>();
						for (int n = 0; n < 6; n++) {
							Felt nabo = kort[i, j].GetNeighbour(n);
							if (nabo.Højde == hmin) {
								minnabo.Add(n);
							}
							else if (nabo.Højde < hmin) {
								hmin = nabo.Højde;
								minnabo.Clear();
								minnabo.Add(n);
							}
						}
						if (minnabo.Count == 0) { //vi er i en dal

						}
						else if (minnabo.Count == 1) { //der er én dybest nedgang
							int nabox = kort[i, j].GetNeighbour(minnabo[0]).x;
							int naboy = kort[i, j].GetNeighbour(minnabo[0]).y;
							if (færdig[nabox, naboy] && (hmin == hher)) { //hvis nedgangen er i samme højde, tjekker vi om den selv flyder hertil
								int dir = minnabo[0];
								int diranden = kort[i, j].GetNeighbour(dir).Flodretning;
								diranden += 3;
								if (diranden > 5)
									diranden -= 6;
								if (dir == diranden) {
									kort[i, j].GetNeighbour(dir).Flodretning = -1;
									kort[i, j].Flodretning = -1;
								}
								else {
									kort[i, j].Flodretning = minnabo[0];
								}
							}
							else {
								kort[i, j].Flodretning = minnabo[0];
							}
						}
						else { //der er flere dybeste nedgange
							if (hmin < hher) { //de er under: vælg en vilkårlig
								kort[i, j].Flodretning = minnabo[random.Next(minnabo.Count)];
							}
							else { //damn
								bool succ = false;
								foreach (int nb in minnabo) { //tjekker om nogen har en retning væk allerede
									int dir = kort[i, j].GetNeighbour(nb).Flodretning;
									if (dir != -1) {
										dir += 3;
										if (dir > 5)
											dir -= 6;
										if (nb != dir) { //den flyder ikke her mod
											kort[i, j].Flodretning = nb;
											succ = true;
											break;
										}
									}
								}
								if (!succ) { //der var ikke nogen med en retning væk
									//søg efter en vej ned
									List<Point> flod = new List<Point>();
									List<Point> blindgyder = new List<Point>();
									flod.Add(new Point(i, j));
									if (!FlodFinder(flod, blindgyder, færdig)) {
										//hvis der ikke blev fundet en vej væk
										færdig[i, j] = true;
									}
									//overvejelser til ordentlig version:
									//mens ikke ved havet:
									//  floodfill for at finde ud af om der er en vej nedad
									//  hvis der findes en, følg den
									//    hvis den leder til havet, success
									//    hvis ikke, 
									//  hvis ikke, stig et niveau og prøv igen
								}
							}
						}
					}
					færdig[i, j] = true;
				}
			}
		}

		private bool FlodFinder(List<Point> flod, List<Point> blindgyder, bool[,] færdig) {
			Felt nyepunkt = kort[flod[flod.Count - 1].x, flod[flod.Count - 1].y];
			int højde = nyepunkt.Højde;

			//finder hvad der er i nærheden, som går ned
			int hmin = højde;
			List<int> minnabo = new List<int>();
			for (int n = 0; n < 6; n++) {
				Felt nabo = nyepunkt.GetNeighbour(n);
				if (nabo.Højde == hmin) {
					minnabo.Add(n);
				}
				else if (nabo.Højde < hmin) {
					hmin = nabo.Højde;
					minnabo.Clear();
					minnabo.Add(n);
				}
			}

			if (hmin < højde) { // der er nedgange!
				nyepunkt.Flodretning = minnabo[random.Next(minnabo.Count)]; // vælg en vilkårlig af nedgangene
				færdig[nyepunkt.x, nyepunkt.y] = true;
				return true;
			}

			//der er en eller flere i same niveau
			List<int> frinaboer = new List<int>();
			for (int nr = random.Next(minnabo.Count); minnabo.Count > 0; nr = random.Next(minnabo.Count)) { //kigger igennem naboerne i vilkårlig rækkefølge
				int n = minnabo[nr]; // n er retningen, nr er indexet i minnabo
				Felt nabo = nyepunkt.GetNeighbour(n);
				int dir = nabo.Flodretning;
				if (dir != -1) {
					dir += 3;
					if (dir > 5)
						dir -= 6;
					if (n != dir) { //en nabo flyder væk, yay
						nyepunkt.Flodretning = n;
						færdig[nyepunkt.x, nyepunkt.y] = true;
						return true;
					}
					else { //naboen flyder herimod
						minnabo.RemoveAt(nr);
					}
				}
				else { // hvis naboen er retningsløs
					//først tjekker vi om den er fri til at fortsætte på
					bool fri = true;
					foreach (Point p in flod) {
						if (p.x == nabo.x && p.y == nabo.y) {
							fri = false;
						}
					}
					foreach (Point p in blindgyder) {
						if (p.x == nabo.x && p.y == nabo.y) {
							fri = false;
						}
					}
					if (færdig[nabo.x, nabo.y]) {
						fri = false;
					}
					if (fri) {
						frinaboer.Add(n);
					}
					minnabo.RemoveAt(nr);
				}
			}

			if (frinaboer.Count > 0) { //der er kun fri naboer, vi må fortsætte med at lede ude langs en af dem
				int prøvindex = random.Next(frinaboer.Count);
				Felt ny = nyepunkt.GetNeighbour(frinaboer[prøvindex]);
				flod.Add(new Point(ny.x, ny.y));
				while (!FlodFinder(flod, blindgyder, færdig)) {
					frinaboer.RemoveAt(prøvindex);
					if (frinaboer.Count < 1) { //der er ikke flere frie tilbage
						blindgyder.Add(new Point(nyepunkt.x, nyepunkt.y));
						flod.RemoveAt(flod.Count - 1);
						return false;
					}
					prøvindex = random.Next(frinaboer.Count);
					ny = nyepunkt.GetNeighbour(frinaboer[prøvindex]);
					flod.Add(new Point(ny.x, ny.y));
				}
				//en vej er blevet fundet
				nyepunkt.Flodretning = frinaboer[prøvindex];
				færdig[nyepunkt.x, nyepunkt.y] = true;
				return true;
			}
			else {
				blindgyder.Add(new Point(nyepunkt.x, nyepunkt.y));
				flod.RemoveAt(flod.Count - 1);
				return false;
			}
		}

		struct KontinentVektor
		{
			public Direction retning;
			public int hastighed;
			public KontinentVektor(Direction dir, int hast) {
				retning = dir;
				hastighed = hast;
			}
		}
	}
}
