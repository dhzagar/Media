using Entidades;
using AccesoDatos;
using Series.Models;

namespace Series.Services
{
    public class ActoresServices : IActoresServices
    {
        public IActoresDatos datos;

        public ActoresServices(IActoresDatos datos)
        {
            this.datos = datos;
        }

        public void ActualizarActor(ActorViewModel actorViewModel)
        {

            datos.Actualizar(Convertir(actorViewModel));
        }

        public void AgregarActor(ActorViewModel actor)
        {
            datos.Agregar(Convertir(actor));
        }

        public void BorrarActor(int id)
        {
            Actor actor = datos.ObtenerActorPorId(id);
            datos.BorrarActor(actor);
        }

        public ActorViewModel ObtenerActor(int id)
        {
            return Convertir(datos.ObtenerActorPorId(id));
        }
        public IEnumerable<ActorViewModel> ObtenerActores(int id)
        {
            return Convertir(datos.ObtenerActoresPorSerieId(id));
        }
        public IEnumerable<ActorViewModel> ObtenerTodosLosActores()
        {
            return Convertir(datos.ObtenerActores());
        }

        private static ActorViewModel Convertir(Actor actor)
        {
            return new ActorViewModel()
            {
                ActorId = actor.ActorId,
                Name = actor.Name,
                CharacterName = actor.CharacterName,
                SerieId = actor.SerieId
            };
        }
        private Actor Convertir(ActorViewModel actorViewModel)
        {
            return new Actor()
            {
                ActorId = actorViewModel.ActorId,
                Name = actorViewModel.Name,
                CharacterName = actorViewModel.CharacterName,
                SerieId = actorViewModel.SerieId
            };
        }
        private static IEnumerable<ActorViewModel> Convertir(IEnumerable<Actor> actores)
        {
            List<ActorViewModel> resultado = new();

            foreach (Actor actor in actores)
            {
                resultado.Add(Convertir(actor));
            }
            return resultado;
        }
    }
}
