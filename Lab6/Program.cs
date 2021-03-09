using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создание массива
            Car[] array = new Car[4] {
                new Car(),
                null,
                new Car(),
                new DeLoreanTM()
            };
            //Проверка на количество элементов, не равных null
            Console.WriteLine($"Количество элементов, не равных null - {notNull<Car>(array)}");

            //Создание коллекции ArrayList
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new Car("Opel", 120));
            arrayList.Add(new DeLoreanTM("FGT-89", 150));
            arrayList.Add(new Car("BMW", 149));
            arrayList.Add(new DeLoreanTM());
            arrayList.Add(new Car());
            arrayList.Add(new Car("Hamer", 178));
            arrayList.Add(new DeLoreanTM("KLO-15", 113));

            //Создание коллекции Dictionary
            Dictionary<int, Car> dicCar = new Dictionary<int, Car>(5);
            dicCar.Add(4, new Car("Pegout", 143));
            dicCar.Add(2, new DeLoreanTM("LGR7-75", 98));
            dicCar.Add(5, new DeLoreanTM("XRT-15", 75));
            dicCar.Add(1, new Car("Volvo", 171));
            dicCar.Add(3, new Car("Ferrari", 180));

            //Вывод меню на экран
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|            Меню для ArrayList:           |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1 – просмотр коллекции");
            Console.WriteLine("2 – добавление элемента");
            Console.WriteLine("3 – добавление элемента по указанному индексу");
            Console.WriteLine("4 – нахождение элемента с начала коллекции");
            Console.WriteLine("5 – нахождение элемента с конца коллекции");
            Console.WriteLine("6 – удаление элемента по индексу");
            Console.WriteLine("7 – удаление элемента по значению");
            Console.WriteLine("8 – реверс коллекции");
            Console.WriteLine("9 – сортировка");
            Console.WriteLine("10 – выполнение методов всех объектов, поддерживающих Interface2");
            Console.WriteLine("0 – выход");

            //Цикл считывания пунктов меню и выполнения методов
            bool r = true;
            while (r)
            {
                Console.Write("\nВыбрать пункт меню: ");
                string point = Console.ReadLine();
                int p;
                if (!Int32.TryParse(point, out p)) continue; //Проверка на корректность ввода
                switch (p)
                {
                    case 1: method1(arrayList); break;
                    case 2: method2(arrayList); break;
                    case 3: method3(arrayList); break;
                    case 4: method4(arrayList); break;
                    case 5: method5(arrayList); break;
                    case 6: method6(arrayList); break;
                    case 7: method7(arrayList); break;
                    case 8: method8(arrayList); break;
                    case 9: method9(arrayList); break;
                    case 10: method10(arrayList); break;
                    case 0: r = false; break;
                }
            }

            //----------------------------------------------------------------------------------

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|            Меню для Dictionary:          |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1 – просмотр коллекции");
            Console.WriteLine("2 – добавление элемента в конец");
            Console.WriteLine("3 – добавление элемента по указанному индексу");
            Console.WriteLine("4 – нахождение элемента в коллекции по значению");
            Console.WriteLine("5 – удаление элемента по индексу");
            Console.WriteLine("6 – удаление элемента по значению");
            Console.WriteLine("7 – выполнение методов всех объектов, поддерживающих Interface2");
            Console.WriteLine("0 – выход");

            //Цикл считывания пунктов меню и выполнения методов
            r = true;
            while (r)
            {
                Console.Write("\nВыбрать пункт меню: ");
                string point = Console.ReadLine();
                int p;
                if (!Int32.TryParse(point, out p)) continue; //Проверка на корректность ввода
                switch (p)
                {
                    case 1: method1(dicCar); break;
                    case 2: method2(dicCar); break;
                    case 3: method3(dicCar); break;
                    case 4: method4(dicCar); break;
                    case 5: method5(dicCar); break;
                    case 6: method6(dicCar); break;
                    case 7: method7(dicCar); break;
                    case 0: r = false; break;
                }
            }

        }
        //обобщенный метод, который получает массив произвольного типа и возвращает количество элементов, не равных null
        static int notNull<T>(T[] arr)
        {
            int num = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != null) num++;
            }
            return num;
        }

        //-------------------- Методы для ArrayList --------------------

        static void method1(ArrayList arrayList)    //Вывод коллекции
        {
            int i = 0;
            foreach (object obj in arrayList)
            {
                Console.WriteLine($"{i++}) {(obj as Car)?.ToString()}");
            }
        }
        static void method2(ArrayList arrayList)    //Добавление элемента
        {
            Console.Write("Добавить 1 - Car, 2 - Time machine DeLorean: ");
            string point = Console.ReadLine();
            int p;
            if (!Int32.TryParse(point, out p) || p < 1 || p > 2)
            {
                Console.WriteLine("Некорректный ввод."); 
                return;
            }
            Console.Write("name: ");
            string name = Console.ReadLine();
            Console.Write("speed: ");
            point = Console.ReadLine();
            int speed;
            Int32.TryParse(point, out speed);
            switch (p)
            {
                case 1: arrayList.Add(new Car(name, speed)); break;
                case 2: arrayList.Add(new DeLoreanTM(name, speed)); break;
            }
        }
        static void method3(ArrayList arrayList)    //Добавление элемента по индексу
        {
            Console.Write("Введите индекс: ");
            string point = Console.ReadLine();
            int index;
            if (!Int32.TryParse(point, out index) || index < 0 || index > arrayList.Count)
            {
                Console.WriteLine("Введен неверный индекс.");
                return;
            }
            Console.Write("Добавить 1 - Car, 2 - Time machine DeLorean: ");
            point = Console.ReadLine();
            int p;
            if (!Int32.TryParse(point, out p) || p < 1 || p > 2)
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }
            Console.Write("name: ");
            string name = Console.ReadLine();
            Console.Write("speed: ");
            point = Console.ReadLine();
            int speed;
            Int32.TryParse(point, out speed);
            switch (p)
            {
                case 1: arrayList.Insert(index, new Car(name, speed)); break;
                case 2: arrayList.Insert(index, new DeLoreanTM(name, speed)); break;
            }
        }
        static void method4(ArrayList arrayList)    //Нахождение элемента с начала коллекции
        {
            Console.Write("name: ");
            string name = Console.ReadLine();
            Car car = new Car(name, 0);
            int index = arrayList.IndexOf(car);
            Console.WriteLine(index>-1
                ? $"\nИндекс = {index}: {arrayList[index]}" 
                : "Элемент не найден");
        }
        static void method5(ArrayList arrayList)    //Нахождение элемента с конца коллекции
        {
            Console.Write("name: ");
            string name = Console.ReadLine();
            Car car = new Car(name, 0);
            int index = arrayList.LastIndexOf(car);
            Console.WriteLine(index > -1
                ? $"\nИндекс = {index}: {arrayList[index]}"
                : "Элемент не найден");
        }
        static void method6(ArrayList arrayList)    //Удаление элемента по индексу
        {
            Console.Write("Индекс: ");
            string point = Console.ReadLine();
            int index;
            if (!Int32.TryParse(point, out index) || index < 0 || index >= arrayList.Count)
            {
                Console.WriteLine("Неверный индекс.");
                return;            
            }
            arrayList.RemoveAt(index);
            Console.WriteLine("Элемент успешно удален.");
        }
        static void method7(ArrayList arrayList)    //Удаление элемента по значению
        {
            Console.Write("name: ");
            string name = Console.ReadLine();
            Car car = new Car(name, 0);
            arrayList.Remove(car);
            Console.WriteLine("Элемент удален");
        }
        static void method8(ArrayList arrayList)    //Реверс коллекции
        {
            arrayList.Reverse();
        }
        static void method9(ArrayList arrayList)    //Сортировка
        {
            arrayList.Sort();
        }
        static void method10(ArrayList arrayList)   //Выполнение методов всех объектов, поддерживающих Interface2
        {
            foreach (object obj in arrayList)
            {
                Console.WriteLine(obj);
                Console.WriteLine((obj as IFlying)?.fly());
                Console.WriteLine("-------");
            }
        }

        //-------------------- Перегруженные методы для Dictionary --------------------

        static void method1(Dictionary<int, Car> dicCar)    //Просмотр коллекции
        {
            //словарь в нашем случае будет хранить объекты KeyValuePair<int, Car>
            foreach (KeyValuePair<int, Car> keyValue in dicCar)
            {
                Console.WriteLine($"{keyValue.Key}) {keyValue.Value}");
            }
        }
        static void method2(Dictionary<int, Car> dicCar)    //Добавление элемента
        {
            Console.Write("Добавить 1 - Car, 2 - Time machine DeLorean: ");
            string point = Console.ReadLine();
            int p;
            if (!Int32.TryParse(point, out p) || p < 1 || p > 2)
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }
            Console.Write("name: ");
            string name = Console.ReadLine();
            Console.Write("speed: ");
            point = Console.ReadLine();
            int speed;
            Int32.TryParse(point, out speed);
            Console.Write("point: ");
            point = Console.ReadLine();
            int ind;
            Int32.TryParse(point, out ind);
            if (dicCar.ContainsKey(ind)) 
            {
                Console.WriteLine($"Ошибка добавления данных. Ключ {ind} уже существует.");
                return;
            }
            switch (p)
            {
                case 1: dicCar.Add(ind, new Car(name, speed)); break;
                case 2: dicCar.Add(ind, new DeLoreanTM(name, speed)); break;
            }
        }
        static void method3(Dictionary<int, Car> dicCar)    //Добавление элемента по индексу
        {
            Console.Write("Введите индекс: ");
            string point = Console.ReadLine();
            int index;
            if (!Int32.TryParse(point, out index) || !dicCar.ContainsKey(index))  //если не получилось преобразовать и ключ отсутствует в словаре
            {
                Console.WriteLine("Введен неверный индекс.");
                return;
            }
            Console.Write("Добавить 1 - Car, 2 - Time machine DeLorean: ");
            point = Console.ReadLine();
            int p;
            if (!Int32.TryParse(point, out p) || p < 1 || p > 2)
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }
            Console.Write("name: ");
            string name = Console.ReadLine();
            Console.Write("speed: ");
            point = Console.ReadLine();
            int speed;
            Int32.TryParse(point, out speed);
            switch (p)
            {
                case 1: dicCar[index] = new Car(name, speed); break;
                case 2: dicCar[index] = new DeLoreanTM(name, speed); break;
            }
        }
        static void method4(Dictionary<int, Car> dicCar)    //Нахождение элемента в коллекции по значению
        {
            Console.Write("name: ");
            string name = Console.ReadLine();
            bool h = true;
            foreach (KeyValuePair<int, Car> keyValue in dicCar) //KeyValuePair определяет пару ключ-значение, которая может быть задана или получена
            {
                if (name == keyValue.Value.name)    //Value - возвращает значение из пары ключ-значение
                {
                    if (keyValue.Value is DeLoreanTM)
                    {
                        Console.WriteLine($"{keyValue.Key}) {(DeLoreanTM)keyValue.Value}");
                    }
                    else Console.WriteLine($"{keyValue.Key}) {keyValue.Value}");
                    h = false; 
                    break;
                }
            }
            if (h) Console.WriteLine("Объект не найден");
        }
        static void method5(Dictionary<int, Car> dicCar)    //Удаление элемента по индексу
        {
            Console.Write("Введите индекс: ");
            string point = Console.ReadLine();
            int index;
            if (!Int32.TryParse(point, out index) || !dicCar.ContainsKey(index))  //если не получилось преобразовать или ключ отсутствует в словаре
            {
                Console.WriteLine("Введен неверный индекс.");
                return;
            }
            dicCar.Remove(index);
            Console.WriteLine("Элемент успешно удален.");
        }
        static void method6(Dictionary<int, Car> dicCar)    //Удаление элемента по значению
        {
            Console.Write("name: ");
            string name = Console.ReadLine();
            foreach (KeyValuePair<int, Car> keyValue in dicCar)
            {
                if (name == keyValue.Value.name)
                {
                    dicCar.Remove(keyValue.Key);
                    Console.WriteLine("Удаление завершено");
                    return;
                }
            }
            Console.WriteLine("Объект не найден");
        }
        static void method7(Dictionary<int, Car> dicCar)    //Выполнение методов всех объектов, поддерживающих Interface2
        {
            foreach (KeyValuePair<int, Car> keyValue in dicCar)
            {
                Console.WriteLine($"{keyValue.Key}) {keyValue.Value}");
                Console.WriteLine($"{(keyValue.Value as IFlying)?.fly()}");
                Console.WriteLine("-------");
            }
        }
    }
}
