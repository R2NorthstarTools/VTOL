using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTOL.Advocate.Conversion.JSON
{
	internal class Mod
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Version { get; set; }
		public int LoadPriority { get; set; }

		// there are more fields here but we dont need them for a simple skin mod
	}
}

