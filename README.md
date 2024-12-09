# ReviewsWebApplication
## Описание
Микросервис на C# ASP.NET CORE для управления отзывами о продуктах посредством HTTP-запросов REST API.</br>
Текущяя реализация появилась в результате рефакторинга исходного микросервиса.

## Технологии
1. ASP.NET CORE WebApi
2. MsSQL
3. Entity Framework Core
4. Linq
5. JWT bearer-based authentication
6. Automapper
7. Swagger, Postman
8. Хеширование данных с использованием алгоритма хеширования Argon2 ([Konscious.Security.Cryptography.Argon2](https://github.com/kmaragon/Konscious.Security.Cryptography))

## Работа с API
Для работы с приложением необходимо авторизоваться под зарегистрированным логином и получить токен.

Для авторизованных клиентов доступна работа с отзывами:
- Получение отзыва по индентификатору; 
- Получение отзывов по идентификатору продукта;
- Добавление отзыва к продукту;
- Удаление отзыва по идентификатору.

Работу с API также можно осуществлять через Swagger.

![image](https://github.com/user-attachments/assets/be5ba423-6a07-445b-97ab-babd2239c7d5)


## Установка и настройка
Для работа приложения достаточно иметь установленный MS SQL Server.

Дополнительно можно настроить:
1. Подключение к базе данных MsSQL в файле `appsettings.json`
2. Начальные данные администратора  в файле `appsettings.json` в секции `AdminSettings`
```
  "AdminSettings": {
    "Login": "admin",
    "Password": "Qwerty123!"
  }
```
3. Путь до xml-документации:
![image](https://github.com/user-attachments/assets/c1761433-6182-448e-8683-dff25a0f0ec7)

## Структура каталога решения
![image](https://github.com/user-attachments/assets/f3bb4763-16c2-481d-b2ff-f43d37974704)



