
using c240tube.context;
using c240tube.service.abstracts;
using c240tube.service.concrete;
using c240tube.utilty;

namespace c240tube
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<C240tube>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IStreamerService, StreamerService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IVideoService, VideoService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<JwtManager>();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
