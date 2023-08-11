# Тестовое задание

### Разработка приложения
### Задание:


Строка может содержать в себе несколько видов скобок: `()` `[]` `{}`. Необходимо реализовать приложение на `C# (.Net 6)`, принимающее на входе любую строку и определяющую
корректность расстановки скобок. Решение должно позволять подключать реализованную логику проверки к другим приложениям.


Примеры:  
* Строка: “Этот текст (строка) предназначен для тестирования [бы{стр}ой] проверки вхождения скобок {любых [из трех видов]}”, результат: `корректно`.  
* Строка: “[ ] ({}) ) [])”, результат: `не корректно`.  
* Строка: “[ { ( } ) ]”, результат: `не корректно`.  
