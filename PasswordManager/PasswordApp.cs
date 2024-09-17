namespace PasswordManager;

public class PasswordApp
{
    private const string MasterPassword = "мультипасс";
        
    private Dictionary<string, string> passwordStorage = new Dictionary<string, string>();
        
    public bool VerifyMasterPassword(string inputPassword)
    {
        return inputPassword == MasterPassword;
    }
        
    public void AddPassword(string login, string password)
    {
        if (passwordStorage.ContainsKey(login))
        {
            Console.WriteLine($"Пароль для сервиса {login} уже существует.");
        }
        else
        {
            passwordStorage.Add(login, password);
            Console.WriteLine($"Пароль для сервиса {login} успешно добавлен.");
        }
    }
        
    public bool SearchPassword(string login)
    {
        if (passwordStorage.ContainsKey(login))
        {
            Console.WriteLine($"Пароль для {login}: {passwordStorage[login]}");
            return true;
        }
        else
        {
            Console.WriteLine($"Пароль для сервиса {login} не найден.");
            return false;
        }
    }

    public void ChangePassword(string login)
    {
        bool validLogin = false;

        while (!validLogin)
        {

            if (passwordStorage.ContainsKey(login))
            {
                bool passwordChanged = false;
                while (!passwordChanged)
                {
                    Console.Write("Введите новый пароль: ");
                    string newPassword = Console.ReadLine()!;

                    if (passwordStorage[login] == newPassword)
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
                            newPassword = userInput;
                        }
                    }
                    else
                    {
                        passwordStorage[login] = newPassword;
                        Console.WriteLine($"Пароль для сервиса {login} успешно изменен.");
                        passwordChanged = true;
                    }
                }

                validLogin = true;
            }
            else
            {
                Console.WriteLine($"Пароль для сервиса {login} не найден.");

                Console.Write("Попробуйте снова или введите 'выход' для возврата в главное меню: ");
                string userInput = Console.ReadLine()!;

                if (userInput! == "выход")
                {
                    validLogin = true;
                }
                else
                {
                    login = userInput;
                }
            }
        }
    }
}