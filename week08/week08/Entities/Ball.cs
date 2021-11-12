﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week08.Abstraction;

namespace week08.Entities
{
    public class Ball : Toy
    {
     

        protected override void DrawImage(Graphics g)
        {
            var ecset = new SolidBrush(Color.Blue);
            g.FillEllipse(
              ecset,
              0,
              0,
              Width,
              Height
                );  
        }

    
    }
}
