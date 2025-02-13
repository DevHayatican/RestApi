using c240tube.dto.request;
using c240tube.service.abstracts;
using Microsoft.AspNetCore.Mvc;

namespace c240tube.Controllers
{
    [ApiController]
    [Route("/video")]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }


        [HttpPost("upload")]
        public void save([FromBody] VideoSaveRequestDto dto)
        {
            _videoService.uploadVideo(dto);
        }

    }
}
