namespace DAO.Migrations
{
    using DomainModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAO.MTBuddiesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAO.MTBuddiesContext context)
        {

            if (!context.Tracks.Any(x => x.Name.Equals("Kongshøj")))
            {
                Track track1 = new Track() 
                {
	                Name = "Kongshøj",
	                Map = "/Content/images/kongshoej.png",
	                Length = 7.5,
	                Difficulty = "3",
	                Direction = "cw",
	                Lat = "57.003186",
	                Lon = "9.920193",
	                Description = "MTB-ruten i Kongshøj er en begyndervenlig rute, som samtidig er attraktiv for mere garvede ryttere, der gerne vil presse sig selv mod uret."
	            };
                Track track2 = new Track()
                {
                    Name = "Hammer bakker",
                    Map = "/Content/images/hammer-bakker.png",
                    Length = 13,
                    Difficulty = "4",
                    Direction = "ccw",
                    Lat = "57.122455",
                    Lon = "10.024561",
                    Description = "Sporet Hammer bakker er en tur for de øvede ryttere. Det er en smuk, men hård rute igennem kuperet skov. Der er garanti for sved på panden!"
                };
                
                context.Tracks.Add(track1);
                context.Tracks.Add(track2);

                context.SaveChanges();
            }            
        }
    }
}
