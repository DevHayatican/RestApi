using c240tube.context;
using c240tube.dto.request;
using c240tube.entity;
using c240tube.service.abstracts;
using c240tube.utilty;

namespace c240tube.service.concrete
{
    public class VideoService : IVideoService
    {
        private readonly C240tube _context;
        private readonly IStreamerService _streamerService;
        private readonly JwtManager _jwtManager;
        public VideoService(C240tube context, IStreamerService streamerService, JwtManager jwtManager)
        {
            _context = context;
            _streamerService = streamerService;
            _jwtManager = jwtManager;
        }
        public void uploadVideo(VideoSaveRequestDto dto)
        {
            long id = long.Parse(_jwtManager.ValidateToken(dto.token));

            Auth auth = _context.Auths.FirstOrDefault(auth => auth.Id == id);

            if (auth == null || !auth.Role.Equals("STREAMER"))
            {
                throw new Exception("yetkisiz giris....");
            }

            Streamer streamer = _context.Streamer.FirstOrDefault(x => x.Auth == auth);

            Video video = new Video();
            video.Range = dto.Range;
            video.Title = dto.Title;
            video.Url = dto.Url;



            video.Streamer = streamer;

            _context.Video.Add(video);
            _context.SaveChanges();

        }



    }
}
