using Microsoft.EntityFrameworkCore;
using Redis.Business.Models;
using Redis.Infra.Context;
using Redis.Infra.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis.Infra.Service
{
    public class UsuarioService(AppDbContext context) : IUsuarioService
    {
        private readonly AppDbContext _context = context;

        public async Task<Usuario?> Login(string name)
        {
            Usuario? user = await _context.Users.Where(u => u.Name == name).SingleOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}
