using Beyondbit.Framework;
using BO;
using Common.Cache;
using Entity;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        #region 声明变量
        private static readonly Lazy<MiaoShaGoodBO> _lazyMiaoShaGoodBO = null;

        static Program()
        {
            _lazyMiaoShaGoodBO = new Lazy<MiaoShaGoodBO>(ProxyService.Create<MiaoShaGoodBO>);
        }

        public static MiaoShaGoodBO MiaoShaGoodBO
        {
            get { return _lazyMiaoShaGoodBO.Value; }
        }
        private static RedisCacheWriter cache = new RedisCacheWriter();
        
        #endregion

        static void Main(string[] args)
        {
            #region RabbitMQ
            var type = Console.ReadLine();

            if (type == "PRODUCER")
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "RabbitMQ_Exchange", type: ExchangeType.Direct, durable: true, autoDelete: false, arguments: null);
                    channel.QueueDeclare(queue: "RabbitMQ_Queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
                    channel.QueueBind(queue: "RabbitMQ_Queue", exchange: "RabbitMQ_Exchange", routingKey:"", arguments: null);

                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    for (var i = 0; i < 500; i++)
                    {
                        var message = i.ToString();
                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(exchange: "RabbitMQ_Exchange", routingKey:"", basicProperties: properties, body: body);
                        Console.WriteLine(message);
                    }
                    Console.ReadLine();
                }
            }

            if (type == "CONSUMER")
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

                        //Thread.Sleep(200);

                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    };
                    channel.BasicConsume(queue: "RabbitMQ_Queue", autoAck: false, consumer: consumer);
                    Console.ReadLine();
                }
            }
            #endregion

            #region 把秒杀的数据写入缓存数据库
            //var list = MiaoShaGoodBO.GetAll();
            //foreach (var item in list)
            //{
            //    cache.AddCache("GoodId" + item.GoodId, item.StockCount);
            //}
            #endregion


            Console.ReadKey();
        }
    }
}
