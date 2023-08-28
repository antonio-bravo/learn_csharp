using System;
using Priority_Queue;

namespace CallCenterSimulation
{
    public class CallCenter
    {
        private int _counter = 0;
        public SimplePriorityQueue<IncomingCall> Calls { get; private set; }

        public CallCenter()
        {
            Calls = new SimplePriorityQueue<IncomingCall>();
        }

        public void Call(int clientId, bool isPriority = false)
        {
            var call = new IncomingCall
            {
                Id = ++_counter,
                ClientId = clientId,
                CallTime = DateTime.UtcNow,
                IsPriority = isPriority
            };
            Calls.Enqueue(call, isPriority ? -1 : 0);
        }

        public IncomingCall Answer(string consultant)
        {
            if (Calls.Count > 0)
            {
                var call = Calls.Dequeue();
                call.Consultant = consultant;
                call.StartTime = DateTime.UtcNow;
                return call;
            }
            return null;
        }

        public void End(IncomingCall call)
        {
            call.EndTime = DateTime.UtcNow;
        }

        public bool AreWaitingCalls()
        {
            return Calls.Count > 0;
        }
    }
}
