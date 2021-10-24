using System;
using System.Collections.Generic;

namespace chatbot
{
    public static class Program
    {
        static List<User> connectionsUsers()
        {
            Console.Write("Введите свой ник: ");
            List<User> users = new List<User>();
            int IDs = 0;
            users.Add(new User(IDs++, "Bot"));
            users.Add(new User(IDs++, Console.ReadLine()));
            Console.WriteLine("");
            return users;
        }
        static Message input(User user)
        {
            Console.Write("\n-> ");
            string text = Console.ReadLine();
            bool isSpace = true;
            Console.CursorTop -= 2;
            foreach (char c in text)
            {
                isSpace = Char.IsWhiteSpace(c);
                if (!isSpace)
                    break;
            }
            if (isSpace)
                return null;
            return new Message(user, text);
        }
        static void Main()
        {
            List<User> users = connectionsUsers();

            // Список в кторый попадают готовые к печати сообщения,
            // но которые еще не распечатанны.
            // При выводе сообщений из списка, он очищаеться
            List<Message> messages = new List<Message>();

            // Список в ктором храняться все сообщения
            List<Message> tempList = new List<Message>();

            Message tempMessage;
            string botMessage;
            BrainOfBot Bot = new BrainOfBot();

            tempMessage = new Message(users[0], "Привет");
            messages.Add(tempMessage);
            tempList.Add(tempMessage);
            while (true)
            {
                // Вывод сообщений в консоль
                if (tempList.Count > 0)
                {
                    foreach (Message i in tempList)
                        Console.WriteLine(i.toPrint());
                    tempList.Clear();
                }

                // Ввод пользовательских сообщений
                tempMessage = input(users[1]);
                if (tempMessage != null)
                {
                    messages.Add(tempMessage);
                    tempList.Add(tempMessage);

                // Обработка пользовательских сообщений ботом
                    botMessage = Bot.Send(tempMessage, messages);
                    if (botMessage != null)
                    {
                        tempMessage = new Message(users[0], botMessage);
                        messages.Add(tempMessage);
                        tempList.Add(tempMessage);
                    }
                }
            }
        }
    }
}
