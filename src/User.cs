namespace chatbot
{
    class User
    {
        public string nickname;
        public int id;
        public User(int _id, string _nickname)
        {
            this.id = _id;
            this.nickname = _nickname;
        }
    }
}