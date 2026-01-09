//Задание 1: 
//Реализуйте пользовательский тип Фирма. В нём должна быть 
//информация о названии фирмы, дате основания, профиле 
//бизнеса (маркетинг, IT, и т. д.), ФИО директора, количество 
//сотрудников, адрес.  
//Для массива фирм реализуйте следующие запросы: 
// Получить информацию обо всех фирмах 
// Получить фирмы, у которых в названии есть слово Food 
// Получить фирмы, которые работают в области маркетинга 
// Получить фирмы, которые работают в области маркетинга 
//или IT 
// Получить фирмы с количеством сотрудников, большем 100 
// Получить фирмы с количеством сотрудников в диапазоне от 
//100 до 300 
// Получить фирмы, которые находятся в Лондоне 
// Получить фирмы, у которых фамилия директора White 
// Получить фирмы, которые основаны больше двух лет назад 
// Получить фирмы со дня основания, которых прошло 123 дня 
// Получить фирмы, у которых фамилия директора Black и 
//название фирмы содержит слово White 

using System;

namespace Task1
{
    class Firm
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorFullName { get; set; }
        public int EmployeesCount { get; set; }
        public string Address { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Firm> firms = new List<Firm>
            {
                new Firm { Name="White Food", FoundationDate=DateTime.Now.AddYears(-3), BusinessProfile="Marketing", DirectorFullName="John White", EmployeesCount=150, Address="London"},
                new Firm { Name="Black IT", FoundationDate=DateTime.Now.AddDays(-123), BusinessProfile="IT", DirectorFullName="Robert Black", EmployeesCount=90, Address="New York"},
                new Firm { Name="Green Market", FoundationDate=DateTime.Now.AddYears(-1), BusinessProfile="Marketing", DirectorFullName="Alice Brown", EmployeesCount=250, Address="London"}
            };

            var allFirms = from f in firms select f;
            var foodFirms = from f in firms where f.Name.Contains("Food") select f;
            var marketingFirms = from f in firms where f.BusinessProfile == "Marketing" select f;
            var marketingOrIT = from f in firms where f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT" select f;
            var moreThan100 = from f in firms where f.EmployeesCount > 100 select f;
            var range100to300 = from f in firms where f.EmployeesCount >= 100 && f.EmployeesCount <= 300 select f;
            var londonFirms = from f in firms where f.Address == "London" select f;
            var directorWhite = from f in firms where f.DirectorFullName.EndsWith("White") select f;
            var olderThan2Years = from f in firms where (DateTime.Now - f.FoundationDate).TotalDays > 730 select f;
            var founded123Days = from f in firms where (DateTime.Now - f.FoundationDate).Days == 123 select f;
            var complex = from f in firms
                          where f.DirectorFullName.EndsWith("Black") && f.Name.Contains("White")
                          select f;
        }
    }
}

//Задание 2: 
//Реализуйте запросы из первого задания с использованием 
//синтаксиса методов расширений.  

using System;

namespace Task2
{
    class Firm
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorFullName { get; set; }
        public int EmployeesCount { get; set; }
        public string Address { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Firm> firms = new List<Firm>
            {
                new Firm { Name="White Food", FoundationDate=DateTime.Now.AddYears(-3), BusinessProfile="Marketing", DirectorFullName="John White", EmployeesCount=150, Address="London"},
                new Firm { Name="Black IT", FoundationDate=DateTime.Now.AddDays(-123), BusinessProfile="IT", DirectorFullName="Robert Black", EmployeesCount=90, Address="New York"},
                new Firm { Name="Green Market", FoundationDate=DateTime.Now.AddYears(-1), BusinessProfile="Marketing", DirectorFullName="Alice Brown", EmployeesCount=250, Address="London"}
            };

            var allFirms = firms.ToList();
            var foodFirms = firms.Where(f => f.Name.Contains("Food"));
            var marketingFirms = firms.Where(f => f.BusinessProfile == "Marketing");
            var marketingOrIT = firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT");
            var moreThan100 = firms.Where(f => f.EmployeesCount > 100);
            var range100to300 = firms.Where(f => f.EmployeesCount >= 100 && f.EmployeesCount <= 300);
            var londonFirms = firms.Where(f => f.Address == "London");
            var directorWhite = firms.Where(f => f.DirectorFullName.EndsWith("White"));
            var olderThan2Years = firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays > 730);
            var founded123Days = firms.Where(f => (DateTime.Now - f.FoundationDate).Days == 123);
            var complex = firms.Where(f => f.DirectorFullName.EndsWith("Black") && f.Name.Contains("White"));
        }
    }
}

