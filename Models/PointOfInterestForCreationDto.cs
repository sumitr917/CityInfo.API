using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required(ErrorMessage = "You should provide a name")]
        [MaxLength(50)]
        public string Name { get; set;} = string.Empty;
        [MaxLength(200)]
        public string? Description { get; set;}
    }
}