using System;
using EventGenerator;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("QuotaGeneration")]
        public static void Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            QuotaMessageSender sender = new QuotaMessageSender();

            sender.SendMessage();

            log.Info("successfully append quota event");
        }
    }
}
