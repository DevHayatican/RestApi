using c240tube.entity;

namespace c240tube.service.abstracts
{
    public interface IStreamerService
    {
        void save(string name, string phone, Auth auth);
        Streamer findStreamerById(long id);

    }
}
