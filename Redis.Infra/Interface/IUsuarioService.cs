using Redis.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis.Infra.Interface
{
    public interface IUsuarioService
    {
        Task<Usuario?> Login(string name);
    }
}
