using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperion
{
	/// <summary>
	/// Den grundlæggende klasse enheder. Enhver enhed består af et antal mænd
	/// (voksne folk burde det nok nærmere være, men det lyder dumt) og er 
	/// kontrolleret af en controller. En enhed kan yderligere indeholde våben,
	/// beskyttelse, mad, ting, og andre væsner.
	/// </summary>
	class Enhed
	{
		public Controller Leder { get; private set; }
		Mænd mænd;
		List<Væsner> væsner = new List<Væsner>();

		List<Ting> ting = new List<Ting>();
		List<Mad> mad = new List<Mad>();
		Våben våben;
		Beskyttelse beskyttelse;

		/// <summary>
		/// Konstruerer en basal enhed med det givne antal mænd, og den givne
		/// controller.
		/// </summary>
		/// <param name="antal"></param>
		/// <param name="leder"></param>
		public Enhed(int antal, Controller leder) {
			Leder = leder;
			Leder.Tilføj(this);
			mænd = new Mænd(antal);
		}
	}
}
