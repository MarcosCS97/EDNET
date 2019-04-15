using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace EDNET
{
    public enum Direccion
    {
        izq=-1,
        abajo=0,
        der=1
    };

    abstract class Pieza
    {
        GraphicsDeviceManager graphics;
        Vector2 posic;
        int ancho;
        int alto;
        int separac;
        int tamCuad;
        int avance;
        int rotac;
        Rectangle[] cuadrados = new Rectangle[4];
        
        public Pieza(int separac, int tamCuad, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.separac = separac;
            this.tamCuad = tamCuad;
            posic.X = graphics.PreferredBackBufferWidth/2;
            posic.Y = -separac*2;
            creaPieza();
        }

        public virtual void mueveRect(Direccion dir = Direccion.abajo)
        {
            switch (dir)
            {
                case Direccion.abajo:
                    for(int i=0; i<cuadrados.Length;i++)
                    {
                        cuadrados[i].Y += avance;
                    }
                    break;
                case Direccion.izq:
                case Direccion.der:
                    for(int i=0; i < cuadrados.Length; i++)
                    {
                        cuadrados[i].X += (avance * (int)dir);
                    }
                    break;
            }
        }

        public virtual void creaPieza()
        {
            for(int i=0; i<cuadrados.Length; i++)
            {
                cuadrados[i] = new Rectangle(0, 0, tamCuad, tamCuad);
            }
            rotaPieza();
        }

        public abstract void rotaPieza(int pos = 1);

    }
}
