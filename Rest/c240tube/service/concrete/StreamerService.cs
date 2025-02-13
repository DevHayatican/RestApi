using c240tube.context;
using c240tube.entity;
using c240tube.service.abstracts;

namespace c240tube.service.concrete
{
    public class StreamerService : IStreamerService
    {
        private C240tube _context;
        public StreamerService(C240tube context)
        {
            _context = context;
        }

        public Streamer findStreamerById(long id)
        {
            return _context.Streamer.Find(id);
        }

        public void save(string name, string phone, Auth auth)
        {
            Streamer streamer = new Streamer();
            streamer.Auth = auth;
            streamer.Name = name;
            streamer.Phone = phone;
            _context.Streamer.Add(streamer);
            _context.SaveChanges();

        }
    }
}
