using System;


namespace TicTacToe
{
    class Program
    {
        //Вывод поля
        public static void GameField(char[] arr) 
        {
            const string gorizont = "-----------------";
            const string line1 = "|";
            const string line2 = "     |     |";

            Console.WriteLine("    TicTacToe");
            Console.WriteLine("");
            Console.WriteLine("Игрок 1: X,  Игрок 2: O");
            Console.WriteLine("Игровое поле                     Нумерация клеток");
            Console.WriteLine($"{line2}                         |     |");
            Console.WriteLine($"  {arr[1]}  {line1}  {arr[2]}  {line1}  {arr[3]}                   1  |  2  |  3");
            Console.WriteLine($"{line2}                         |     |");
            Console.WriteLine($"{gorizont}               -----------------");
            Console.WriteLine($"{line2}                         |     |");
            Console.WriteLine($"  {arr[4]}  {line1}  {arr[5]}  {line1}  {arr[6]}                   4  |  5  |  6");
            Console.WriteLine($"{line2}                         |     |");
            Console.WriteLine($"{gorizont}               -----------------");
            Console.WriteLine($"{line2}                         |     |");
            Console.WriteLine($"  {arr[7]}  {line1}  {arr[8]}  {line1}  {arr[9]}                   7  |  8  |  9");
            Console.WriteLine($"{line2}                         |     |");
        }
        //Ввод данных и определение победителя
        public static bool PlayerWinner(char Zero, char[] arr, bool GameCheck, int step) 
        {
            const char X = 'X';
            const char O = 'O';
            int player, number;
            string s = " ";
            bool flag = true;
            player = (step % 2) + 1;

            do
            {
                try
                {
                    Console.WriteLine("Ход игрока " + player);
                    Console.Write("Выберите клетку от 1 до 9: ");
                    s = Console.ReadLine();
                    number = Convert.ToInt32(s);
                    if ((s.Length == 1) && (number >= 1) && (number <= 9))
                    {
                        if (arr[number] == Zero)
                        {
                            if (player == 1)
                                arr[number] = X;
                            else arr[number] = O;
                            flag = false;
                        }
                        else Console.WriteLine("Ошибка. Выбранная клетка занята");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка. Введите номер клетки от 1 до 9");
                }
            }
            while (flag);

            //Проверочки на победу
            GameCheck = (Zero != arr[1]) && (arr[1] == arr[2]) && (arr[2] == arr[3]) || 
            (Zero != arr[4]) && (arr[4] == arr[5]) && (arr[5] == arr[6]) ||
            (Zero != arr[7]) && (arr[7] == arr[8]) && (arr[8] == arr[9]) ||
            (Zero != arr[1]) && (arr[1] == arr[4]) && (arr[4] == arr[7]) ||
            (Zero != arr[2]) && (arr[2] == arr[5]) && (arr[5] == arr[8]) ||
            (Zero != arr[3]) && (arr[3] == arr[6]) && (arr[6] == arr[9]) ||
            (Zero != arr[1]) && (arr[1] == arr[5]) && (arr[5] == arr[9]) ||
            (Zero != arr[3]) && (arr[3] == arr[5]) && (arr[5] == arr[7]);
            Console.Clear();
            GameField(arr);

            if (GameCheck)
                Console.WriteLine("Победил игрок " + player);
            else if (step == 9)
            {
                GameCheck = true;
                Console.WriteLine("Ничья");
            }
            return GameCheck;
        }
        static void Main(string[] args)
        {
            const char zero = ' ';
            char[] Field = new char[10];
            int step = 0;
            bool game = false;

            Array.Fill(Field, zero);
            GameField(Field);
            while (game == false)
            {
                game = PlayerWinner(zero, Field, game, step);
                step += 1;
            }
            Console.ReadKey();
        }
    }
}