using c240tube.entity;

namespace c240tube.service.abstracts
{
    public interface ICustomerService
    {
        void save(string name, string phone, Auth auth);
        Customer? getById(long id);

    }
}
