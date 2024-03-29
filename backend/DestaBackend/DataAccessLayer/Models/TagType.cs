﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Models
{
    public class TagType
    {
        public long Id { get; set; }
        public string Name { get; set; }  //What | Why
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual IList<Tag> Tags { get; set; } = new List<Tag>();
    }
}
