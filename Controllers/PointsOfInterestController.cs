using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Cotrollers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c=>c.Id==cityId);
            if(city==null){
                return NotFound();
            }
            return Ok(city.PointsOfInterest);
        }
        [HttpGet("{pointofinterestid}", Name = "GetPointofinterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointofinterestid)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c=>c.Id == cityId);
            if(city==null)
            {
                return NotFound();
            }
            //find point of interest
            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p=>p.Id == pointofinterestid);
            if(pointOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }
        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointofInterest(
            int cityId, PointOfInterestForCreationDto pointOfInterest)
            {
                var city = CitiesDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == cityId);
                if(city == null)
                {
                    return NotFound();
                }
                //demo purpose - to be improved
                var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(
                    c => c.PointsOfInterest).Max(p => p.Id);
                var finalPointOfInterest = new PointOfInterestDto()
                {
                    Id = ++maxPointOfInterestId,
                    Name = pointOfInterest.Name,
                    Description = pointOfInterest.Description
                };
                city.PointsOfInterest.Add(finalPointOfInterest);
                return CreatedAtRoute("GetPointOfInterest", 
                new
                {
                    cityId = cityId,
                    pointOfInterestId = finalPointOfInterest.Id
                },
                finalPointOfInterest
                );
            }
    }
}