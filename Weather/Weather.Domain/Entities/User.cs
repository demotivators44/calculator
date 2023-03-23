using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Common;

namespace Weather.Domain.Entities
{
	public class User : BaseEntity
	{
		public string Name { get; set; }
		public string SurName { get; set; }
		public string MidleName { get; set; }
	}
}
