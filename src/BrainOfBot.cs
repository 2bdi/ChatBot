using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace chatbot
{
    class BrainOfBot
    {
        DateTime runningBot = DateTime.Now;
        private Regex reTime = new Regex(@"врем\w+");
        private Regex reName = new Regex(@"(зов|имя|редстав)");
        private Regex reHowU = new Regex(@"(дела|живае)");
        private Regex reWork = new Regex(@"(раб|включен)");
        private Regex reMess = new Regex(@"(историю|сообщени)");
        private Regex reClea = new Regex(@"(чисти|дали.+сообщени)");

        private string getTime()
        {
            string time = DateTime.Now.ToString("F");
            return $"Сейчас {time}.";
        }
        private string getName()
        {
            return "Меня зовут Bot!";
        }
        private string getHowU()
        {
            return "У меня все хорошо";
        }
        private string getWork()
        {
            TimeSpan currentTime = (DateTime.Now - this.runningBot);
            string time = currentTime.ToString("T").Split('.')[0];
            return $"С момента запуска прошло {time}.";
        }
        private string getMessage(List<Message> messages)
        {
            string result = "Все наши сообщения:";
            foreach (Message m in messages)
            {
                string head = $"[{m.GetTime()} - {m.GetSenderName()}] ";
                string text = head + m.GetText();
                if (text.Length + 1  > Console.WindowWidth)
                    text = text.Substring(0, Console.WindowWidth - 5) + "...";
                result = result + "\n" + text ;
            }
            return result;
        }
        private string getClea()
        {
            Console.Clear();
            return "Окно очищено!";
        }

        public string Send(Message message, List<Message> messages)
        {
            string textMessage = message.GetText().ToLower();

            if (reTime.Matches(textMessage).Count > 0) return getTime();
            if (reName.Matches(textMessage).Count > 0) return getName();
            if (reHowU.Matches(textMessage).Count > 0) return getHowU();
            if (reWork.Matches(textMessage).Count > 0) return getWork();
            if (reClea.Matches(textMessage).Count > 0) return getClea();
            if (reMess.Matches(textMessage).Count > 0) return getMessage(messages);

            return null;
        }
    }
}