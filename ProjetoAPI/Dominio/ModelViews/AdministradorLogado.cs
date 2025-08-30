using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoAPI.Dominio.Enuns;

namespace ProjetoAPI.Dominio.ModelViews
{
    public record AdministradorLogado
    {
        public string Email { get; set; } = default;
        public string Perfil { get; set; } = default;
        public string Token { get; set; } = default;
    }
}