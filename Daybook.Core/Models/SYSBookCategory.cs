﻿using System.Collections.Generic;

namespace Daybook.Core.Models
{
    public class SYSBookCategory
    {
        public string CategoryID { get; set; } 
        public string CategoryName { get; set; } //nvarchar(155)


        public ICollection<SYSBookCategoryItem> CategoryItems { get; set; }
    }
}
