using c240tube.context;
using c240tube.entity;
using c240tube.service.abstracts;
using Microsoft.EntityFrameworkCore;

namespace c240tube.service.concrete
{
    public class AdminService : IAdminService
    {
        private C240tube _context;

        public AdminService(C240tube context)
        {
            _context = context;
        }

        public void save(string name, string surname, string phone, Auth auth)
        {
            if (surname == null)
            {
                throw new Exception("soy adi girilmeli ");
            }


            Admin admin = new Admin();
            admin.Name = name;
            admin.Surname = surname;
            admin.Phone = phone;
            admin.Auth = auth;

            _context.Admin.Add(admin);
            _context.SaveChanges();


        }
    }
}
