using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08.Abstraction;

namespace week08.Entities
{
    public class Car : Toy
    {
        protected override void DrawImage(Graphics g)
        {
            var image = Image.FromFile(@"Images\car.png");
            g.DrawImage(image, 0, 0, Width, Height);
         
        }
    }
}
