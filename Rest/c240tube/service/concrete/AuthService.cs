using c240tube.context;
using c240tube.entity.enums;
using c240tube.entity;
using c240tube.service.abstracts;
using c240tube.dto.response;
using c240tube.dto.request;
using c240tube.utilty;

namespace c240tube.service.concrete
{
    public class AuthService : IAuthService
    {

        private C240tube _context;
        private IStreamerService _streamerService;
        private IAdminService _adminService;
        private ICustomerService _customerService;
        private JwtManager _jwtManager;


        public AuthService(ICustomerService customerService, C240tube context, IStreamerService streamerService, IAdminService adminService, JwtManager jwtManager)
        {
            _context = context;
            _streamerService = streamerService;
            _adminService = adminService;
            _customerService = customerService;
            _jwtManager = jwtManager;
        }

        public void save(AuthSaveRequestDto dto)
        {
            Auth? auth1 = getAuthByEmail(dto.email);


            if (auth1 != null) // false
            {
                throw new Exception("bu maile kayıtlı biri var");
            }

            string hashPass = BCrypt.Net.BCrypt.HashPassword(dto.password);

            Auth auth = new Auth();
            auth.Email = dto.email;
            auth.Password = hashPass;
            auth.Role = (ERole)Enum.Parse(typeof(ERole), dto.role);

            _context.Auths.Add(auth);
            _context.SaveChanges();

            Auth ekliAuth = getAuthByEmail(dto.email);

            if (dto.role.Equals("ADMIN"))
            {
                _adminService.save(dto.name, dto.surname, dto.phone, ekliAuth);

            }
            else if (dto.role.Equals("STREAMER"))
            {
                _streamerService.save(dto.name, dto.phone, ekliAuth);

            }
            else if (dto.role.Equals("CUSTOMER"))
            {
                _customerService.save(dto.name, dto.phone, ekliAuth);
            }



        }

        public Auth getAuthByEmail(string mail)
        {
            Auth? auth = _context.Auths
                .FirstOrDefault(x => x.Email.Equals(mail));
            return auth;
        }

        public AuthResponseDto getAuthByEmailResponse(string email, string token)
        {
            long id = long.Parse(_jwtManager.ValidateToken(token));

            Auth a = _context.Auths.FirstOrDefault(x => x.Id == id);

            if (a == null)
            {
                throw new Exception("auth bulunamadı");
            }
            if (!a.Role.Equals("ADMIN"))
            {
                throw new Exception("yetkiniz yok");
            }

            Auth? auth = _context.Auths
                .FirstOrDefault(x => x.Email.Equals(email));

            if (auth == null)
            {
                throw new Exception("bu maile kayitli biri bulunamadi...");
            }

            AuthResponseDto authResponse = new AuthResponseDto();
            authResponse.id = auth.Id;
            authResponse.email = auth.Email;
            authResponse.createAt = auth.CreateAt;

            return authResponse;

        }

        public LoginResponseDto login(LoginRequestDto dto)
        {
            Auth auth = _context.Auths
                .FirstOrDefault(x => x.Email.Equals(dto.email));

            if (auth == null)
            {
                throw new Exception("kayitli mail adresi bulunamadi...");
            }

            if (!BCrypt.Net.BCrypt
                .Verify(dto.password, auth.Password))
            {
                throw new Exception("Yanlis Sifre");
            }
            LoginResponseDto responseDto = new LoginResponseDto();
            responseDto.token = _jwtManager.CreateToken(auth.Id);
            return responseDto;
        }
    }
}
