﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CartConfig.Shared
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string StatusName { get; set; }
    }
}
