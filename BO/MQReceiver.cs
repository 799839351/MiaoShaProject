using Beyondbit.Framework;
using Common.Log;
using Entity;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class MQReceiver
    {

        private readonly Lazy<GoodBO> goodBO = new Lazy<GoodBO>(ProxyService.Create<GoodBO>);
        private readonly Lazy<OrderInfoBO> orderInfoBO = new Lazy<OrderInfoBO>(ProxyService.Create<OrderInfoBO>);
        private readonly Lazy<MiaoShaOrderBO> miaoShaOrderBO = new Lazy<MiaoShaOrderBO>(ProxyService.Create<MiaoShaOrderBO>);
        public void Receive(string message)
        {
            LogHelper.WriteLog("receive message:" + message);
            MiaoShaMessage mm = JsonConvert.DeserializeObject<MiaoShaMessage>(message);
            MiaoShaUser user = mm.MiaoShaUser;
            var goodId = mm.GoodId;
            var good = goodBO.Value.GetGoodById(goodId);
            var stock = good.StockCount;
            if (stock <= 0)
            {
                return;
            }
            //判断是否已经秒杀到了
            MiaoShaOrder order = miaoShaOrderBO.Value.GetMiaoshaOrderByUserIdGoodsId(user.Id, goodId);
            if (order != null)
            {
                return;
            }
            ////减库存 下订单 写入秒杀订单
            var orderInfo = orderInfoBO.Value.MiaoSha(user, good);
        }

        public void Consumer()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "RabbitMQ_Exchange", type: ExchangeType.Direct, durable: true, autoDelete: false, arguments: null);
                channel.QueueDeclare(queue: "RabbitMQ_Queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueBind(queue: "RabbitMQ_Queue", exchange: "RabbitMQ_Exchange", routingKey: "", arguments: null);

                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                    Receive(message);
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                channel.BasicConsume(queue: "RabbitMQ_Queue", autoAck: false, consumer: consumer);
                Console.ReadLine();
            }
        }

    }

}

