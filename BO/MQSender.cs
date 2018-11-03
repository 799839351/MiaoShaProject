using Common.Log;
using Entity;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class MQSender
    {
        public void sendMiaoshaMessage(MiaoShaMessage mm)
        {
            String msg = JsonConvert.SerializeObject(mm);
            LogHelper.WriteLog("send message:" + msg);
            Produce(msg);
        }

        #region RabbitMQ
        public void Produce(string msg)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "RabbitMQ_Exchange", type: ExchangeType.Direct, durable: true, autoDelete: false, arguments: null);
                channel.QueueDeclare(queue: "RabbitMQ_Queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueBind(queue: "RabbitMQ_Queue", exchange: "RabbitMQ_Exchange", routingKey: String.Empty, arguments: null);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                var message = msg;
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "RabbitMQ_Exchange", routingKey: String.Empty, basicProperties: properties, body: body);
            }
        }


        #endregion


    }
}
