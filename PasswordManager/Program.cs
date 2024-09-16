using System;
using PasswordManager;

namespace PasswordManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Создаем экземпляр класса PasswordApp, который управляет паролями
            PasswordApp manager = new PasswordApp();
            // Переменная для отслеживания кол-ва неверных попыток ввода мастер-пароля
            int attemptCount = 0;
            // Максимальное количество попыток ввода мастер-пароля
            const int maxAttempts = 3;

            // Цикл для предоставления пользователю возможности ввести мастер-пароль несколько раз
            while (attemptCount < maxAttempts)
            {
                // Запрос мастер-пароля у пользователя
                Console.Write("Введите мастер пароль: ");
                string masterPassword = Console.ReadLine()!;
                
                // Проверяем, правильный ли мастер-пароль введен
                if (manager.VerifyMP(masterPassword!))
                {
                    // Если пароль верный, запускаем основной функционал
                    Console.WriteLine("Добро пожаловать в менеджер паролей!");

                    // Цикл, управляющий основным функционалом менеджера паролей
                    while (true)
                    {
                        // Вывод меню с возможностями управления паролями
                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Добавить новый пароль");
                        Console.WriteLine("2. Поиск пароля");
                        Console.WriteLine("3. Изменить пароль");
                        Console.WriteLine("4. Выход");

                        // Запрос действия от пользователя
                        Console.Write("Ваш выбор: ");
                        string choice = Console.ReadLine()!;

                        // Обработка выбора пользователя
                        switch (choice)
                        {
                            // Добавление нового пароля
                            case "1":
                                Console.Write("Введите название сервиса: ");
                                string service = Console.ReadLine()!;
                                Console.Write("Введите пароль: ");
                                string password = Console.ReadLine()!;
                                manager.AddPassword(service, password); // Вызов метода добавления пароля
                                break;
                            
                            // Поиск пароля
                            case "2":
                                bool validService = true;
                                while (validService)
                                {
                                    Console.Write("Введите название сервиса (или введите 'выход' для возврата в главное меню): ");
                                    string searchService = Console.ReadLine()!;
        
                                    if (searchService! == "выход")
                                    {
                                        validService = true; // Выходим из цикла поиска и возвращаемся в главное меню
                                    }
                                    else
                                    {
                                        if (manager.SearchPassword(searchService))
                                        {
                                            validService = false; // Выходим из цикла, если пароль найден
                                        }
                                        else
                                        {
                                            Console.WriteLine("Пароль не найден. Попробуйте снова.");
                                        }
                                    }
                                }
                                break;


                            // Изменение существующего пароля
                            case "3":
                                Console.Write("Введите название сервиса: ");
                                string serviceToChange = Console.ReadLine()!;
                                manager.ChangePassword(serviceToChange); // Вызов метода изменения пароля
                                break;

                            // Выход из программы
                            case "4":
                                Console.WriteLine("До свидания!");
                                return;

                            // Сообщение об ошибке при некорректном выборе
                            default:
                                Console.WriteLine("Неверный формат.");
                                break;
                        }
                    }
                }
                else
                {
                    // Увеличиваем счетчик неверных попыток
                    attemptCount++;
                    // Вывод сообщения с количеством неверных попыток
                    Console.WriteLine($"Неверный мастер-пароль. Попытка {attemptCount} из {maxAttempts}.");
                    
                    // Если превышено максимальное количество попыток, программа завершает работу
                    if (attemptCount == maxAttempts)
                    {
                        Console.WriteLine("Превышено количество попыток ввода. Доступ заблокирован.");
                        return;
                    }
                }
            }
        }
    }
}
