using c240tube.entity;

namespace c240tube.service.abstracts
{
    public interface IAdminService
    {
        void save(string name, string surname, string phone, Auth auth);

    }
}
