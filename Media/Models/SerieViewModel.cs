using Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Series.Models
{
    public class SerieViewModel
    {
        public int Id { get; set; }
        public String Titulo { get; set; }
        public String Resumen { get; set; }
        public int Temporadas { get; set; }
        public String ImagenURL { get; set; }
        

    }
}
