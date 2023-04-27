using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Cotrollers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly IMailService _mailSerive;
        private readonly CitiesDataStore _citiesDataStore;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger,
        IMailService mailService, CitiesDataStore citiesDataStore)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailSerive = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _citiesDataStore = citiesDataStore ?? throw new ArgumentNullException(nameof(citiesDataStore));
        }
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            try
            {
                var city = _citiesDataStore.Cities.FirstOrDefault(c=>c.Id==cityId);
                if(city==null){
                    _logger.LogInformation("City with city Id {0} was not found.",cityId);
                    return NotFound();
                }
                return Ok(city.PointsOfInterest);
            }
            catch(Exception ex)
            {
                _logger.LogCritical($"Exception while getting points of interest for city with id {cityId}.", ex);
                return StatusCode(500, "A problem while handling your request");
            }
            
        }
        [HttpGet("{pointofinterestid}", Name = "GetPointofinterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointofinterestid)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c=>c.Id == cityId);
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
                var city = _citiesDataStore.Cities
                .FirstOrDefault(c => c.Id == cityId);
                if(city == null)
                {
                    return NotFound();
                }
                //demo purpose - to be improved
                var maxPointOfInterestId = _citiesDataStore.Cities.SelectMany(
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
        [HttpPut("{pointofinterestid}")]
        public ActionResult UpdatePointOfInterest(int cityId, int pointofinterestid, 
        PointOfInterestForUpdateDto pointOfInterest)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }
            var pointOfInterestToBeUpdated = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointofinterestid);
            if(pointOfInterestToBeUpdated == null)
            {
                return NotFound();
            }
            pointOfInterestToBeUpdated.Name = pointOfInterest.Name;
            pointOfInterestToBeUpdated.Description = pointOfInterest.Description;

            return Ok();
        }
        [HttpPatch("{pointofinterestid}")]
        public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointofinterestid,
        JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }
            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointofinterestid);
            if(pointOfInterest == null)
            {
                return NotFound();
            }
            var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
            {
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };
            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!TryValidateModel(pointOfInterestToPatch))
            {
                return BadRequest(ModelState);
            }

            pointOfInterest.Name = pointOfInterestToPatch.Name;
            pointOfInterest.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }

        [HttpDelete("{pointofinterestid}")]
        public ActionResult DeletePointOfInterest(int cityId, int pointofinterestid)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }
            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointofinterestid);
            if(pointOfInterest == null)
            {
                return NotFound();
            }
            city.PointsOfInterest.Remove(pointOfInterest);
            _mailSerive.Send(
                "Point of interest deleted.",
                $"Point of interest {pointOfInterest.Name} with id {pointOfInterest.Id} was deleted."
            );
            return NoContent();
        }

    }
}