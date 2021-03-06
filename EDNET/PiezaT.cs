﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDNET
{
    class PiezaT : Pieza
    {
        public PiezaT(Point posic, int separac, int tamCuad, GraphicsDeviceManager graphics) : base(posic, separac, tamCuad, graphics)
        {
            color = Color.Purple;
        }
        public override void rotaPieza()
        {
            switch (rotac)
            {
                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        cuadrados[i].Location = new Point(calcPos[i]((int)posic.X), calcPos[1]((int)posic.Y));
                    }
                    cuadrados[3].Location = new Point(calcPos[1]((int)posic.X), calcPos[0]((int)posic.Y));
                    break;
                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        cuadrados[i].Location = new Point(calcPos[1]((int)posic.X), calcPos[i]((int)posic.Y));
                    }
                    cuadrados[3].Location = new Point(calcPos[0]((int)posic.X), calcPos[1]((int)posic.Y));
                    break;
                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        cuadrados[i].Location = new Point(calcPos[i]((int)posic.X), calcPos[0]((int)posic.Y));
                    }
                    cuadrados[3].Location = new Point(calcPos[1]((int)posic.X), calcPos[1]((int)posic.Y));
                    break;
                case 4:
                    for (int i = 0; i < 3; i++)
                    {
                        cuadrados[i].Location = new Point(calcPos[0]((int)posic.X), calcPos[i]((int)posic.Y));
                    }
                    cuadrados[3].Location = new Point(calcPos[1]((int)posic.X), calcPos[1]((int)posic.Y));
                    break;
            }
            rotac++;
            if (rotac > 4) rotac = 1;
        }
        public override void restauraRotac()
        {
            for(int i=0;i<2;i++){
                rotac--;
                if(rotac<=0)rotac=4;
            }
            rotaPieza();
        }
    }
}
