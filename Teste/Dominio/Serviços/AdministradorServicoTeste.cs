using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ProjetoAPI.Dominio.Entidades;
using ProjetoAPI.Dominio.Serviços;
using ProjetoAPI.Infraestrutura.DB;

namespace Teste.Dominio.Serviços
{
    [TestClass]
    public class AdministradorServicoTeste
    {
        private DbContexto CriarContextoDeTeste()
        {
            var assemblypath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblypath ?? "", "..", "..", ".."));
            var builder = new ConfigurationBuilder()
            .SetBasePath(path)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);

        }

        [TestMethod]
        public void TestarCriarAdministrador()
        {
            //Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
            var adm = new Administrador();
            adm.Id = 1;
            adm.Email = "teste@teste.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";

            var administradorServico = new AdministradorServico(context);

            //Act
            administradorServico.Incluir(adm);


            //Assert
            Assert.AreEqual(1, administradorServico.Todos(1).Count());

        }
        
        public void TestarBuscarAdministrador()
        {
            //Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
            var adm = new Administrador();
            adm.Id = 1;
            adm.Email = "teste@teste.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";
            
            var administradorServico = new AdministradorServico(context);

            //Act
            administradorServico.Incluir(adm);
            var admin = administradorServico.BuscaPorId(adm.Id);


            //Assert
            Assert.AreEqual(1, admin?.Id);

        }
    }
}