using Entidades;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.EntityFramework
{
    public class SerieContext : DbContext
    {
        public SerieContext(DbContextOptions<SerieContext> opciones): base(opciones) { }

        public DbSet<Actor> Actores { get; set; }
        public DbSet<Serie> Series { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
			
			List<Actor> list = new()
			{

				new Actor() { ActorId = 1, Name = "Karl Urban", CharacterName = "Billy Butcher", SerieId = 1 },
				new Actor() { ActorId = 2, Name = "Dean Norris", CharacterName = "Hughie Campbell", SerieId = 1 },
				new Actor() { ActorId = 3, Name = "Antony Starr", CharacterName = "Homelander", SerieId = 1 },
				new Actor() { ActorId = 4, Name = "Erin Moriarty", CharacterName = "Annie January", SerieId = 1 },

				new Actor() { ActorId = 5, Name = "Emma D'Arcy", CharacterName = "Rhaenyra Targaryen", SerieId = 2 },
				new Actor() { ActorId = 6, Name = "Paddy Considine", CharacterName = "Viserys Targaryen", SerieId = 2 },
				new Actor() { ActorId = 7, Name = "Olivia Cooke", CharacterName = "Alicent Hightower", SerieId = 2 },
				new Actor() { ActorId = 8, Name = "Matt Smith", CharacterName = "Daemon Targaryen", SerieId = 2 },

				new Actor() { ActorId = 9, Name = "Bryan Cranston", CharacterName = "Walter White", SerieId = 3 },
				new Actor() { ActorId = 10, Name = "Aaron Paul", CharacterName = "Jesse Pinkman", SerieId = 3 },
				new Actor() { ActorId = 11, Name = "Anna Gunn", CharacterName = "Skyler White", SerieId = 3 },
				new Actor() { ActorId = 12, Name = "Dean Norris", CharacterName = "Hank Schrader", SerieId = 3 }
			};
			modelBuilder.Entity<Actor>().HasData(list);
			
			modelBuilder.Entity<Actor>()
				.HasKey(p => p.ActorId);
			
			modelBuilder.Entity<Actor>()
			.Property(p => p.ActorId)
			.ValueGeneratedOnAdd();

			modelBuilder.Entity<Serie>().HasData(
                new Serie() { Id = 1, Titulo = "The Boys", Resumen = "The Boys está ambientada en un universo en el que los individuos superpoderosos son reconocidos como héroes por el público en general y trabajan para la poderosa corporación Vought International, que los comercializa y monetiza. Fuera de sus personajes heroicos, la mayoría son arrogantes, egoístas y corruptos." , ImagenURL="The-Boys.jpg", Temporadas = 3},
                new Serie() { Id = 2, Titulo = "House of the Dragon", Resumen = "The Targaryen dynasty is at the absolute apex of its power, with more than 10 dragons under their yoke. Most empires crumble from such heights. In the case of the Targaryens, their slow fall begins when King Viserys breaks with a century of tradition by naming his daughter Rhaenyra heir to the Iron Throne. But when Viserys later fathers a son, the court is shocked when Rhaenyra retains her status as his heir, and seeds of division sow friction across the realm. ", ImagenURL = "hotd.jpg", Temporadas = 1},
                new Serie() { Id = 3, Titulo = "Breaking Bad", Resumen = "Walter White es un frustrado profesor de química en un instituto, padre de un joven discapacitado y con su esposa embarazada. Además, trabaja en un lavadero de vehículos por las tardes. Cuando le diagnostican un cáncer pulmonar terminal se plantea qué pasará con su familia cuando él muera. En una redada de la DEA, a la cual fue invitado por su cuñado, Walt reconoce a un antiguo alumno suyo, a quien contacta para fabricar y vender metanfetamina y así asegurar el bienestar económico de su familia.", ImagenURL="breaking-bad.jpg", Temporadas = 6 }
                );

            modelBuilder.Entity<Serie>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Serie>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
			
		}
    }
}

