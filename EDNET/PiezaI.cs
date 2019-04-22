using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDNET
{
    class PiezaI : Pieza
    {
        public PiezaI(Point posic, int separac, int tamCuad, GraphicsDeviceManager graphics) : base(posic, separac, tamCuad, graphics)
        {
            color = Color.SkyBlue;
        }
        public override void rotaPieza()
        {
            switch (rotac)
            {
                case 1:
                    for(int i = 0; i < 4; i++)
                    {
                        cuadrados[i].Location = new Point(calcPos[i]((int)posic.X), calcPos[0]((int)posic.Y));
                    }
                    break;
                case 2:
                    for (int i = 0; i < 4; i++)
                    {
                        cuadrados[i].Location = new Point(calcPos[0]((int)posic.X), calcPos[i]((int)posic.Y));
                    }
                    break;
            }
            rotac++;
            if (rotac > 2) rotac = 1;
        }
    }
}
