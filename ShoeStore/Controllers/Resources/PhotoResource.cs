﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ShoeStore.Core.Models;

namespace ShoeStore.Controllers.Resources
{
    public class PhotoResource
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public int ColorId { get; set; }
        public string FileName { get; set; }
    }
}
