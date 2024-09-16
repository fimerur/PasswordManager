using System;
using PasswordManager;

namespace PasswordManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PasswordApp manager = new PasswordApp();
            int attemptCount = 0;
            const int maxAttempts = 3;
            
            while (attemptCount < maxAttempts)
            {
                Console.Write("Введите мастер пароль: ");
                string masterPassword = Console.ReadLine()!;
                
                if (manager.VerifyMasterPassword(masterPassword!))
                {
                    Console.WriteLine("Добро пожаловать в менеджер паролей!");
                    
                    while (true)
                    {
                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Добавить новый пароль");
                        Console.WriteLine("2. Поиск пароля");
                        Console.WriteLine("3. Изменить пароль");
                        Console.WriteLine("4. Выход");
                        Console.Write("Ваш выбор: ");
                        string choice = Console.ReadLine()!;

                        switch (choice)
                        {
                            case "1":
                                Console.Write("Введите название сервиса: ");
                                string login = Console.ReadLine()!;
                                Console.Write("Введите пароль: ");
                                string password = Console.ReadLine()!;
                                manager.AddPassword(login, password);
                                break;
                            
                            case "2":
                                bool validLogin = true;
                                while (validLogin)
                                {
                                    Console.Write("Введите название сервиса (или введите 'выход' для возврата в главное меню): ");
                                    string searchlogin = Console.ReadLine()!;
        
                                    if (searchlogin! == "выход")
                                    {
                                        validLogin = true;
                                    }
                                    else
                                    {
                                        if (manager.SearchPassword(searchlogin))
                                        {
                                            validLogin = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Пароль не найден. Попробуйте снова.");
                                        }
                                    }
                                }
                                break;
                            
                            case "3":
                                Console.Write("Введите название сервиса: ");
                                string loginToChange = Console.ReadLine()!;
                                manager.ChangePassword(loginToChange); 
                                break;
                            
                            case "4":
                                Console.WriteLine("До свидания!");
                                return;
                            
                            default:
                                Console.WriteLine("Неверный формат.");
                                break;
                        }
                    }
                }
                else
                {
                    attemptCount++;
                    Console.WriteLine($"Неверный мастер-пароль. Попытка {attemptCount} из {maxAttempts}.");
                    
                    if (attemptCount != maxAttempts) continue;
                    Console.WriteLine("Превышено количество попыток ввода. Доступ заблокирован.");
                    return;
                }
            }
        }
    }
}