//Задание 3: 
//Добавьте к первому заданию класс, содержащий информацию о 
//сотрудниках. Нужно хранить такие данные: 
// ФИО сотрудника 
// Должность 
// Контактный телефон 
// Email 
// Заработная плата 
//Добавьте информацию о сотрудниках внутрь фирмы.  
//Для массива сотрудников фирмы реализуйте следующие 
//запросы: 
// Получить всех сотрудников конкретной фирмы 
// Получить всех сотрудников конкретной фирмы, у которых 
//заработные платы больше заданной 
// Получить сотрудников всех фирм, у которых должность 
//менеджер 
// Получить сотрудников, у которых телефон начинается с 23 
// Получить сотрудников, у которых Email начинается с di 
// Получить сотрудников, у которых имя Lionel

using System;

namespace Task3
{
    class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
    }

    class Firm
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Firm> firms = new List<Firm>
            {
                new Firm
                {
                    Name="White Food",
                    Employees=new List<Employee>
                    {
                        new Employee{ FullName="Lionel Messi", Position="Manager", Phone="231234", Email="di_messi@mail.com", Salary=5000 },
                        new Employee{ FullName="Alex Brown", Position="Developer", Phone="451234", Email="alex@mail.com", Salary=3000 }
                    }
                },
                new Firm
                {
                    Name="Black IT",
                    Employees=new List<Employee>
                    {
                        new Employee{ FullName="Lionel Richie", Position="Manager", Phone="239999", Email="di_rich@mail.com", Salary=6000 }
                    }
                }
            };

            var employeesOfFirm = firms.First(f => f.Name == "White Food").Employees;

            var employeesWithSalary = firms
                .First(f => f.Name == "White Food")
                .Employees
                .Where(e => e.Salary > 4000);

            var managers = firms.SelectMany(f => f.Employees)
                                .Where(e => e.Position == "Manager");

            var phone23 = firms.SelectMany(f => f.Employees)
                               .Where(e => e.Phone.StartsWith("23"));

            var emailDi = firms.SelectMany(f => f.Employees)
                               .Where(e => e.Email.StartsWith("di"));

            var nameLionel = firms.SelectMany(f => f.Employees)
                                  .Where(e => e.FullName.StartsWith("Lionel"));
        }
    }
}

//Задание 1: 
//Для массива целых реализуйте пользовательскую сортировку. 
//Сортировка должна работать по сумме цифр числа (по 
//возрастанию и убыванию). Например, если сортировка 
//производится по убыванию, нужно вернуть числа с 
//максимальной суммой в порядке убывания суммы.  Например,
//если массив содержит 121, 75, 81, после сортировки по убыванию 
//мы получим 75, 81, 121.  
//Такой результат, потому что (7+5 = 12, 8+1 = 9, 1+2+1 = 4) 

using System;

