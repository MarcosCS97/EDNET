using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDNET
{
    class PiezaS : Pieza
    {
        public PiezaS(Point posic, int separac, int tamCuad, GraphicsDeviceManager graphics) : base(posic, separac, tamCuad, graphics)
        {
            color = Color.SpringGreen;
        }
        public override void rotaPieza()
        {
            int cont = 0;
            switch (rotac)
            {
                case 1:
                    for (int i = 1; i < 3; i++)
                    {
                        cuadrados[cont].Location = new Point(calcPos[i]((int)posic.X), calcPos[0]((int)posic.Y));
                        cont++;
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        cuadrados[cont].Location = new Point(calcPos[i]((int)posic.X), calcPos[1]((int)posic.Y));
                        cont++;
                    }
                    break;
                case 2:
                    for (int i = 1; i >= 0; i--)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            cuadrados[cont].Location = new Point(calcPos[i]((int)posic.X), calcPos[i + j]((int)posic.Y));
                            cont++;
                        }
                    }
                    break;
            }
            rotac++;
            if (rotac > 2) rotac = 1;
        }
    }
}
