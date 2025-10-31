using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // 🔗 İlişki (1 role → N kullanıcı)
        public ICollection<User> Users { get; set; }
    }
}
