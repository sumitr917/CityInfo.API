using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Models
{
    public class PointOfInterestForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a name")]
        [MaxLength(50)]
        public string Name { get; set;}
        [MaxLength(200)]
        public string? Description { get; set;}
    }
}