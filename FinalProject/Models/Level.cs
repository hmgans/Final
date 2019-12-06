using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Level
    {
        [Key]
        public int LevelID { get; set; }
        public String BackGroundImage { get; set; }
        public String LevelObsticles { get; set; }

    }
}
