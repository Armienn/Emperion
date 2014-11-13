using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperion
{
	/// <summary>
	/// Spiller-baseret controller.
	/// </summary>
	class Spiller : Controller
	{
		public Spiller(String navn) {
			Navn = navn;
		}

		public override void LoadOrdrer() {
			throw new NotImplementedException();
		}
	}
}
