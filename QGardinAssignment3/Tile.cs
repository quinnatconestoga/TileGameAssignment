/*  QGardinAssignment3.cs
 *  
 *  Tile class used for N-Tile Game.
 *  
 *  Revision History:
 *      Quinn Gardin, 2017.11.30: Created
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QGardinAssignment3
{

    /// <summary>
    /// Main Tile Class, Child class of Button
    /// </summary>
    public class Tile : Button
    {
        int tileValue;

        int tilePosX;
        int tilePosY;


        /// <summary>
        /// Default Constructor
        /// </summary>
        public Tile()
        {
            tileValue = 0;
        }


        /// <summary>
        /// Constructor With Value Parameter
        /// </summary>
        /// <param name="valueSet"></param>
        public Tile(int valueSet)
        {
            tileValue = valueSet;
        }


        /// <summary>
        /// Tile Value Setter
        /// </summary>
        /// <param name="value"></param>
        public void setTileValue (int value)
        {
            tileValue = value;
        }


        /// <summary>
        /// Tile Value Getter
        /// </summary>
        /// <returns></returns>
        public int getTileValue()
        {
            return tileValue;
        }


        /// <summary>
        /// Tile X Position Setter
        /// </summary>
        /// <param name="x"></param>
        public void setTilePosX(int x)
        {
            tilePosX = x;
        }


        /// <summary>
        /// Tile Y Position Setter
        /// </summary>
        /// <param name="y"></param>
        public void setTilePosY(int y)
        {
            tilePosY = y;
        }


        /// <summary>
        /// Tile X Position Getter
        /// </summary>
        /// <returns></returns>
        public int getTilePosX()
        {
            return tilePosX;
        }


        /// <summary>
        /// Tile Y Position Getter
        /// </summary>
        /// <returns></returns>
        public int getTilePosY()
        {
            return tilePosY;
        }


        /// <summary>
        /// Tile Value Getter String Return
        /// </summary>
        /// <returns></returns>
        public string getValueString()
        {
            return tileValue.ToString();
        }

    }
}
