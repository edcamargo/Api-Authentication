using Authentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace Authentication.Repository.Context
{
    public class AuthContext : DbContext
    {
        #region Objetos

        public DbSet<Company> Companies { get; set; }
        public DbSet<Users> Users{ get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<GroupUsers> GroupsUsers { get; set; }

        #endregion

        public AuthContext()
        { }

        /// <summary>
        /// Seta o tempo de resposta do banco de dados
        /// </summary>
        /// <param name="options"></param>
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
            this.Database.SetCommandTimeout(180);
        }

        /// <summary>
        /// Recupera a conexão com banco de dados
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();               

            optionsBuilder.UseMySQL(config.GetSection("ConnectionStrings")["DefaultConnection"]);

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Sobreescreve o método SaveChanges.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            SetaDataInclusao();

            return base.SaveChanges();
        }

        /// <summary>
        /// Verifica se existe a propriedade Data_Inclusao, caso ela exista e se trate de uma inserção de registro o campo recebe a data e horários atuais.
        /// </summary>private void SetaDataInclusao()
        private void SetaDataInclusao()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateInclude") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateInclude").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateInclude").IsModified = false;
                }
            }
        }
    }
}
