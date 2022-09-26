using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EFCoreInMemoryDemo.Model.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }

    }
}
