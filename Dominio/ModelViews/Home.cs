using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI.Dominio.ModelViews
{
    public struct Home
    {
        public string Mensagem{ get => "Bem Vindo a API de Veiculos";}
        public string Documentacao { get => "/swagger"; }
    }
}