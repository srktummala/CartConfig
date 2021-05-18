using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CartConfig.Shared
{
    public class Programs
    {
        [Key]
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public string Name { get; set; }
    }
}
