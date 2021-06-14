using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    class ColorTile
    {
        private bool isPrimaryColor;
        private string colorType;
        private ColorTile color1, color2;
        public ColorTile(string colorType, ColorTile color1, ColorTile color2)
        {
            this.color1 = color1;
            this.color2 = color2;
            this.colorType = colorType;
            this.isPrimaryColor = false;
        }

        public ColorTile(string colorType)
        {
            this.colorType = colorType;
            isPrimaryColor = true;
        }




    }
}
