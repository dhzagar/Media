using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class Actor
	{
		public int ActorId { get; set; }
		public String Name { get; set; }
		public String CharacterName { get; set; }
		public int SerieId { get; set; }
	}
}
