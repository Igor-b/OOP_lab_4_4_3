using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace OOP_lab_4_4_3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Меню прогами:");
            Console.WriteLine("a - Додавання записiв;");
            Console.WriteLine("e - Редагування записiв;");
            Console.WriteLine("f - Видалення записiв;");
            Console.WriteLine("s - Виведення iнформацiї;");
            Console.WriteLine("n - Пошук альбому;");
            Console.WriteLine("c - Сортування за датою;");
            Console.WriteLine("q - Вихiд.");

            char check;
            int n;
            string name;

            do
            {
                check = char.Parse(Console.ReadLine());

                Collection[] disk = UpdateBasa();

                if (check == 'a')
                {
                    Console.WriteLine("Введiть новий запис до бази даних.");

                    Collection.AddInFile(Console.ReadLine());

                }
                else if (check == 'e')
                {
                    Edit(disk);

                    UpdateFile(disk);
                }
                else if (check == 'f')
                {
                    Console.Write("Введiть номер рядка який хочете видалити: ");

                    n = int.Parse(Console.ReadLine());

                    RemoveRecords(n);

                    disk = UpdateBasa();
                }
                else if (check == 's')
                {
                    Console.WriteLine("Вмiст файлу:");
                    ShowFile();
                }
                else if (check == 'n')
                {
                    Console.Write("Введiть назву альбому: ");

                    name = Console.ReadLine();

                    Search(disk, name);
                }
                else if (check == 'c')
                {
                    Sorting(disk);

                    UpdateFile(disk);

                    Console.WriteLine("База успiшно вiдсортована за датою.");
                }
                else
                {
                    if (check == 'q') Console.WriteLine("Програма завершена.");
                }
            } while (check != 'q');
        }

        public static void RemoveRecords(int n)
        {
            List<string> quotelist = File.ReadAllLines("base.txt").ToList();

            quotelist.RemoveAt(n - 1);

            File.WriteAllLines("base.txt", quotelist.ToArray());
        }

        public static void Search(Collection[] d, string name)
        {
            for (int i = 0; i < d.Length; i++)
            {
                if (d[i].NameOfAlbum == name)
                {
                    Console.WriteLine($"{d[i].Number,-10} {d[i].NameOfAlbum,15} {d[i].SizeOfDisk,15} {d[i].TypeOfDisk,15} {d[i].DateOfRecording.ToShortDateString(),15}");
                }
            }
        }

        public static void Edit(Collection[] d)
        {
        Line:
            Console.Write("Введіть номер рядка, в якому хочете щось змінити: ");

            int k = (int.Parse(Console.ReadLine())) - 1;

            if (k > d.Length)
            {
                Console.WriteLine("Такого рядка не iснує. Спробуйте iнший");
                goto Line;
            }

            Console.WriteLine("Введіть номер поля, яке хочете змінити.");

            Console.WriteLine("{0, -10} {1, 15} {2, 15} {3, 15} {4, 15}","Номер", "Альбом", "Розмiр диску", "Тип диску", "Дата запису");
            
            int pole = int.Parse(Console.ReadLine());

            Console.Write("Введіть нове значення: ");

            string val = Console.ReadLine();

            switch (pole)
            {
                case 1:
                    d[k].Number = val;
                    break;

                case 2:
                    d[k].NameOfAlbum = val;
                    break;

                case 3:
                    d[k].SizeOfDisk = double.Parse(val);
                    break;

                case 4:
                    d[k].TypeOfDisk = val;
                    break;

                case 5:
                    string[] data = val.Split('.');
                    int day = int.Parse(data[0]);
                    int month = int.Parse(data[1]);
                    int year = int.Parse(data[2]);
                    d[k].DateOfRecording = new DateTime(year, month, day);
                    break;

                default:
                    Console.WriteLine("Поля з таким номером не існує!");
                    break;
            }
        }

        public static void Sorting(Collection[] d)
        {
            Array.Sort(d, new DateComparer());
        }

        public static void UpdateFile(Collection[] d)
        {
            StreamWriter file = new StreamWriter("base.txt");

            for (int i = 0; i < d.Length; i++)
            {
                file.WriteLine("{0, -10} {1, 15} {2, 15} {3, 15} {4, 15}", d[i].Number, d[i].NameOfAlbum, d[i].SizeOfDisk, d[i].TypeOfDisk, d[i].DateOfRecording.ToShortDateString());
            }

            file.Close();
        }

        public static void ShowFile()
        {
            StreamReader file = new StreamReader("base.txt");

            Console.WriteLine(file.ReadToEnd());

            file.Close();
        }

        public static Collection[] UpdateBasa()
        {
            int k = 0;
            int i = 0;

            StreamReader file = new StreamReader("base.txt");

            string line;

            while ((line = file.ReadLine()) != null)
            {
                k++;
            }

            file.BaseStream.Position = 0;

            Collection[] basa = new Collection[k];

            while ((line = file.ReadLine()) != null)
            {
                basa[i] = new Collection(line);
                k++;
                i++;
            }

            file.Close();

            return basa;

        }
    }

}