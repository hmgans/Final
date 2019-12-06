using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Bot
    {
        [Key]
        public int BotID { get; set; }
        public int LevelID { get; set; } // Min time for easy access
        public String Recording { get; set; }
        public int time { get; set; }
    }
}
