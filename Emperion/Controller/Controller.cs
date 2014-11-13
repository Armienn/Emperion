using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperion
{
	/// <summary>
	/// Base klasse for controllers. Alle enheder hører under en controller,
	/// som tager sig af at styre dem.
	/// </summary>
	abstract class Controller
	{
		public String Navn { get; protected set; }
		protected Verden verden;
		protected List<Enhed> enheder;

		/// <summary>
		/// Tilføjer en enhed til denne controllers liste. Det forventes at 
		/// controlleren allerede er sat som den vedkommende enheds leder.
		/// </summary>
		/// <param name="enhed"></param>
		public void Tilføj(Enhed enhed) {
			enheder.Add(enhed);
		}

		public abstract void LoadOrdrer();
	}
}
