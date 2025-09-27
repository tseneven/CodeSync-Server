# Основная информация
CodeSync Client - CRM-система для программистов с большим функционалом с формате мобильного приложения. 
Данный репозиторий содержит серверную часть приложения.
[Клиентская часть](https://github.com/tseneven/CodeSync-Client)

# Стек технологий
Сервер написанный на C# с использованием Entity Framework Core, AspNet Core, Jwt Bearer и My Sql

# Архитектура

```
Application/DTO             # Data Transfer Object

Domain/                     # Бизнес-логика

Infrastructure/             # Инфраструктура
│
├── Entities/               # Модели данных для миграции
├── Migration/              # Миграция
└── Repositorys/            # ORM и интерфейсы

Migrations/                 # Кэш миграции

Web/
│
├── Controllers/            # Контроллеры
└── Middleware/             # Мидделваре


```

# Документация
[Тык](https://drive.google.com/drive/folders/1XD7Qr-lko32kdyc2H8am07eKxcx4DfWZ?usp=sharing)
# Запуск 
Через точку входа main или 
Дай бог через exe или Docket =)

