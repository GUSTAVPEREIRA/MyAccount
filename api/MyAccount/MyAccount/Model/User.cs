using System;
using System.Security.Cryptography;
using System.Text;

namespace MyAccount.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; private set; }
        public string Name { get; set; }
        public DateTime CreatedAt
        {
            get
            {
                return _CreatedAt.ToLocalTime();
            }
            private set
            {
                _CreatedAt = value;
            }
        }

        public DateTime UpdatedAt
        {
            get
            {
                return _UpdatedAt.ToLocalTime();
            }
            set
            {
                _UpdatedAt = value;
            }
        }

        private DateTime _UpdatedAt { get; set; }
        private DateTime? _DeletedAt { get; set; }
        private DateTime _CreatedAt { get; set; }
        public DateTime? DeletedAt
        {
            get
            {
                if (_DeletedAt.HasValue)
                {
                    return _DeletedAt.Value.ToLocalTime();
                }

                return null;
            }
            private set
            {
                _DeletedAt = value;
            }
        }

        public User()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public User(string username, string password)
        {
            Username = username;
            SetPassword(password);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            DeletedAt = new DateTime?();
        }

        public void DisableUser()
        {
            DeletedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void EnableUser()
        {
            DeletedAt = null;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                Password = password;
                StringBuilder keyPassword = new StringBuilder();
                MD5 md5 = MD5.Create();
                byte[] input = Encoding.ASCII.GetBytes("//" + this.Password);
                byte[] hash = md5.ComputeHash(input);

                for (int i = 0; i < hash.Length; i++)
                {
                    keyPassword.Append(hash[i].ToString("X2"));
                }

                Password = keyPassword.ToString();
            }
            else
            {
                Password = "";
            }
        }
    }
}