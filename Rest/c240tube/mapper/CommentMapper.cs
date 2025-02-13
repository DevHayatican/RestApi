using c240tube.dto.request;
using c240tube.entity;

namespace c240tube.mapper
{
    public class CommentMapper
    {
        public static Comment toComment(CommentSaveRequestDto dto)
        {
            Comment comment = new Comment();
            comment.CustomerId = dto.customerId;
            comment.VideoId = dto.videoId;
            comment.Description = dto.description;
            return comment;

        }


    }
}
