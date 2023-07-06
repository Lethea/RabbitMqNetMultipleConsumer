# RabbitMqNetMultipleConsumer
This is .net 7 RabbitMq Client Implementation Sample
In this project 


RabbitMq Local  Docker Installation
---------------------------------
Download Docker From [DOCKER LINK]

You can find rabbitmq installation guide on docker [RABBIT DOCUMENT]
```
$ docker run -d --hostname my-rabbit --name some-rabbit -e RABBITMQ_DEFAULT_USER=user -e RABBITMQ_DEFAULT_PASS=password rabbitmq:3-management
```

INSTALLATION
---------------------------------
```
git clone git@github.com:Lethea/RabbitMqNetMultipleConsumer.git
```

 There is two project in solution
1. RabbitMqBase : This is RabbitMq Multiple consumer + sample producer web api
   * Listen given consumer count in appsettings json
   * Sample producer work with ProducerController basic controller 
2. Another Consumer : This is console app , you can run for test in another machine

CONFIGURATION
----------------------------------

Change Your Credentials and rabbitmq host port in appsettings.json
Change QueueName in Hosted Service. Default is TestQueue

```
 "RabbitMqConnectionInfo": {
    "Hostname": "127.0.0.1",
    "Port": 5672,
    "UserName": "admin",
    "Password": "qwe123FF",
    "ConsumerCount": 5
  }
```

![Sample Image](https://img001.prntscr.com/file/img001/KadEWt5_S2KwDd5K1Mw1rg.png)


Features
-------------
- [x] Multiple Consumer  
- [x] Producer / Consumer Sample
- [x] Consumer Base Implementation
- [x] Test
- [ ] ILogger SeriLog Implementation
- [ ] Typo Control

Contact
------------
````
Mail : emre.karatasoglu@hotmail.com
Phone / Whatsapp / Telegram : +90 532 346 67 79
Donate :   3AjEhr96KU1XsrE9rwUdpuKHaqz34WRpLb ( BTC )
           0x4DEbeE9EEdC3c9a4A38D7fae5481a9c3f0a6c88F ( ETH  ERC 20) 
````

[DOCKER LINK]:https://www.docker.com/products/docker-desktop/
[RABBIT DOCUMENT]:https://hub.docker.com/_/rabbitmq
