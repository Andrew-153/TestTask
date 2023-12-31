
### Разработка приложения
### Задание:


Строка может содержать в себе несколько видов скобок: `()` `[]` `{}`. Необходимо реализовать приложение на `C# (.Net 6)`, принимающее на входе любую строку и определяющую
корректность расстановки скобок. Решение должно позволять подключать реализованную логику проверки к другим приложениям.


Примеры:  
* Строка: “Этот текст (строка) предназначен для тестирования [бы{стр}ой] проверки вхождения скобок {любых [из трех видов]}”, результат: `корректно`.  
* Строка: “[ ] ({}) ) [])”, результат: `не корректно`.  
* Строка: “[ { ( } ) ]”, результат: `не корректно`.  




## Описание логики работы проекта

Данное приложение написано при использовании языка C# 7.3 и фреймворка .NET Framework 4.8.

Логика работы приложения следующая:
Входная точкой приожения является проект `ConsoleApp_IsCorrectPlaceBrackets`, класс `Programm.cs`  
В данном классе пользователь вводит текст, который необходимо проверить, после чего происходит вызов метода `CheckCorrectBrackets` из пространства имём `IsCorrectPlaceBrackets_Task`.

Логика вся логика проверки приложения реализована в проекте `TextProcessor`, в классе `IsCorrectPlaceBrackets_Task`. Данный реализован как библиотека классов, для
возможности интеграции с другие проекты, а также вынесен в отельный проект/класс с более удобного тестирования.  
В данном классе реализован метод `CheckCorrectBrackets`, который проверяет в тексте скобки и если находит открывающуюсу скобку, то делает ещё раз проверку в граница
`startIndex` - это найденная открывающаяся скобка,  `endIndex` - это найденная закрывающася скобка, для ранее найденной открывающейся скобки.   


Метод учитывает следующие случаи:  
1. Если найдена открывающаяся скобка, но не найдена для неё пара закрывающейся скобки
2. Если найдена только закрывающася скобка
3. Если в метод `CheckCorrectBrackets` аргументом переданая пустая строка или null.


Также добавлен проект UnitTest, для тестирования метода `CheckCorrectBrackets` из класса `IsCorrectPlaceBrackets_Task`

## UPD

Добавллне более оптимальный метод решения данной задачи при помощи методов класса Stack.
