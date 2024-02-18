
using Redis.Business.Auth;

namespace Redis.Business.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int IdPermission { get; set; } = ((int)Permission.Default);

    }
}
