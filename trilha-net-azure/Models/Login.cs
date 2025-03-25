using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace trilha_net_azure.Models
{
    public class Login
    {
        [EmailAddress]
        public string Email { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
