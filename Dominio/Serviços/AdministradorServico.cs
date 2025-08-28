using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoAPI.Dominio.DTOs;
using ProjetoAPI.Dominio.Entidades;
using ProjetoAPI.Dominio.Interfaces;
using ProjetoAPI.Infraestrutura.DB;

namespace ProjetoAPI.Dominio.Serviços
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;
        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }
        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();

            return adm;
            
            
        }
    }
}