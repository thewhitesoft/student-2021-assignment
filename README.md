# Утромы

### Описание

Донателло со своими братьями ворвался на базу инопланетной расы утромов, чтобы собрать информацию с их серверов. 
В код техгика закралась ошибка, в результате которой все файлы и директории с сервером были скопированы в одну директорию "Utrom's secrets", а к их именам через пробел добавился универсальный уникальный идентификатор ([UUID](uuid.md)).

Напишите программу, которая обработает данные из директории "Utrom's secrets", и оставит только уникальные файлы и директории.\
Для того, чтобы данные занимали меньше места, упакуйте их в [zip-архив](zip.md) "Utrom's secrets.zip"*.

Данные одинаковые, если...
* данные одного типа (оба файла или обе директории)
* имена до UUID совпадают (для файлов - должны совпадать расширения).\
  При совпадении отсортировать по имени файла с UUID и взять первый файл или директорию.
* содержимое совпадает (для директорий - файлы и данные в них). \
  Если нет, то указывать отсортировать по убыванию размера (для директорий суммировать размер вложенных файлов) 
  и в скобках через пробел указать порядковый номер, начиная от 1 (для первого файла / директории не проставлять, только для дублей)*

Ограничения:
- в директориях не может быть поддиректорий

Задание под звездой (*) повышенной сложности и необязательны для выполнения.

#### Входные данные

- директория "src/Utrom's secrets", лежащая в корне проекта

#### Выходные данные

- директория "Utrom's secrets" или zip-архив "Utrom's secrets.zip", лежащие в директории "dest" в корне проекта.

Будет плюсом, если входные и выходные данные можно задавать при запуске программы:
```
solution.exe --src "./src/Utrom's secrets/" --dest ./dest/

java -jar solution.jar --src "./src/Utrom's secrets/" --dest ./dest/
```


---

### Что отсылать?
Решение (программу) с исходным кодом, написанную на твоем любимом языке программирования, с инструкцией по запуску.\
Будет плюсом, если закинешь свое решение в Git ([GitHub](https://github.com/), [GitLab](https://about.gitlab.com/), [Bitbucket](http://bitbucket.org/)).

### Куда отсылать решения?
На электронную почту [student@theWhite.ru](mailto:student@theWhite.ru)

### Что еще?
Заполни [анкету](https://forms.gle/zYYp74V32vzoqkeT7), чтобы рассказать о себе больше.

---

### Пример
#### Utrom's server 1
```
/
|- Secret data/
    |- top.secret 500Kb
    |- middle.secret 30Kb
|- Total secret/
    |- total.secret 17Kb
|- Win.plan 256Kb
|- Research/
    |- finded.secret 70Kb
|- Share/
    |- shared.secret 45Kb
```

#### Utrom's server 2
```
/
|- Secret data/
    |- middle.secret 30Kb
|- Win.plan 25Kb
|- Escape.plan 56Kb
|- Research/
    |- finded.secret 75Kb
|- Share/
    |- shared.secret 45Kb
```

#### src/Utrom's secrets (входные данные)
```
/src/Utrom's secrets/
    |- Research fe2fbaed-9a7f-4f9a-b430-e089a9771c95/
        |- finded.secret 70Kb
    |- Research 5e5ce901-b486-49e1-848a-a8134a791374/
        |- finded.secret 75Kb
    |- Secret data cdd8d173-61d9-4eaa-a827-61ebd75ce7da/
        |- middle.secret 30Kb
    |- Secret data 047f1762-d6f4-4f41-9ee3-9dfacf2575ec/
        |- top.secret 500Kb
        |- middle.secret 30Kb
    |- Share ba8ad6f4-0194-4e0c-b825-78582720bba3/
        |- shared.secret 45Kb
    |- Share e1106238-d0f3-4902-9478-f012b87ce2a8/
        |- shared.secret 45Kb 
    |- Total secret 86b5d8c6-5b6c-493f-b626-b7b506900687/
        |- total.secret 17Kb
    |- Escape 5e5ce901-b486-49e1-848a-a8134a791374.plan 56Kb
    |- Win e4e31179-1e60-46d5-a868-fbb709789e07.plan 25Kb
    |- Win f51a1b8a-1519-4ac0-b432-00d6d9001400.plan 256Kb   
```

#### dest/Utrom's secrets
```
/dest/Utrom's secrets/
    |- Research/
        |- finded.secret 75Kb
    |- Secret data/
        |- middle.secret 30Kb
        |- top.secret 500Kb
    |- Share/
        |- shared.secret 45Kb
    |- Total secret/
        |- total.secret 17Kb
    |- Escape.plan 56Kb
    |- Win.plan 256Kb
```

#### dest/Utrom's secrets.zip
```
/dest/Utrom's secrets.zip/
    |- Research/
        |- finded.secret 75Kb
    |- Research (1)/
        |- finded.secret 70Kb
    |- Secret data/
        |- middle.secret 30Kb
        |- top.secret 500Kb
    |- Secret data (1)/
        |- middle.secret 30Kb
    |- Share/
        |- shared.secret 45Kb
    |- Total secret/
        |- total.secret 17Kb
    |- Escape.plan 56Kb
    |- Win.plan 256Kb
    |- Win (1).plan 25Kb
```