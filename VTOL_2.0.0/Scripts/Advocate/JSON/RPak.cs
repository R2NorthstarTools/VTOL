using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTOL.Advocate.Conversion.JSON
{
	internal class RPak
	{
		public Dictionary<string, bool> Preload { get; set; }
		// there is also Postload and Aliases but we dont need them for now
	}
}