namespace Task1
{
    class Program
    {
        static int DigitsSum(int number)
        {
            number = Math.Abs(number);
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        static void Main()
        {
            int[] numbers = { 121, 75, 81, 34, 99 };

            var ascSort = numbers.OrderBy(n => DigitsSum(n));

            var descSort = numbers.OrderByDescending(n => DigitsSum(n));

            Console.WriteLine("По возрастанию суммы цифр:");
            foreach (var n in ascSort)
                Console.WriteLine($"{n} (сумма = {DigitsSum(n)})");

            Console.WriteLine("\nПо убыванию суммы цифр:");
            foreach (var n in descSort)
                Console.WriteLine($"{n} (сумма = {DigitsSum(n)})");
        }
    }
}

//Задание 2: 
//Для двух массивов стран реализуйте следующие запросы: 
// Получить разницу двух массивов (элементы первого 
//массива, которых нет во втором)  
// Получить пересечение массивов (элементы, которые 
//являются общими в обоих массивах) 
// Получить объединение массивов (элементы обоих 
//массивов без наличия дубликатов) 
// Получить содержимое первого массива без повторений 

using System;

namespace Task2
{
    class Program
    {
        static void Main()
        { 
            string[] countries1 = { "Ukraine", "Poland", "Germany", "France", "Italy" };
            string[] countries2 = { "Germany", "Spain", "Italy", "Portugal" };

            var difference = countries1.Except(countries2);

            var intersection = countries1.Intersect(countries2);

            var union = countries1.Union(countries2);

            var distinctFirst = countries1.Distinct();

            Console.WriteLine("Разница:");
            foreach (var c in difference)
                Console.WriteLine(c);

            Console.WriteLine("\nПересечение:");
            foreach (var c in intersection)
                Console.WriteLine(c);

            Console.WriteLine("\nОбъединение:");
            foreach (var c in union)
                Console.WriteLine(c);

            Console.WriteLine("\nПервый массив без повторений:");
            foreach (var c in distinctFirst)
                Console.WriteLine(c);
        }
    }
}

//Задание 3: 
//Создайте пользовательский тип Устройство. Нужно хранить 
//такие характеристики: 
// Название устройства 
// Производитель устройства 
// Стоимость 
//Для двух массивов устройств реализуйте операции: 
// Разница массивов 
// Пересечение массивов 
// Объединение массивов 
//Критерий для проведения операций – производитель 
//устройства.

using System;

namespace Task3
{
    class Device
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Device> devices1 = new List<Device>
            {
                new Device { Name="Phone X", Manufacturer="Apple", Price=900 },
                new Device { Name="Galaxy S", Manufacturer="Samsung", Price=800 },
                new Device { Name="Pixel", Manufacturer="Google", Price=700 }
            };

            List<Device> devices2 = new List<Device>
            {
                new Device { Name="iPhone 14", Manufacturer="Apple", Price=1200 },
                new Device { Name="Galaxy A", Manufacturer="Samsung", Price=500 },
                new Device { Name="Xperia", Manufacturer="Sony", Price=600 }
            };

            var difference = devices1
                .Where(d => !devices2.Any(d2 => d2.Manufacturer == d.Manufacturer));

            var intersection = devices1
                .Where(d => devices2.Any(d2 => d2.Manufacturer == d.Manufacturer));

            var union = devices1
                .Concat(devices2)
                .GroupBy(d => d.Manufacturer)
                .Select(g => g.First());

            Console.WriteLine("Разница:");
            foreach (var d in difference)
                Console.WriteLine(d.Manufacturer);

            Console.WriteLine("\nПересечение:");
            foreach (var d in intersection)
                Console.WriteLine(d.Manufacturer);

            Console.WriteLine("\nОбъединение:");
            foreach (var d in union)
                Console.WriteLine(d.Manufacturer);
        }
    }
}

//Задание 1: 
//Создайте пользовательский тип Телефон. Необходимо хранить 
//такую информацию: 
// Название телефона 
// Производитель 
// Цена 
// Дата выпуска 
//Для массива телефонов выполните следующие задания,
//используя агрегатные операции из LINQ: 
// Посчитайте количество телефонов 
// Посчитайте количество телефонов с ценой больше 100 
// Посчитайте количество телефонов с ценой в диапазоне от 
//400 до 700 
// Посчитайте 
//производителя 
//количество 
//телефонов 
// Найдите телефон с минимальной ценой  
// Найдите телефон с максимальной ценой  
//конкретного 
// Отобразите информацию о самом старом телефоне 
// Отобразите информацию о самом свежем телефоне 
// Найдите среднюю цену телефона 

using System;

namespace Task1
{
    class Phone
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Phone> phones = new List<Phone>
            {
                new Phone { Name="iPhone 13", Manufacturer="Apple", Price=999, ReleaseDate=new DateTime(2021,9,1)},
                new Phone { Name="Galaxy S22", Manufacturer="Samsung", Price=850, ReleaseDate=new DateTime(2022,2,1)},
                new Phone { Name="Xperia 5", Manufacturer="Sony", Price=650, ReleaseDate=new DateTime(2020,6,1)},
                new Phone { Name="iPhone X", Manufacturer="Apple", Price=500, ReleaseDate=new DateTime(2018,9,1)},
                new Phone { Name="Galaxy A51", Manufacturer="Samsung", Price=300, ReleaseDate=new DateTime(2019,3,1)}
            };

