using System;
using System.Collections.Generic;

namespace PasswordManager
{
    public class PasswordApp
    {
        // Константа для хранения мастер-пароля
        private const string MasterPassword = "мультипасс";

        // Словарь для хранения паролей (ключ - название сервиса, значение - пароль)
        private Dictionary<string, string> passwordStorage = new Dictionary<string, string>();

        // Метод для проверки мастер-пароль
        public bool VerifyMP(string inputPassword)
        {
            // Возвращает true, если введенный пароль совпадает с мастер-паролем
            return inputPassword == MasterPassword;
        }

        // Метод для добавления нового пароля
        public void AddPassword(string service, string password)
        {
            // Проверяем, есть ли уже пароль для данного сервиса
            if (passwordStorage.ContainsKey(service))
            {
                Console.WriteLine($"Пароль для сервиса {service} уже существует.");
            }
            else
            {
                // Добавляем новый пароль, если его еще нет
                passwordStorage.Add(service, password);
                Console.WriteLine($"Пароль для сервиса {service} успешно добавлен.");
            }
        }

        // Метод для поиска пароля по названию сервиса
        public bool SearchPassword(string service)
        {
            // Если пароль для данного сервиса существует, выводим его и возвращаем true
            if (passwordStorage.ContainsKey(service))
            {
                Console.WriteLine($"Пароль для {service}: {passwordStorage[service]}");
                return true;
            }
            else
            {
                // Если пароль не найден, выводим соответствующее сообщение и возвращаем false
                Console.WriteLine($"Пароль для сервиса {service} не найден.");
                return false;
            }
        }

        // Метод для изменения пароля
        public void ChangePassword(string service)
        {
            bool validService = false;

            while (!validService)
            {
                // Проверяем, существует ли пароль для данного сервиса
                if (passwordStorage.ContainsKey(service))
                {
                    bool passwordChanged = false;
                    while (!passwordChanged)
                    {
                        // Запрашиваем новый пароль у пользователя
                        Console.Write("Введите новый пароль: ");
                        string newPassword = Console.ReadLine()!;

                        // Проверяем, совпадает ли новый пароль с текущим
                        if (passwordStorage[service] == newPassword)
                        {
                            Console.WriteLine("Новый пароль совпадает с текущим.");
                            Console.WriteLine("Введите другой пароль или введите 'выход' для возврата в главное меню: ");
                            string userInput = Console.ReadLine()!;

                            if (userInput! == "выход")
                            {
                                passwordChanged = true;
                            }
                            else
                            {
                                // Устанавливаем новый пароль для повторного ввода
                                newPassword = userInput;
                            }
                        }
                        else
                        {
                            // Обновляем пароль и выходим из внутреннего цикла
                            passwordStorage[service] = newPassword;
                            Console.WriteLine($"Пароль для сервиса {service} успешно изменен.");
                            passwordChanged = true;
                        }
                    }

                    validService = true; // Выходим из внешнего цикла, так как пароль успешно изменен
                }
                else
                {
                    // Сообщение, если пароль для сервиса не найден
                    Console.WriteLine($"Пароль для сервиса {service} не найден.");

                    Console.Write("Попробуйте снова или введите 'выход' для возврата в главное меню: ");
                    string userInput = Console.ReadLine()!;

                    if (userInput! == "выход")
                    {
                        validService = true; // Выходим из внешнего цикла и возвращаемся в главное меню
                    }
                    else
                    {
                        service = userInput; // Повторно запрашиваем название сервиса
                    }
                }
            }
        }
    }
}