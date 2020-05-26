# Producer Consumer RabbitMQ
Small app just showing how to send a message and how to consume it thru RabbitMQ

This is a console app c# .net core 3.1 using RabbitMQ 3.8.4 (Windows 10 and Visual Studio 2019 Community)

First thing, if you do not have Erlang installed, you need to do it. For this example it was used Erlang 23.0 (erlang.org/downloads).
After install Erlang, it's time to install RabbitMQ 3.8.4 (https://www.rabbitmq.com/download.html).

RabbitMQ will run in the http://localhost:15672/#/

Initially if did not work, check if service is up running.
Windows -> services.msc (Service RabbitMQ)
You can also use command line to start RabbitMQ Service, please check it in RabbitMQ Documentation.

Normally it's not showing the app in the page mentioned above
Go to Menu and find RabbitMQ Command Prompt and execute the command -> *rabbitmq-plugins enable rabbitmq_management*

After that you will be able to see the **RabbitMQ Management page.**

Open your Visual Studio.
Use can use this project but if you want to create from scratch follow steps below:
Create a solution
Create 2 c# core console apps inside the solution (one will be used to be the sender and the other one consumer)
Add nuget package RabbitMQ.Client in both console apps
Use the code provided here in the projects.
Basically it's that.
