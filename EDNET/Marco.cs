using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDNET
{
    class Marco
    {

        public Color colBorde;
        public Color colFondo;
        public Rectangle marco;
        public Rectangle contenedor;
        public string texto;
        public Marco(Point posic, int ancho, int alto, int borde, Color colBorde, Color colFondo, string texto="")
        {
            this.texto = texto;
            this.colBorde = colBorde;
            this.colFondo = colFondo;
            contenedor = new Rectangle(posic.X, posic.Y, ancho, alto);
            marco = new Rectangle(posic.X - borde, posic.Y - borde, ancho + (2 * borde), alto + (2 * borde));
        }
        
    }
}
