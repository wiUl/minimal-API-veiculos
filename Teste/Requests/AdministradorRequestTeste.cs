using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.ResponseCompression;
using ProjetoAPI.Dominio.DTOs;
using ProjetoAPI.Dominio.ModelViews;
using Teste.Helpers;

namespace Teste.Requests
{
    [TestClass]
    public class AdministradorRequestTeste
    {
        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Setup.ClassInit(testContext);
        }

        [ClassCleanup]


        [TestMethod]
        public static async Task TestarRequest()
        {
            //Arrange
            var loginDTO = new LoginDTO
            {
                Email = "adm@teste.com",
                Senha = "123456"
            };

            var content = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "Application/json");

            //Act

            var response = await Setup.client.PostAsync("administradores/login", content);

            //Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var admLogado = JsonSerializer.Deserialize<AdministradorLogado>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.IsNotNull(admLogado.Perfil ?? "");
            Assert.IsNotNull(admLogado.Email ?? "");
            Assert.IsNotNull(admLogado.Token ?? "");
        }
    }
}