## Skiing_RabbitMq

#PL:
RabbitMQ ma ExchangeType ustawiony na fanout, co oznacza, że to co opublikuje za pomocą Publishera zostanie dostarczone do wszystkich Consumerów (których mam 4, ale mogłaby być ich inna liczba, a wiadomość dostaną wszystkie).

Jest zrobiony też zapis do bazy mongoDB przez co możemy wyśledzić, że wiadomości zostały zapisane wszędzie te same.

-------------------------------------------------------------------------------------------------------------------

#ANG:
RabbitMQ has ExchangeType as fanout, which means that everything what is publish with Publisher will be deliver to every Consumer (we have 4 consumers, but the number of them could be diffrent and the message still would be delivered to all of them).

There is entry to the mongoDB database as well, beacause of which we can save the same message everwhere here.

-------------------------------------------------------------------------------------------------------------------
![image](https://user-images.githubusercontent.com/72659265/187655250-e38bca1d-a137-42f9-8675-d67dd753024b.png)

Zapis dla każdego z 4ech consumerów i 1dnego Publishera:
![image](https://user-images.githubusercontent.com/72659265/187655724-a5bf86b2-dfbb-4f25-96aa-532cfa00f67e.png)
![image](https://user-images.githubusercontent.com/72659265/187655805-f588be2d-682b-4800-9215-fa7f2f1b7559.png)
![image](https://user-images.githubusercontent.com/72659265/187655938-41c3f21d-d626-4476-94de-5d160cff5198.png)


Pokazanie działania wykresów RabbitMq dla wysyłanych danych:
![image](https://user-images.githubusercontent.com/72659265/187655004-28393608-4bc9-40cf-9807-b902f11fad0d.png)
![image](https://user-images.githubusercontent.com/72659265/187655076-796ce121-3492-4cdf-928e-f1d5e72ea8f4.png)
![image](https://user-images.githubusercontent.com/72659265/187655145-d83a60be-8324-40f6-9396-76f53a496584.png)
