
using System;
using System.Collections.Generic;
using HeavenSchema;
using Microsoft.ServiceBus.Messaging;

namespace EventGenerator
{
    /// <summary>
    /// Send events to azure service bus queue or azure topic
    /// </summary>
    public class QuotaMessageSender
    {
        const string ServiceBusConnectionString = "Endpoint=sb://heavengo.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=I2b9811N1AgnCXTXfW6NGhfQyhd5GuqXBdIJ7c18SBM=";
        const string QueueName = "stockq";

        private static Lazy<MessagingFactory> senderMessagingFactory =
            new Lazy<MessagingFactory>(() => MessagingFactory.CreateFromConnectionString(ServiceBusConnectionString));
        
        public void SendMessage()
        {
            List<BrokeredMessage> quotaMessages = new List<BrokeredMessage>();

            QuotaMesasage message1 = new QuotaMesasage();
            message1.SourceId = "source 10";
            message1.Allowance = 10;

            QuotaMesasage message2 = new QuotaMesasage();
            message1.SourceId = "source 5";
            message1.Allowance = 5;

            QuotaMesasage message3 = new QuotaMesasage();
            message1.SourceId = "source 1";
            message1.Allowance = 1;

            quotaMessages.Add(new BrokeredMessage(message1.ToXmlStream()));
            quotaMessages.Add(new BrokeredMessage(message2.ToXmlStream()));
            quotaMessages.Add(new BrokeredMessage(message3.ToXmlStream()));

            QueueClient queueClient = senderMessagingFactory.Value.CreateQueueClient(QueueName);
            queueClient.SendBatch(quotaMessages);
        }

    }
}
