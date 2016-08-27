using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManager.Domain.Entities
{
    [Table("users")]
    public class User
    {
        public int ID { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string EmailConfirmed { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public DateTime AccountCreationTS { get; set; }
    }
}
