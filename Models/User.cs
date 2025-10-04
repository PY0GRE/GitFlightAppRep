using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class User
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; } = string.Empty;
        public byte[]? ProfileImage { get; set; } 
        public string PasswordHash { get; set; } = string.Empty;
        public ICollection<Connection> Connections { get; set; } = [];
    }
}
