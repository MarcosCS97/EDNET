using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDNET
{
    class PiezaO:Pieza
    {
        public PiezaO(int separac, int tamCuad, GraphicsDeviceManager graphics) : base(separac, tamCuad, graphics)
        {
            color = Color.Yellow;
        }
        public override void rotaPieza()
        {
            int cont = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    cuadrados[cont].Location = new Point(calcPos[j]((int)posic.X), calcPos[i]((int)posic.Y));
                    cont++;
                }
            }
            ancho = 2 * (separac + tamCuad);
            alto = 2 * (separac + tamCuad);
        }
    }
}
