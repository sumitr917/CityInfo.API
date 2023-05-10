using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Cotrollers
{
    [Authorize]
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(
            FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
            {
                _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
                    ?? throw new System.ArgumentNullException(
                        nameof(fileExtensionContentTypeProvider)
                    );
            }
        
        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            //look for file by fileId
            //demo
            var pathToFile = "files/AZ-900 exam self-serve guide.pdf";

            //check whether the file exists
            if(!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            if(!_fileExtensionContentTypeProvider.TryGetContentType(
                pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);

            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}