            int totalCount = phones.Count();
            int priceAbove100 = phones.Count(p => p.Price > 100);
            int priceRange = phones.Count(p => p.Price >= 400 && p.Price <= 700);
            int appleCount = phones.Count(p => p.Manufacturer == "Apple");

            var minPricePhone = phones.OrderBy(p => p.Price).First();
            var maxPricePhone = phones.OrderByDescending(p => p.Price).First();
            var oldestPhone = phones.OrderBy(p => p.ReleaseDate).First();
            var newestPhone = phones.OrderByDescending(p => p.ReleaseDate).First();
            decimal avgPrice = phones.Average(p => p.Price);
        }
    }
}

//Задание 2: 
//Добавьте к первому заданию новую функциональность: 
// Отобразите пять самых дорогих телефонов 
// Отобразите пять самых дешевых телефонов 
// Отобразите три самых старых телефона 
// Отобразите три самых новых телефона 
//Для реализации задания используйте семейство методов Skip,
//Take. 

using System;

namespace Task2
{
    class Phone
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Phone> phones = new List<Phone>
            {
                new Phone { Name="iPhone 13", Manufacturer="Apple", Price=999, ReleaseDate=new DateTime(2021,9,1)},
                new Phone { Name="Galaxy S22", Manufacturer="Samsung", Price=850, ReleaseDate=new DateTime(2022,2,1)},
                new Phone { Name="Xperia 5", Manufacturer="Sony", Price=650, ReleaseDate=new DateTime(2020,6,1)},
                new Phone { Name="iPhone X", Manufacturer="Apple", Price=500, ReleaseDate=new DateTime(2018,9,1)},
                new Phone { Name="Galaxy A51", Manufacturer="Samsung", Price=300, ReleaseDate=new DateTime(2019,3,1)},
                new Phone { Name="Pixel 7", Manufacturer="Google", Price=900, ReleaseDate=new DateTime(2022,10,1)}
            };

            var fiveMostExpensive = phones
                .OrderByDescending(p => p.Price)
                .Take(5);

            var fiveCheapest = phones
                .OrderBy(p => p.Price)
                .Take(5);

            var threeOldest = phones
                .OrderBy(p => p.ReleaseDate)
                .Take(3);

            var threeNewest = phones
                .OrderByDescending(p => p.ReleaseDate)
                .Take(3);
        }
    }
}

//Задание 3: 
//Добавьте к первому заданию новую функциональность: 
// Отобразите статистику по количеству телефонов каждого 
//производителя. Например: Sony – 3, Samsung – 4, Apple – 5 
//и т. д. 
// Отобразите статистику по количеству моделей телефонов. 
//Например: IPhone 13 – 12, IPhone 10 – 11, Galaxy S22 – 8  
// Отобразите статистику телефонов по годам. Например: 2021 – 10, 2022 – 5, 2019 – 3

using System;

namespace Task3
{
    class Phone
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Phone> phones = new List<Phone>
            {
                new Phone { Name="iPhone 13", Manufacturer="Apple", Price=999, ReleaseDate=new DateTime(2021,9,1)},
                new Phone { Name="iPhone 13", Manufacturer="Apple", Price=950, ReleaseDate=new DateTime(2021,9,1)},
                new Phone { Name="Galaxy S22", Manufacturer="Samsung", Price=850, ReleaseDate=new DateTime(2022,2,1)},
                new Phone { Name="Galaxy S22", Manufacturer="Samsung", Price=800, ReleaseDate=new DateTime(2022,2,1)},
                new Phone { Name="Xperia 5", Manufacturer="Sony", Price=650, ReleaseDate=new DateTime(2020,6,1)}
            };

            var byManufacturer = phones
                .GroupBy(p => p.Manufacturer)
                .Select(g => new { Manufacturer = g.Key, Count = g.Count() });

            var byModel = phones
                .GroupBy(p => p.Name)
                .Select(g => new { Model = g.Key, Count = g.Count() });

            var byYear = phones
                .GroupBy(p => p.ReleaseDate.Year)
                .Select(g => new { Year = g.Key, Count = g.Count() });
        }
    }
}

