# MTS_Test

## Задача 1.

Необходимо получить одним запросом  выборку за 2017 год в разрезе клиента по месяцам нарастающим итогом упорядоченную по клиенту, месяцу:

Решение для задачи 1
```sql
SELECT 
 C1.clientname as ClientName,
    MONTH(C1.Date) as Month,
    SUM(C2.amount) as SumAmount
FROM
 Clients C1
JOIN 
 Clients C2
on 
 C1.ClientName = C2.ClientName
    and C1.date >= C2.Date
where 
 C1.date >= '2017-01-01'
    and C1.date < '2018-01-01'
GROUP BY C1.clientname, MONTH(C1.Date)
```

## Задача 2

Разработать на c# консольное приложение, которое должно отслеживать появление новых текстовых файлов в заданном каталоге. При появлении нового файла необходимо:
- Для html файла посчитать количество тегов div
- Для css  файла проверить, что количество открывающих скобок “{“ совпадает с количеством закрывающих скобок “}”
- Во всех других случаях – посчитать количество знаков препинания.

Результаты расчетов необходимо сохранить в текстовый документ в виде “<имя файла>-<имя операции>-<результат>”. При проектировании приложения предусмотреть возможность расширения как количества операций, выполняемых над имеющимся типом файла, так и количества распознаваемых типов файлов.

Решение:

Данный репозиторий содержит решение для задачи 2.

Для запуска необходимо передать в качестве параметров запуска --dirpath='Директория за которой надо следить'.

Пример:
```
MTS_Test.exe --dirpath='C:/'
```

## Задача 3

Дано: приложение, помогающее проложить оптимальный маршрут от одной станции московского метро до другой (аналог https://metro.yandex.ru/moscow). 
Основной сценарий работы:
- построение маршрута между двумя станциями. 

Исходные данные, описывающие схему метрополитена хранятся в xml файле.

Задача: спроектировать структуру XML файла для хранения схемы московского метрополитена.

```xml
<Metro>
    <Line color="Brown" name="Kolctsevaya">
        <Station>
            <Name>Novoslobodskaya</Name>
            <Next>ProskpektMira</Next>
            <Transfer>
                <Line>
                    <Color>Gray</Color>
                    <Name>Serpuhovsko-Timiryazevskaya</Name>
                    <StationName>Mendeleevskaya</StationName>
                </Line>
            </Transfer>
        </Station>
        <Station>
            <Name>Proskpekt Mira</Name>
            <Next>Komsomol'skaya</Next>
            <Transfer>
                <Line>
                    <Color>Orange</Color>
                    <Name>Kaluzhsko-Rizhskaya</Name>
                    <StationName>Proskpekt Mira</StationName>
                </Line>
            </Transfer>
        </Station>
        ...
        ...
        ...
        <Station>
            <Name>Belorusskaya</Name>
            <Next>Novoslobodskaya</Next>
            <Transfer>
                <Line>
                    <Color>Green</Color>
                    <Name>Zamoskvoreckaya</Name>
                    <StationName>Belorusskaya</StationName>
                </Line>
            </Transfer>
        </Station>
    </Line>
    <Line>...</Line>
    <Line>...</Line>
    <Line>...</Line>
</Metro>
```
