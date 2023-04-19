using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Models
{
    public class PointOfInterestForCreationDto
    {
        public string Name { get; set;}
        public string? Description { get; set;}
    }
}