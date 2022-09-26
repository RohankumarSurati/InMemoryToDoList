using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EFCoreInMemoryDemo.Model.Entities
{
    public class Task
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required, MaxLength(2000)]
        public string Description { get; set; }

        [DisplayName("Update Description")]
        [Required, MaxLength(2000)]
        public string UpdateDescription { get; set; }

        [DisplayName("Updated On")]
        public string UpdateOn { get; set; }
        public bool Done { get; set; }
    }
}
