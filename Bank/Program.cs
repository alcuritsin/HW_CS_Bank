using System;

namespace Bank
{
    class Program
    {
        static void Main()
        {
            ShowConsole(":: Банк ::");
            //  Создаём инвестора
            Investor investor = new Investor("Василий Васильев", 1990, Month.August, 5);
            // Добавляем в делегат ссылку на метод ShowConsole
            // а сам делегат передается в качестве параметра метода RegisterHandler
            investor.RegistrHandler(new Investor.AccountStateHandler(ShowConsole));

            //  Проверяем состояние инвестора
            investor.info();

            //  Открываем счёт
            investor.OpenAccount();

            //  Проверяем состояние инвестора
            investor.info();

            //  Кладем на счет 100
            investor.DepositMoney(100);

            //  Проверяем состояние инвестора
            investor.info();

            //  Снимаем 50
            investor.WithdrawMoney(50);

            //  Проверяем состояние инвестора
            investor.info();

            //  Пытаемся закрыть счет
            investor.CloseAccount();  //  Вернуть должно false, а на экран вывести сообщение что закрыть нельзя.

            //  Проверяем состояние инвестора
            investor.info();

            //  Снимаем все деньги
            investor.WithdrawAllMoney();

            //  Проверяем состояние инвестора
            investor.info();

            //  Пытаемся закрыть счет
            investor.CloseAccount();  //  Вернуть должно true, а на экран вывести сообщение что счёт закрыт.

            //  Проверяем состояние инвестора
            investor.info();
        }
        private static void ShowConsole(string message)
        {
           Console.WriteLine($"{message}");
        }
    }
}
