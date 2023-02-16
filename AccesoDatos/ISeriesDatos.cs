using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public interface ISeriesDatos
    {
        IEnumerable<Serie> ObtenerSeriesPortada();

        IEnumerable<Serie> ObtenerTodasLasSeries();

		Serie ObtenerSeriesPorId(int id);
        public void Borrar(Serie serie);

        void Actualizar(Serie serie);

        void Agregar(Serie serie);
    }
}
