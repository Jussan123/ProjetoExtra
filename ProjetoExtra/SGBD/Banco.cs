using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model;
using System.Data.SqlClient;
using System.Linq;

namespace Banco
{
    public class DataBase : DbContext
    {
        public DbSet<Usuario> Users { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Sessao>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {   
                try
                {
                    string connectionAWS = GetConnectionStringAWS();
                    optionsBuilder.UseMySql(connectionAWS, ServerVersion.AutoDetect(connectionAWS));
                } catch
                {
                    Console.WriteLine("Não foi possível conectar a AWS");
                    try 
                    {
                        string connectionLocal = GetConnectionStringLocal();
                        optionsBuilder.UseMySql(connectionLocal, ServerVersion.AutoDetect(connectionLocal));
                    } catch{
                        Console.WriteLine("Não foi possível conectar ao banco de dados local");
                    }
                }

            }
        }

        public static string GetConnectionStringAWS()
        {
            string serverName = "awsjussan.cbrcalzcoxol.us-east-1.rds.amazonaws.com";
            //string serverName = "RDS MySQL";
            string databaseName = "ControleDeAcessoDeUsuarios";
            string username = "admin";
            string password = "jussan123";

            string connectionString = $"Server={serverName};Database={databaseName};User ID={username};Password={password};";

            return connectionString;
        }


        private static string GetConnectionStringLocal()
        {
            return "Server=localhost;User ID=root;Database=ControleDeAcessoDeUsuarios;";
        }
    }
}