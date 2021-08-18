using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{

    public class Investor : Human
    {
        //  Объявляем делегат
        public delegate void AccountStateHandler(string message);

        //  Создаём переменную делегата
        AccountStateHandler _del;
        string _accountNumber { get; set; }  //  Номер счета.
        bool _accountIsOpen { get; set; }  //  Счёт открыт.
        double _accauntBalans { get; set; }  //  Баланс на счету.
        public Investor(string name, uint yearBirth, Month monthBirth, uint dayBirth) : base(name, yearBirth, monthBirth, dayBirth)
        {
            _accauntBalans = 0;
        }

        public void RegistrHandler(AccountStateHandler del)
        {
            _del = del;
        }
        public void DepositMoney(double summ)
        {
            //  Весение денег
            if (_del!=null)
            {
                _del("operation: DepositMoney");
            }
            if (_accountIsOpen)
            {
                _accauntBalans += summ;
                if (_del != null)
                {
                    _del($"Сумма: {summ} внесена на счет # {_accountNumber}.");
                }
            }
            else
            {
                if (_del != null)
                {
                    _del($"У клиента отсутствует счет. Необходимо вначале открыть счет.");
                }
            }
        }

        public void WithdrawMoney(double summ)
        {
            //  Снятие денег
            if (_del != null)
            {
                _del("operation: WithdrawMoney");
            }

            if (_accountIsOpen)
            {
                if (summ <= _accauntBalans)
                {
                    _accauntBalans -= summ;
                    if (_del != null)
                    {
                        _del($"Сумма: {summ} снята со счета # {_accountNumber}.");
                    }
                }
                else
                {
                    if (_del != null)
                    {
                        _del($"Недостаточно средств для снятия со счета # {_accountNumber}.");
                    }
                }
            }
            else
            {
                if (_del != null)
                {
                    _del($"У клиента отсутствует счет. Необходимо вначале открыть счет.");
                }
            }

        }

        public bool CloseAccount()
        {
            //  Закрыть счёт
            if (_del != null)
            {
                _del("operation: CloseAccount");
            }

            if (_accountIsOpen)
            {
                //  Счет открыт можно попробовать закртыть
                if (_accauntBalans > 0)
                {
                    //  На балансе есть средства
                    if (_del!=null)
                    {
                        _del("Счет не может быть закрыт, пока на нём есть средства");
                    }
                        return false; //  счет ещё не закрыт
                }
                else
                {
                    //  Баланс пустой, можно производить закрытие счета
                    _accountIsOpen = false;
                    if (_del !=null)
                    {
                    _del($"Счёт # {_accountNumber} закрыт. Больше он не существует.");

                    }
                    _accountNumber = "";
                    return true;  //  удачное закрытие
                }
            }
            else
            {
                //  Счет уже закрыт или не существует
                if (_del != null)
                {
                    _del($"У клиента нет счета для закрытия");
                }
                return false;  //  вернуть утверждение
            }
        }

        public bool OpenAccount()
        {
            //  Открытие счета
            if (_del != null)
            {
                _del("operation: OpenAccount");
            }

            if (_accountIsOpen)
            {
                //  Счёт уже открыт
                if (_del != null)
                {
                    _del("Счёт уже открыт");
                }
                return false;  //  вернуть отрицание
            }
            else
            {
                _accountIsOpen = true;
                _accountNumber = DateTime.Now.ToString();
                if (_del != null)
                {
                    _del($"Открыт счет # {_accountNumber}");
                }
                return true;  //  вернуть утверждение
            }
        }

        public void WithdrawAllMoney()
        {
            //  Снятие всех денег
            if (_del != null)
            {
                _del("\noperation: WithdrawAllMoney");
            }

            if (_accountIsOpen && _accauntBalans > 0)
            {
                if (_del!=null)
                {
                    _del($"Выдоно: {_accauntBalans} со счёта # {_accountNumber}");
                }
                _accauntBalans = 0; //  Обнуляем баланс
            }
        }
        public void info()
        {
            if (_del !=null)
            {
                _del(
                    $"\n               User: {_name}\n" +
                    $"              Birth: {_dayBirth}.{_monthBirth}.{_yearBirth}\n" +
                    "StatusAccountNumber: " + (_accountIsOpen?"open":"close") + "\t" + $"AccountNumber: {_accountNumber}\n" +
                    $"             Balans: {_accauntBalans}\n"
                    );
            }
        }
    }
}
