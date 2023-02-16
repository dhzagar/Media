using Entidades;
using Series.Models;

namespace Series.Services
{
    public interface IActoresServices
    {
        IEnumerable<ActorViewModel> ObtenerActores(int id);
        IEnumerable<ActorViewModel> ObtenerTodosLosActores();
        ActorViewModel ObtenerActor(int id);
        void BorrarActor(int id);
        void AgregarActor(ActorViewModel actor);
        void ActualizarActor(ActorViewModel actorViewModel);
    }
}
