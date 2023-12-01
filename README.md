# EmployeesWebApi

## Цель
Веб сервис для ведения учёта сотрудников компании

## Использование

Сервис использует http и json для обмена сообщениями.

Работа с сервисом осуществляется через следующие ендпоинты:

![Pasted image 20231201184143](https://github.com/michaelenoroexe/EmployeesWebApi/assets/86874761/3040abe6-554a-4177-98c3-dc477478568b)

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
