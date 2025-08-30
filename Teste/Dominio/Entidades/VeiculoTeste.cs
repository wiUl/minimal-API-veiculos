using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoAPI.Dominio.Entidades;

namespace Teste.Dominio.Entidades;


[TestClass]
public class VeiculoTeste
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange
        var veiculo = new Veiculo();

        //Act
        veiculo.Id = 1;
        veiculo.Nome = "teste";
        veiculo.Marca = "marca teste";
        veiculo.Ano = 2000;
        

        //Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("teste", veiculo.Nome);
        Assert.AreEqual("marca teste", veiculo.Marca);
        Assert.AreEqual(2000, veiculo.Ano);

    }
}