//Задание 1: 
//Для массива фамилий выполните следующие задания: 
// Проверьте все ли фамилии имеют длину больше трёх 
//символов. Используйте метод All. 
// Проверьте все ли фамилии имеют длину больше трёх 
//символов и меньше десяти символов. Используйте метод 
//All. 
// Проверьте есть ли в массиве хотя бы одна фамилия, которая 
//начинается с W. Используйте метод Any. 
// Проверьте есть ли в массиве хотя бы одна фамилия, которая 
//заканчивается на Y. Используйте метод Any. 
// Проверьте есть ли в массиве фамилия Orange. Используйте 
//метод Contains. 
// Отобразите первую фамилию с длиной равной 6. 
//Используйте метод FirstOrDefault. 
// Отобразите последнюю фамилию с длиной меньше 15. 
//Используйте метод LastOrDefault. 

using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            string[] surnames =
            {
                "White", "Brown", "Wilson", "Smith", "Green", "Orange", "Murphy"
            };

            bool allMoreThan3 = surnames.All(s => s.Length > 3);

            bool allFrom3To10 = surnames.All(s => s.Length > 3 && s.Length < 10);

            bool anyStartsWithW = surnames.Any(s => s.StartsWith("W"));

            bool anyEndsWithY = surnames.Any(s => s.EndsWith("Y"));

            bool containsOrange = surnames.Contains("Orange");

            string firstLength6 = surnames.FirstOrDefault(s => s.Length == 6);

            string lastLessThan15 = surnames.LastOrDefault(s => s.Length < 15);
        }
    }
}

//Задание 2: 
//Создайте пользовательский тип Журнал. Необходимо хранить 
//такую информацию: 
// Название Журнала 
// Жанр 
// Количество страниц в выпуске 
// Дата выпуска 
//Для массива журналов выполните следующие задания: 
// Проверьте у всех ли журналов количество страниц больше 
//30. Используйте метод All. 
// Проверьте у всех ли журналов жанр Политика, Мода или 
//Спорт. Используйте метод All. 
// Проверьте есть ли хотя бы один журнал в жанре Сад и 
//Огород. Используйте метод Any. 
// Проверьте есть ли в массиве хотя бы один журнал в жанре 
//Рыбалка. Используйте метод Any. 
// Проверьте есть ли в массиве журналы по Охоте. 
//Используйте метод Contains. Обратите внимание, что Охота 
//может быть написана в любом регистре. Вам необходимо 
//игнорировать регистр. 
// Отобразите первый журнал с годом выпуска 2022. 
//Используйте метод FirstOrDefault. 
// Отобразите последний журнал название, которого 
//начинается с Авто. Используйте метод LastOrDefault.

using System;

namespace Task2
{
    class Magazine
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Magazine> magazines = new List<Magazine>
            {
                new Magazine { Title="Auto Мир", Genre="Авто", Pages=45, ReleaseDate=new DateTime(2022,5,1)},
                new Magazine { Title="Sport Life", Genre="Спорт", Pages=60, ReleaseDate=new DateTime(2021,3,1)},
                new Magazine { Title="Fashion Style", Genre="Мода", Pages=50, ReleaseDate=new DateTime(2020,6,1)},
                new Magazine { Title="Garden", Genre="Сад и Огород", Pages=35, ReleaseDate=new DateTime(2019,7,1)},
                new Magazine { Title="Hunting Pro", Genre="охота", Pages=40, ReleaseDate=new DateTime(2018,8,1)}
            };

            bool pagesMoreThan30 = magazines.All(m => m.Pages > 30);

            bool validGenres = magazines.All(m =>
                m.Genre == "Политика" ||
                m.Genre == "Мода" ||
                m.Genre == "Спорт" ||
                m.Genre == "Авто" ||
                m.Genre == "Сад и Огород" ||
                m.Genre.ToLower() == "охота");

            bool anyGarden = magazines.Any(m => m.Genre == "Сад и Огород");

            bool anyFishing = magazines.Any(m => m.Genre == "Рыбалка");

            bool containsHunting = magazines.Any(m =>
                m.Genre.Equals("Охота", StringComparison.OrdinalIgnoreCase));

            var first2022 = magazines.FirstOrDefault(m => m.ReleaseDate.Year == 2022);

            var lastAuto = magazines.LastOrDefault(m => m.Title.StartsWith("Auto"));
        }
    }
}

