# EmployeesWebApi

## Цель
Веб сервис для ведения учёта сотрудников компании

## Использование

Сервис использует http и json для обмена сообщениями.

Работа с сервисом осуществляется через следующие ендпоинты:

## Описание 

Сервис работает с тремя основными сущностями:
- Компания 
- Подразделение
- Сотрудник

Которые имеют следующую структуру:

### Company
``` json
{
  "id": "int",
  "name": "string"
}
```

### Department
``` json
{
  "id": "int",
  "name": "string",
  "phone": "string"
}
```

### Employee
``` json
{
  "id": "int",
  "name": "string",
  "surname": "string",
  "phone": "string",
  "companyId": "int",
  "passport": { 
    "type": "string",
    "number": "string" 
  }, 
  "department": { 
    "name": "string",
    "phone": "string" 
  }
}
```

## Инструкция для разработки

Инфраструктуру для разработки можно поднять командой docker compose up из корневой папки проекта
