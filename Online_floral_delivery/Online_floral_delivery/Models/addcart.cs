﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_floral_delivery.Models
{
    public class tocart
    {
        public static List<addcart> c = new List<addcart>();
    }

    public class addcart
    {
        public int? c_id;
        public int c_qty;
    }
}