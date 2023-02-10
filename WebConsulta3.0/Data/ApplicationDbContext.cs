using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebConsultaCliente2._0.Poco;

namespace WebConsulta3._0.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebConsultaCliente2._0.Poco.Contatos> Contatos { get; set; }
        public DbSet<WebConsultaCliente2._0.Poco.CadastroCliente> CadastroCliente { get; set; }
    }
}
