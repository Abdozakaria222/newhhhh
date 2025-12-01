using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace DNSOptimizer
{
    public class DnsTester
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long ResponseTime { get; private set; }

        public async Task<long> TestAsync()
        {
            try
            {
                var ping = new Ping();
                var reply = await ping.SendPingAsync(Address, 1500);
                ResponseTime = reply.Status == IPStatus.Success ? reply.RoundtripTime : 9999;
            }
            catch
            {
                ResponseTime = 9999;
            }

            return ResponseTime;
        }
    }
}
