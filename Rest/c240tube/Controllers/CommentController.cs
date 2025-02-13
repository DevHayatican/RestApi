using c240tube.dto.request;
using c240tube.service.abstracts;
using Microsoft.AspNetCore.Mvc;

namespace c240tube.Controllers
{
    [ApiController]
    [Route("comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpPost("save")]
        public void save(CommentSaveRequestDto dto)
        {
            _commentService.AddComment(dto);
        }

    }
}