//Задание 1: 
//Для массива целых реализуйте следующие запросы: 
// Получить весь масcив целых 
// Получить четные целые 
// Получить нечетные целые 
// Получить значения больше заданного 
// Получить числа в заданном диапазоне 
// Получить числа кратные семи. Результат отсортировать по 
//возрастанию 
// Получить числа кратные восьми. Результат отсортировать 
//по убыванию 

using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { 3, 7, 8, 14, 21, 32, 40, 56, 63 };

            var allNumbers = numbers;

            var evenNumbers = numbers.Where(n => n % 2 == 0);

            var oddNumbers = numbers.Where(n => n % 2 != 0);

            int value = 20;
            var greaterThanValue = numbers.Where(n => n > value);

            int min = 10;
            int max = 50;
            var inRange = numbers.Where(n => n >= min && n <= max);

            var multipleOfSeven = numbers
                .Where(n => n % 7 == 0)
                .OrderBy(n => n);

            var multipleOfEight = numbers
                .Where(n => n % 8 == 0)
                .OrderByDescending(n => n);
        }
    }
}

//Задание 2: 
//Для массива строк, содержащих название городов реализуйте 
//следующие запросы: 
// Получить весь масcив городов 
// Получить города с длиной названия равной заданному 
// Получить города названия, которых начинается с буквы A 
// Получить города названия, которых заканчивается на букву 
//M 
// Получить города названия, которых начинаются на N и 
//заканчиваются на букву K 
// Получить города названия, которых начинаются на Ne. 
//Результат отсортировать по убыванию 

using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            string[] cities =
            {
                "Amsterdam", "Rome", "New York", "Berlin",
                "Naples", "Norsk", "Nebrok", "London"
            };

            var allCities = cities;

            int length = 5;
            var citiesWithLength = cities.Where(c => c.Length == length);

            var startsWithA = cities.Where(c => c.StartsWith("A"));

            var endsWithM = cities.Where(c => c.EndsWith("m"));

            var startsNEndsK = cities
                .Where(c => c.StartsWith("N") && c.EndsWith("k"));

            var startsWithNeDesc = cities
                .Where(c => c.StartsWith("Ne"))
                .OrderByDescending(c => c);
        }
    }
}

//Задание 3: 
//Реализуйте пользовательский тип Студент. В нём должна быть 
//информация об имени, фамилии, возрасте, названии учебного 
//заведения.  
//Для массива студентов реализуйте следующие запросы: 
// Получить весь массив студентов 
// Получить студентов с именем Boris 
// Получить студентов с фамилией, которая начинается с Bro 
// Получить студентов, которые старше 19 лет 
// Получить студентов, которые старше 20 лет и младше 23 лет 
// Получить студентов, которые учатся в MIT 
// Получить студентов, которые учатся в Oxford и их возраст 
//старше 18 лет. Результат отсортировать по возрасту по 
//убыванию.

using System;

namespace Task3
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string University { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student { Name="Boris", Surname="Brown", Age=20, University="MIT" },
                new Student { Name="Alex", Surname="Brooks", Age=22, University="Oxford" },
                new Student { Name="Ivan", Surname="Smith", Age=18, University="MIT" },
                new Student { Name="Boris", Surname="White", Age=24, University="Harvard" },
                new Student { Name="John", Surname="Bronson", Age=21, University="Oxford" }
            };

            var allStudents = students;

            var nameBoris = students.Where(s => s.Name == "Boris");

            var surnameBro = students.Where(s => s.Surname.StartsWith("Bro"));

            var olderThan19 = students.Where(s => s.Age > 19);

            var age20to23 = students.Where(s => s.Age > 20 && s.Age < 23);

            var studyMIT = students.Where(s => s.University == "MIT");

            var oxfordOlder18 = students
                .Where(s => s.University == "Oxford" && s.Age > 18)
                .OrderByDescending(s => s.Age);
        }
    }
}

//Задание 1: 
//Для массива строк реализуйте пользовательскую сортировку. 
//Сортировка должна работать по количеству символов (по 
//возрастанию и убыванию). Например, если сортировка 
//производится по убыванию, нужно вернуть строки с 
//максимальной длиной в порядке убывания длины.  

