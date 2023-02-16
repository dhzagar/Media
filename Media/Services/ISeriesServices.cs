using Series.Models;

namespace Series.Services
{
    public interface ISeriesServices
    {
        IEnumerable<SerieViewModel> ObtenerSeriesPortada();

        SerieViewModel ObtenerSerie(int id);

        IEnumerable<SerieViewModel> ObtenerTodasLasSeries();

        void BorrarSerie(int id);

        void AgregarSerie(SerieViewModel serie);

        void ActualizarSerie(SerieViewModel serieViewModel);

    }
}
