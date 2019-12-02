using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComManager.Models
{
    public class Computer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Processor { get; set; }
        public int OperatingMemory { get; set; }
        public double LocalDriveSize { get; set; }
        public bool FlaggedAsBroken { get; set; }
        public Room Room { get; set; } // shadow property
        public int RoomId { get; set; } // navigation property
    }
}