using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            string[] words =
            {
                "apple", "banana", "kiwi", "strawberry", "pear", "plum"
            };

            var ascSort = words.OrderBy(w => w.Length);

            var descSort = words.OrderByDescending(w => w.Length);

            Console.WriteLine("По возрастанию длины:");
            foreach (var w in ascSort)
                Console.WriteLine(w);

            Console.WriteLine("\nПо убыванию длины:");
            foreach (var w in descSort)
                Console.WriteLine(w);
        }
    }
}

//Задание 2: 
//Для двух массивов целых реализуйте следующие запросы: 
// Получить разницу двух массивов (элементы первого 
//массива, которых нет во втором)  
// Получить пересечение массивов (элементы, которые 
//являются общими в обоих массивах) 
// Получить объединение массивов (элементы обоих 
//массивов без наличия дубликатов) 
// Получить содержимое первого массива без повторений 

using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            int[] array1 = { 1, 2, 3, 4, 5, 6, 7 };
            int[] array2 = { 5, 6, 7, 8, 9 };

            var difference = array1.Except(array2);

            var intersection = array1.Intersect(array2);

            var union = array1.Union(array2);

            var distinctFirst = array1.Distinct();
        }
    }
}

//Задание 3: 
//Создайте пользовательский тип Автомобиль. Нужно хранить 
//такие характеристики: 
// Название
// Производитель  
// Год выпуска 
//Для двух массивов автомобилей реализуйте операции: 
// Разница массивов 
// Пересечение массивов 
// Объединение массивов 
//Критерий для проведения операций – производитель.

using System;

namespace Task3
{
    class Car
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Car> cars1 = new List<Car>
            {
                new Car { Name="Model S", Manufacturer="Tesla", Year=2020 },
                new Car { Name="Corolla", Manufacturer="Toyota", Year=2018 },
                new Car { Name="Civic", Manufacturer="Honda", Year=2019 }
            };

            List<Car> cars2 = new List<Car>
            {
                new Car { Name="Model 3", Manufacturer="Tesla", Year=2021 },
                new Car { Name="Camry", Manufacturer="Toyota", Year=2020 },
                new Car { Name="A4", Manufacturer="Audi", Year=2017 }
            };

            var difference = cars1
                .Where(c => !cars2.Any(c2 => c2.Manufacturer == c.Manufacturer));

            var intersection = cars1
                .Where(c => cars2.Any(c2 => c2.Manufacturer == c.Manufacturer));

            var union = cars1
                .Concat(cars2)
                .GroupBy(c => c.Manufacturer)
                .Select(g => g.First());
        }
    }
}

//Задание 1: 
//Для массива целых выполните следующие задания, используя 
//агрегатные операции из LINQ: 
// Посчитайте произведение элементов массива 
// Посчитайте количество элементов массива 
// Посчитайте количество элементов массива, кратных 9 
// Посчитайте количество элементов массива, кратных 7 и 
//больших, чем 945 
// Посчитайте сумму элементов массива 
// Посчитайте сумму чётных элементов массива 
// Найдите минимум в массиве 
// Найдите максимум в массиве 
// Найдите среднее значение в массиве 

using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { 7, 9, 14, 21, 945, 954, 18, 36 };

            long product = numbers.Aggregate(1L, (acc, n) => acc * n);

            int count = numbers.Count();

            int countDiv9 = numbers.Count(n => n % 9 == 0);

            int countDiv7AndGreater945 = numbers.Count(n => n % 7 == 0 && n > 945);

            int sum = numbers.Sum();

            int sumEven = numbers.Where(n => n % 2 == 0).Sum();

            int min = numbers.Min();

            int max = numbers.Max();

            double average = numbers.Average();
        }
    }
}

//Задание 2: 
//Добавьте к первому заданию новую функциональность: 
// Отобразите три первых максимальных элемента 
// Отобразите три первых минимальных элемента 
//Для реализации задания используйте семейство методов Skip,
//Take. 

using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { 7, 9, 14, 21, 945, 954, 18, 36 };

            var threeMax = numbers
                .OrderByDescending(n => n)
                .Take(3);

            var threeMin = numbers
                .OrderBy(n => n)
                .Take(3);
        }
    }
}

//Задание 3: 
//Добавьте к первому заданию новую функциональность: 
// Отобразите статистику вхождения каждого числа в массив. 
//Например: 7 – 3 раза, 5 – 2 раза, 8 – 4 раза и т. д. 
// Отобразите статистику вхождения чётных чисел в массив. 
//Например: 2 – 4 раза, 6 – 2 раза и т. д. 
// Отобразите статистику вхождения чётных и нечётных чисел 
//в массив. Например: чётные – 3 раза, нечётные – 2 раза

