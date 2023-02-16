using Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Series.Models
{
	public class ActorViewModel
	{
		public int ActorId { get; set; }
		public String Name { get; set; }
		public String CharacterName { get; set; }
		public int SerieId { get; set; }
	}
}
