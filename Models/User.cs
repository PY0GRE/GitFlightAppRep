using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        // No se guarda en BD, solo para UI - IA
        [NotMapped]
        public ImageSource? ProfileImageSource { get; set; }
        
        public ICollection<Connection> Connections { get; set; } = [];
    }
}
