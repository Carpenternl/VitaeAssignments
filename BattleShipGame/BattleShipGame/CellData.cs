using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleShipGame
{
    public class CellData
    {
        public readonly int X;
        public readonly int Y;

        public Point Location;
        public readonly int ShipName;

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return this.GetHashCode() == obj.GetHashCode();  
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return X+Y*10;
        }
    }
}
