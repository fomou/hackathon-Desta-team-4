﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class UserTag
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long TagId { get; set; }
        public long TagPurposeId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User User { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual TagPurpose TagPurpose { get; set; }
    }
}
