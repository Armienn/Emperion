using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperion
{
	/// <summary>
	/// Grundlæggende npc controller.
	/// </summary>
	class Gaia : Controller
	{
		public Gaia(String navn) {
			Navn = navn;
		}

		public override void LoadOrdrer() {
			throw new NotImplementedException();
		}
	}
}
