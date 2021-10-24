using System;

namespace chatbot
{
    class Message
    {
        private DateTime datetimeOfPush;
        private User sender;
        private bool viewed;
        private string text;
        public Message(User _user, string _text)
        {
            this.datetimeOfPush = DateTime.Now;
            this.sender = _user;
            this.text =_text;
            this.viewed = false;
        }
        public string GetText()
        {
            if (!this.viewed)
                this.viewed = true;
            return this.text;
        }
        public string GetSenderName()
        {
            return this.sender.nickname;
        }
        public string GetTime()
        {
            return this.datetimeOfPush.ToString("t");
        }
        public string toPrint()
        {
            string head = $"[{GetTime()}]: -- {GetSenderName()} -- ";
            if (head.Length < this.text.Length)
                head = head + new string(' ', 3 + this.text.Length - head.Length);
            return $"\n{head}\n{this.text}";
        }
    }
}