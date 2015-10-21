namespace DAO.Migrations
{
    using DomainModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAO.MSSQLMTBuddiesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            //SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(MSSQLMTBuddiesContext context)
        {
            #region Adding Kongshøj and Hammerbakker
            if (!context.Tracks.Any(x => x.Name.Equals("Kongshøj")))
            {
                Ride ride1 = new Ride() 
                {
                    Author = "Peter Thomsen",
                    Comment = "Dette er en test Ride",
                    Date = DateTime.Now,                    
                };
                Ride ride2 = new Ride() 
                {
                    Author = "Johnny Johnson",
                    Comment = "Dette er også en test Ride",
                    Date = DateTime.Now,                    
                };

                IList<Ride> rides = new List<Ride>();
                rides.Add(ride1);
                rides.Add(ride2);

                Track track1 = new Track() 
                {
	                Name = "Kongshøj",
	                Map = "/Content/images/kongshoej.png",
	                Length = 7.5,
	                Difficulty = "3",
	                Direction = "cw",
	                Lat = "57.003186",
	                Lon = "9.920193",
	                Description = "MTB-ruten i Kongshøj er en begyndervenlig rute, som samtidig er attraktiv for mere garvede ryttere, der gerne vil presse sig selv mod uret.",
                    Rides = rides
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
            #endregion

            #region Adding Rold, Poulstrup and Lundby
            if (!context.Tracks.Any(x => x.Name.Equals("Poulstrup Sø")))
            {               
                Track track1 = new Track()
                {
                    Name = "Poulstrup Sø",
                    Map = "/Content/images/poulstrup.png",
                    Length = 5.7,
                    Difficulty = "5",
                    Direction = "ccw",
                    Lat = "56.973191",
                    Lon = "9.934423",
                    Description = "Ruten indeholder stejle op- og nedkørsler og kræver et grundlæggende kendskab til køreteknik. Specielt vanskelige forløb kan skæres fra ved at følge grøn markering fremfor sort og rød." 
                };
                Track track2 = new Track()
                {
                    Name = "Lundby Bakker",
                    Map = "/Content/images/lundby-bakker.png",
                    Length = 7.8,
                    Difficulty = "6",
                    Direction = "ccw",
                    Lat = "56.983499",
                    Lon = "10.002476",
                    Description = "På dele af ruten er der lavet kantsikringer, og selv rutinerede ryttere vil kunne finde rigeligt med udfordringer. En specielt teknisk og vanskelig del omkring Alsbjerg er skiltet med sort markering, mens en kort smutvej er skiltet med grøn markering."
                };

                context.Tracks.Add(track1);
                context.Tracks.Add(track2);

                context.SaveChanges();
            }

            #endregion

            #region Adding country Denmark and region Nordjylland

            if (!context.Countries.Any(x => x.Name.Equals("Danmark")))
            {
                ICollection<Region> regions = new List<Region>();
                ICollection<Track> tracks = context.Tracks.ToList();

                Region nordjylland = new Region()
                {
                    Name = "Nordjylland",
                    Tracks = tracks
                };
                
                regions.Add(nordjylland);

                Country denmark = new Country()
                {
                    Name = "Danmark",
                    Regions = regions,
                };

                context.Countries.Add(denmark);
                context.SaveChanges();
            }

            #endregion

            #region Adding region Sjælland

            if (!context.Regions.Any(x => x.Name.Equals("Sjælland")))
            {
                Region sjælland = new Region()
                {
                    Name = "Sjælland"
                };

                Country danmark = context.Countries.Include(x => x.Regions).SingleOrDefault(x => x.Name.Equals("Danmark"));
                
                danmark.Regions.Add(sjælland);

                context.SaveChanges();
            }

            #endregion
        }
    }
}
