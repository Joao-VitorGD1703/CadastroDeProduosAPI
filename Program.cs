using CadastroDeProduosAPI.Models;
using CadastroDeProduosAPI.Models.Produto;
using CadastroDeProduosAPI.Repositorios.Produtos;
using CadastroDeProduosAPI.Services.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SQLitePCL;

namespace CadastroDeProduosAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Batteries.Init();
            var builder = WebApplication.CreateBuilder(args);

            // Configura o contexto do banco de dados
            builder.Services.AddDbContext<Contexto>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("ConexaoSQLite")));

            // Configura a política de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontendOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:5173") // Substitua pela URL do frontend
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            // Adiciona serviços ao contêiner
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Registro dos serviços e repositórios
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IProdutoService, ProdutoService>();
            var app = builder.Build();

            // Configura o pipeline de solicitação HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowFrontendOrigin");

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
