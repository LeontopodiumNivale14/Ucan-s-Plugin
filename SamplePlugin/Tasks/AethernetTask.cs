using ECommons.Throttlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePlugin.Tasks
{
    public class AethernetTask(int territoryId,string aethername) : IBaseTask
    {
        public unsafe bool? Run()
        {
            if (GetZoneID() == territoryId)
                return true; // already in correct zone
            else
            {
                if (!Lifestream.IsBusy())
                {
                    if (EzThrottler.Throttle("Teleporting", 4000))
                    {
                        Lifestream.ExecuteCommand(aethername);
                    }
                }
                return false; ;
            }
        }
    }
}
