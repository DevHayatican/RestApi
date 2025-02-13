using c240tube.dto.request;

namespace c240tube.service.abstracts
{
    public interface ICommentService
    {
        void AddComment(CommentSaveRequestDto dto);

    }
}
