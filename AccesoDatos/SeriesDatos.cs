using AccesoDatos.EntityFramework;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos
{
    public class SeriesDatos : ISeriesDatos
    {
        private SerieContext dbContext;

        public SeriesDatos(SerieContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Database.EnsureCreated();
        }

        public void Actualizar(Serie serie)
        {
			Serie SerieDB = ObtenerSeriesPorId(serie.Id);

            SerieDB.Titulo = serie.Titulo;
            SerieDB.Resumen = serie.Resumen;
            SerieDB.ImagenURL = serie.ImagenURL;
            SerieDB.Temporadas = serie.Temporadas;

            dbContext.Series.Update(SerieDB);
            dbContext.SaveChanges();
        }

        public void Agregar(Serie serie)
        {
            dbContext.Series.Add(serie);
            dbContext.SaveChanges();
        }
        public void Borrar(Serie serie)
        {
            dbContext.Series.Remove(serie);
            dbContext.SaveChanges();
        }

        public Serie ObtenerSeriesPorId(int id)
        {
            var query = from n in dbContext.Series where n.Id == id select n;

            return query.SingleOrDefault();
        }

        public IEnumerable<Serie> ObtenerSeriesPortada()
        {
            var query = from serie in dbContext.Series select serie;

            return query.Take(6).ToList();
        }

        public IEnumerable<Serie> ObtenerTodasLasSeries()
        {
            var query = from serie in dbContext.Series select serie;

            return query.ToList();
        }
    }
}