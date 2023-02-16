using AccesoDatos.EntityFramework;
using Entidades;

namespace AccesoDatos
{
	public class ActoresDatos : IActoresDatos
	{
		private SerieContext dbContext;

		public ActoresDatos(SerieContext dbContext)
		{
			this.dbContext = dbContext;
			this.dbContext.Database.EnsureCreated();
		}
	
		public void Actualizar(Actor actor)
		{
			Actor ActorDB = ObtenerActorPorId(actor.ActorId);

			ActorDB.Name = actor.Name;
			ActorDB.CharacterName = actor.CharacterName;
			ActorDB.SerieId = actor.SerieId;
			
			dbContext.Actores.Update(ActorDB);
			dbContext.SaveChanges();
		}

		public void Agregar(Actor actor)
		{
			dbContext.Actores.Add(actor);
			dbContext.SaveChanges();
		}
		public void BorrarActor(Actor actor)
		{
            dbContext.Actores.Remove(actor);
            dbContext.SaveChanges();
        }

		public IEnumerable<Actor> ObtenerActores()
		{
			var query = from n in dbContext.Actores select n;
			return query.ToList();
		}

		public IEnumerable<Actor> ObtenerActoresPorSerieId(int serieId)
		{
			var query = from n in dbContext.Actores where n.SerieId == serieId select n;
			return query.ToList();
		}

		public Actor ObtenerActorPorId(int id)
		{
			var query = from n in dbContext.Actores 
						where n.ActorId == id 
						select n;
			return query.SingleOrDefault();
		}

	}
}
