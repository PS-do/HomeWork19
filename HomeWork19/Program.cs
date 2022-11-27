using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer(){ Code =1,BrandName="HP 290 G4 MT Micro-Tower",CPU_Type="Intel Core i3-10100",CPU_Rate=3600,RAM_size=4*1024,HDD_size=1024,GPU_RAM_size=3*1024,Coast=42000,Pcs=24},
                new Computer(){ Code =2,BrandName="Robotcomp Black Star",CPU_Type="Robotcomp Black Star",CPU_Rate=3500,RAM_size=16*1024,HDD_size=240,GPU_RAM_size=2*1024,Coast=42000,Pcs=124},
                new Computer(){ Code =3,BrandName="NOTEXE FB3",CPU_Type="Intel Core i5-11400F",CPU_Rate=2600 ,RAM_size=8*1024,HDD_size=1024,GPU_RAM_size=8*1024,Coast=73290 ,Pcs=38},
                new Computer(){ Code =4,BrandName="Raskat Start 100",CPU_Type="AMD A6-9500E",CPU_Rate=3000,RAM_size=4*1024,HDD_size=0,GPU_RAM_size=4*1024,Coast=9990,Pcs=42},
                new Computer(){ Code =5,BrandName="Intel",CPU_Type="Intel Core i5-10600KF",CPU_Rate=4100,RAM_size=4*1024,HDD_size=1024,GPU_RAM_size=8*1024,Coast=78996,Pcs=147},
                new Computer(){ Code =6,BrandName="Intel",CPU_Type="Intel Core i5-10400F",CPU_Rate=2900,RAM_size=4*1024,HDD_size=1024/2,GPU_RAM_size=6*1024,Coast=66968,Pcs=29},
                new Computer(){ Code =7,BrandName="Gamer - 636",CPU_Type="Intel Core i5-10600KF",CPU_Rate=4100,RAM_size=4*1024,HDD_size=1024,GPU_RAM_size=2*1024,Coast=62096,Pcs=11},
                new Computer(){ Code =8,BrandName="Компьютер для дома и офиса home and office - 1821",CPU_Type="Intel Core i5-11600K",CPU_Rate=3900,RAM_size=4*1024,HDD_size=1024,GPU_RAM_size=0,Coast=53189,Pcs=2},
                new Computer(){ Code =9,BrandName="HP 290 G4 MT Micro-Tower",CPU_Type="Intel Core i3-10100",CPU_Rate=3600,RAM_size=4*1024,HDD_size=1024,GPU_RAM_size=3*1024,Coast=42000,Pcs=24}
            };

            Console.WriteLine("все компьютеры с указанным процессором. Название процессора запросить у пользователя");
            Console.WriteLine("Введите название процессора");
            //Console.Write("Intel Core i5-10600KF");  //<<< Таким образом я хотел сделать значение по умолчанию, которое при желании можно было бы откорректировать. Почему не сработало?
            string CPU_Type1 = Console.ReadLine();
            List<Computer> ComputerList = computers.Where(x => x.CPU_Type == CPU_Type1).ToList();
            Print_List(ComputerList);

            Console.WriteLine("все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя");
            Console.WriteLine("Введите min RAM_size");
            int minRAM_size = Convert.ToInt32(Console.ReadLine());
            ComputerList = computers.Where(x => x.RAM_size >= minRAM_size).ToList();
            Print_List(ComputerList);

            Console.WriteLine("весь список, отсортированный по увеличению стоимости");
            ComputerList = computers.OrderBy(x => x.Coast).ToList();
            Print_List(ComputerList);

            Console.WriteLine("\nnвывести весь список, сгруппированный по типу процессора");
            foreach (IGrouping<string, Computer> gr in computers.GroupBy(x => x.CPU_Type))
            {
                Console.WriteLine(gr.Key);
                foreach (Computer c in gr)
                {
                    Console.WriteLine($"{c.Code}\t{c.BrandName}\t{c.CPU_Type}\t{c.CPU_Rate}\t{c.RAM_size}\t{c.HDD_size}\t{c.GPU_RAM_size}\t{c.Coast}\t{c.Pcs}");
                }
            }

            //найти самый дорогой и самый бюджетный компьютер;
            Console.WriteLine("Самый дешёвый ПК:");
            Print(computers.OrderByDescending(x => x.Coast).LastOrDefault());
            Console.WriteLine("Самый дорогой ПК:");
            Print(computers.OrderByDescending(x => x.Coast).FirstOrDefault());

            //есть ли хотя бы один компьютер в количестве не менее 30 штук
            Console.WriteLine(computers.Any(x=>x.Pcs>=30));
            Console.ReadKey();
        }

        static void Print_List(List<Computer> computers)
        {
            Console.WriteLine("{c.Code}\t{c.BrandName}\t{c.CPU_Type}\t{c.CPU_Rate}\t{c.RAM_size}\t{c.HDD_size}\t{c.GPU_RAM_size}\t{c.Coast}\t{c.Pcs}");
            foreach (Computer c in computers)
            {
                Print(c);
            }
            Console.WriteLine();
        }
        static void Print(Computer c)
        {
            Console.WriteLine($"{c.Code}\t{c.BrandName}\t{c.CPU_Type}\t{c.CPU_Rate}\t{c.RAM_size}\t{c.HDD_size}\t{c.GPU_RAM_size}\t{c.Coast}\t{c.Pcs}");
        }
        //Модель компьютера  характеризуется
        //кодом  и
        //названием  марки компьютера,
        //типом  процессора,
        //частотой работы  процессора,
        //объемом оперативной памяти,
        //объемом жесткого диска,
        //объемом памяти видеокарты,
        //стоимостью компьютера в условных единицах и
        //количеством экземпляров, имеющихся в наличии
        //.Создать список, содержащий 6-10 записей с различным набором значений характеристик.
        public class Computer
        {
            public int Code { get; set; }
            public string BrandName { get; set; }            //названием  марки компьютера,
            public string CPU_Type { get; set; }            //типом  процессора,
            public int CPU_Rate { get; set; }            //частотой работы  процессора, МГц
            public int RAM_size { get; set; }    // объемом оперативной памяти, MB
            public double HDD_size { get; set; }        //объемом жесткого диска, ГБ
            public double GPU_RAM_size { get; set; }        //объемом памяти видеокарты, MB
            public decimal Coast { get; set; }            //стоимостью компьютера в условных единицах и
            public int Pcs { get; set; }            //количеством экземпляров, имеющихся в наличии
        }
    }
}
