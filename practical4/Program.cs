namespace practical4
{
    internal class Program
    {
        public static int cursorpos = 1;
        public static int MoveDay = 0;
        public static DateTime mydate = new DateTime(2022, 10, 11);
        public static Nouns FirstOne = new Nouns()
        {
            name = "Практические по Python",
            data = new DateTime(2022, 10, 11),
            day = 11,
            description = "Сесть наконец за компьютер и сделать практические по Python."
        };
        public static Nouns FirstTwo = new Nouns()
        {
            name = "Работа",
            data = new DateTime(2022, 10, 11, 18, 30 , 0),
            day = 11,
            description = "Не забыть, что добавили дополнительную смену."
        };
        public static Nouns FirstThree = new Nouns()
        {
            name = "Отмена пары",
            data = new DateTime(2022, 10, 11),
            day = 11,
            description = "Не забыть, что последнюю пару отменили."
        };
        public static Nouns SecondOne = new Nouns()
        {
            name = "День спячки",
            data = new DateTime(2022, 10, 27),
            day = 27,
            description = "Забыть в этот день про все и поспать 15 часов."
        };
        public static Nouns SecondTwo = new Nouns()
        {
            name = "Фильм",
            data = new DateTime(2022, 10, 27),
            day = 27,
            description = "Посмотреть фильм, который уже месяцами лежит в заметках."
        };
        public static Nouns ThirdOne = new Nouns()
        {
            name = "Выход альбома",
            data = new DateTime(2022, 11, 4),
            day = 4,
            description = "В этот день забыть про все, и послушать долгожданный альбом."
        };
        public static List<Nouns> daylist = new List<Nouns>();


        static void Main()
        {
            daylist.Add(FirstOne);
            daylist.Add(FirstTwo);
            daylist.Add(FirstThree);
            daylist.Add(SecondOne);
            daylist.Add(SecondTwo);
            daylist.Add(ThirdOne);
            Console.WriteLine("Это ежедневник , Для выхода нажми ESC");
            while (true)
            {
                SelectedDate();
                ConsoleKeyInfo key = Console.ReadKey();
                buttons(key);
            }
        }

        private static void SelectedDate()
        {
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"   Выбрана дата: {mydate.AddDays(MoveDay)}");
            Console.SetCursorPosition(3, 2);
            int n = 0;
            foreach (var item in daylist)
            {
                if(item.data == mydate.AddDays(MoveDay) )
                {
                    Console.WriteLine($"{n + 1}. {item.name}");
                }
            }
            Console.SetCursorPosition(0, cursorpos);
        }

        static void buttons(ConsoleKeyInfo Choice)
        {
            switch(Choice.Key)
            {
                case ConsoleKey.RightArrow:
                    MoveDay = MoveDay + 1;
                    break;

                case ConsoleKey.LeftArrow:
                    MoveDay = MoveDay - 1;
                    break;

                case ConsoleKey.DownArrow:
                    if (cursorpos > daylist.Where(i => i.day == MoveDay).ToList().Count + 1)
                    {
                    }
                    else
                    {
                        cursorpos += 1;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (cursorpos < 2)
                    {
                        cursorpos = 2;
                    }
                    else
                    {
                        cursorpos -= 1;
                    }
                    break;

                case ConsoleKey.Enter:
                    Console.Clear();
                    Console.SetCursorPosition(2, 2);
                    Fully();
                    break;

                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
            Cursor();
        }
        
        private static void Fully()
        {
            int n = 0;
            foreach (var item in daylist)
            {
                if (item.day == mydate.AddDays(MoveDay).Day)
                {
                    Console.WriteLine($"{item.name}\n    Поддробности: {item.description}");
                }
            }
            Console.ReadKey();
        }

        private static void Cursor()
        {
            Console.Clear();
            Console.SetCursorPosition(0, cursorpos);
            Console.Write("->");
        }
    }
}