using c240tube.dto.request;

namespace c240tube.service.abstracts
{
    public interface IVideoService
    {
        void uploadVideo(VideoSaveRequestDto dto);

    }
}
