using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
	public interface IActoresDatos
	{
		IEnumerable<Actor> ObtenerActores();

		IEnumerable<Actor> ObtenerActoresPorSerieId(int serieId);
		
		public Actor ObtenerActorPorId(int id);

		void Actualizar(Actor actor);

		void Agregar(Actor actor);
        void BorrarActor(Actor actor);
    }
}
