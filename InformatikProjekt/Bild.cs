﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InformatikProjekt
{
    public class Bild
    {
        public double h { get; set; }
        public double w { get; set; }
        public Image Image { get; set; }

        public bool gotClicked = false;
    }
}