using ECommons.DalamudServices;
using ECommons.Throttlers;


namespace SamplePlugin.Tasks
{
    public class DeliveroTask() : IBaseTask
    {
        public unsafe bool? Run() 
        {
            if (!deliveroo.IsTurnInRunning()) 
            {
                if (EzThrottler.Throttle("Delivero", 1000))
                {
                    Svc.Commands.ProcessCommand("/deliveroo enable");
                    return true;
                }
            }
            return false;
        }
    }
}
