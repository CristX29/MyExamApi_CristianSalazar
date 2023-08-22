using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyExamApi_CristianSalazar.Models;

namespace MyExamApi_CristianSalazar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.



            builder.Services.AddControllers();

            var CnnStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("CNNSTR"));

            CnnStrBuilder.Password = "123456";
            
            string cnnstr = CnnStrBuilder.ConnectionString;

            builder.Services.AddDbContext<AnswersDBContext>(options => options.UseSqlServer(cnnstr));


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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