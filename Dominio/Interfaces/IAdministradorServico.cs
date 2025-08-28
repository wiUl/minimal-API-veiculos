using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoAPI.Dominio.DTOs;
using ProjetoAPI.Dominio.Entidades;

namespace ProjetoAPI.Dominio.Interfaces
{
    public interface IAdministradorServico
    {
        Administrador? Login(LoginDTO loginDTO); 
    }
}