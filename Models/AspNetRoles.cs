using System.ComponentModel;

namespace Capstone.Models
{
    public class AspNetRoles
    {
        [DisplayName("Role")]
        public int Role { get; set; }

        [DisplayName("Permissions")]
        public int Permissions { get; set; }
    }
}
