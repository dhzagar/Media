using AccesoDatos;
using Entidades;
using Series.Models;

namespace Series.Services
{
    public class SerieServices : ISeriesServices
    {
        public ISeriesDatos datos;
        public SerieServices(ISeriesDatos datos)
        {
            this.datos = datos;
        }
        public void ActualizarSerie(SerieViewModel serieViewModel)
        {
            datos.Actualizar(Convertir(serieViewModel));
        }

        public void AgregarSerie(SerieViewModel serie)
        {
            datos.Agregar(Convertir(serie));
        }
        public void BorrarSerie(int id)
        {
            Serie serie = datos.ObtenerSeriesPorId(id);
            datos.Borrar(serie);
        }
        public SerieViewModel ObtenerSerie(int id)
        {
            return Convertir(datos.ObtenerSeriesPorId(id));
        }

        public IEnumerable<SerieViewModel> ObtenerSeriesPortada()
        {
            return Convertir(datos.ObtenerSeriesPortada());
        }

        public IEnumerable<SerieViewModel> ObtenerTodasLasSeries()
        {
            return Convertir(datos.ObtenerTodasLasSeries());
        }
        private static SerieViewModel Convertir(Serie serie)
        {
            return new SerieViewModel()
            {
                Id = serie.Id,
                Titulo = serie.Titulo,
                ImagenURL = serie.ImagenURL,
                Resumen = serie.Resumen,
                Temporadas = serie.Temporadas,
            };
        }
        private Serie Convertir(SerieViewModel serieViewModel)
        {
            return new Serie()
            {
                Id = serieViewModel.Id,
                Titulo = serieViewModel.Titulo,
                ImagenURL = serieViewModel.ImagenURL,
                Resumen = serieViewModel.Resumen,
                Temporadas = serieViewModel.Temporadas
            };
        }

        private static IEnumerable<SerieViewModel> Convertir(IEnumerable<Serie> series)
        {
            List<SerieViewModel> resultado = new();

            foreach (Serie serie in series)
            {
                resultado.Add(Convertir(serie));
            }
            return resultado;
        }
    }
}
