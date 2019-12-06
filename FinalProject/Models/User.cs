using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public String Email { get; set; }
        public String Role { get; set; }
        public String UserName { get; set; }
        public int CurrentLevel { get; set; } // Up to this level is unlocked
        public int NosContainers { get; set; }
        public int Cash { get; set; }


        /* This is the store section */
        public bool Nos { get; set; }

        public bool SkinRed { get; set; }
        public bool SkinBlue { get; set; }
        public bool SkinGreen { get; set; }
        public bool SkinPurple { get; set; }
        public bool SkinChrome { get; set; }
    }
}
