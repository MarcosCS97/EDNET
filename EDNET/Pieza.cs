using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace EDNET
{
    public delegate int calcPos(int x);
    public enum Direccion
    {
        izq=-1,
        abajo=0,
        der=1
    };

    abstract class Pieza
    {
        public calcPos[] calcPos=new calcPos[4];
        public GraphicsDeviceManager graphics;
        public Vector2 posic;
        public int ancho;
        public int alto;
        public int separac;
        public int tamCuad;
        public int avance;
        public int rotac=1;
        public Rectangle[] cuadrados = new Rectangle[4];
        public Color color;
        
        public Pieza(int separac, int tamCuad, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.separac = separac;
            this.tamCuad = tamCuad;
            avance = tamCuad + separac;
            posic.X = separac;
            posic.Y = separac;

            for(int i=0; i<calcPos.Length; i++)
            {
                int j = i;
                calcPos[i] = new calcPos((x) => { return (int)(0.5 + j) * separac + j * tamCuad + x; });
            }
            creaPieza();
        }
        
        /// <summary>
        /// Método que hace que la pieza se mueva hacia abajo o hacia los lados
        /// </summary>
        /// <param name="dir">Indica en qué dirección se moverá la pieza, por defecto hacia abajo</param>
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

        /// <summary>
        /// Método que crea los cuadrados que forman el tetrimino
        /// </summary>
        public virtual void creaPieza()
        {
            for(int i=0; i<cuadrados.Length; i++)
            {
                cuadrados[i] = new Rectangle(0, 0, tamCuad, tamCuad);
                
            }
            rotaPieza();
        }

        /// <summary>
        /// Método que asigna cada cuadrado a su posición relativa necesaria
        /// para formar o rotat la pieza en la posición indicada
        /// </summary>
        /// <param name="pos">Valor que indica la posición de la pieza, por defecto es 1</param>
        public virtual void rotaPieza()
        {

        }

    }
}