using System;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { 2, 7, 2, 5, 7, 8, 8, 8, 5 };

            var eachNumberStat = numbers
                .GroupBy(n => n)
                .Select(g => new { Number = g.Key, Count = g.Count() });

            var evenStat = numbers
                .Where(n => n % 2 == 0)
                .GroupBy(n => n)
                .Select(g => new { Number = g.Key, Count = g.Count() });

            var evenOddStat = numbers
                .GroupBy(n => n % 2 == 0 ? "Чётные" : "Нечётные")
                .Select(g => new { Type = g.Key, Count = g.Count() });
        }
    }
}

//Задание 1: 
//Для массива целых выполните следующие задания: 
// Проверьте все ли элементы в массиве чётные. Используйте 
//метод All. 
// Проверьте все ли элементы в массиве больше 10 и меньше 
//45. Используйте метод All. 
// Проверьте есть ли в массиве хотя бы один отрицательный 
//элемент. Используйте метод Any. 
// Проверьте есть ли в массиве хотя бы один нечётный,
//отрицательный элемент. Используйте метод Any. 
// Проверьте есть ли в массиве значение 7. Используйте метод 
//Contains. 
// Отобразите первый элемент больше 723. Используйте метод 
//FirstOrDefault. 
// Отобразите 
//последний,
//отрицательный 
//Используйте метод LastOrDefault. 

using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { 12, 18, -7, 24, 36, 7, -3, 800 };

            bool allEven = numbers.All(n => n % 2 == 0);

            bool allBetween10And45 = numbers.All(n => n > 10 && n < 45);

            bool anyNegative = numbers.Any(n => n < 0);

            bool anyOddNegative = numbers.Any(n => n < 0 && n % 2 != 0);

            bool contains7 = numbers.Contains(7);

            int firstGreater723 = numbers.FirstOrDefault(n => n > 723);

            int lastNegative = numbers.LastOrDefault(n => n < 0);
        }
    }
}

//Задание 2: 
//элемент.
//Создайте пользовательский тип Книга. Необходимо хранить 
//такую информацию: 
// Название книги 
// Автор 
// Жанр 
// Количество страниц 
// Год выпуска 
//Для массива книг выполните следующие задания: 
// Проверьте у всех ли книг количество страниц больше 100. 
//Используйте метод All. 
// Проверьте у всех ли книг жанр Исторический или Сатира. 
//Используйте метод All. 
// Проверьте есть ли хотя бы одна книга в жанре Ужасы. 
//Используйте метод Any. 
// Проверьте есть ли в массиве хотя бы одна книга Шекспира. 
//Используйте метод Any. 
// Проверьте есть ли в массиве книги Байрона. Используйте 
//метод Contains. 
// Отобразите первую книгу с годом выпуска 1993. 
//Используйте метод FirstOrDefault. 
// Отобразите последнюю книгу с годом выпуска 2002. 
//Используйте метод LastOrDefault.

using System;

namespace Task2
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Book> books = new List<Book>
            {
                new Book { Title="Hamlet", Author="Shakespeare", Genre="Исторический", Pages=250, Year=1993 },
                new Book { Title="Don Juan", Author="Byron", Genre="Сатира", Pages=180, Year=2002 },
                new Book { Title="Dracula", Author="Stoker", Genre="Ужасы", Pages=320, Year=1897 },
                new Book { Title="Ivanhoe", Author="Scott", Genre="Исторический", Pages=400, Year=1993 }
            };

            bool allPagesMore100 = books.All(b => b.Pages > 100);

            bool allHistoricalOrSatire = books.All(b =>
                b.Genre == "Исторический" || b.Genre == "Сатира");

            bool anyHorror = books.Any(b => b.Genre == "Ужасы");

            bool anyShakespeare = books.Any(b => b.Author == "Shakespeare");

            bool containsByron = books.Any(b => b.Author == "Byron");

            Book first1993 = books.FirstOrDefault(b => b.Year == 1993);

            Book last2002 = books.LastOrDefault(b => b.Year == 2002);
        }
    }
}