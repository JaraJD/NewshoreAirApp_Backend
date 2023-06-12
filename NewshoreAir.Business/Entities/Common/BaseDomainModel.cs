using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAir.Business.Entities.Common
{
	public abstract class BaseDomainModel
	{
		public string? Origin { get; set; }

		public string? Destination { get; set; }

		public decimal Price { get; set; }
	}
}
