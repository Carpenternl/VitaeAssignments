using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    public class ShipYard
    {
        public enum VesselClass { Scout, Submarine,Frigate,Carrier}
        private int[] AvailableVessels = { 4, 3, 2, 1 };
        private int[] VesselSizes = { 2, 3, 4, 5 };

        public ShipYard()
        {
        }

        public void Build(VesselClass VesselType)
        {
            //
        }
    }
}
