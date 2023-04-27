using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities {get; set;}
        //public static CitiesDataStore Current {get;} = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Banaras",
                    Description = "The Land Of Lord Shiva.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Kashi Vishwanath Temple",
                            Description = "One of 12 Jyotirlingas of Lord Shiva"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Dasashwamedha Ghat",
                            Description = "One of the ghats on Holy Ganges"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Patna",
                    Description = "Earlier called as Patliputra.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Mahavir Temple",
                            Description = "Famous temple of Lord Hanuman at Patna junction"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Gandhi Maidan",
                            Description = "Large ground for gatherings, festivals"
                        }
                    }

                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Pune",
                    Description = "One of the Famous IT Hubs in India",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 5,
                            Name = "Hinjewadi",
                            Description = "Full of offices of IT companies"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "Koregaon Park",
                            Description = "The go to party and enjoyment place"
                        }
                    }    
                }
            };       
        }
    }
}