using System.ComponentModel.DataAnnotations;

namespace SRV.DL
{
    public class RefUserRole
    {
        [MaxLength(4)]
        [MinLength(3)]
        public string UserRoleCode { get; set; }
        public string UserRoleName { get; set; }
        public List<User> Users { get; set; }
    }
}
