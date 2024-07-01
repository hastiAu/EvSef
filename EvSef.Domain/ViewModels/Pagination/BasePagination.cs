﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.Pagination
{
    public class BasePagination
    {

        public int PageId { get; set; }
        public int TakeEntity { get; set; }
        public int SkipEntity { get; set; }
        public int AllEntitiesCount { get; set; }
        public int AllPageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public BasePagination()
        {
            PageId = 1;
            TakeEntity = 15;
        }
    }
}
