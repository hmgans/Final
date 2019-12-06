using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class HighScore
    {
        [Key]
        public int HighScore_ID { get; set; }

        public int UserID { get; set; }

        public int LevelID { get; set; }

        public int time { get; set; }

        public String recording { get; set; }
    }
}

