
namespace _01_Life_Demo_Project.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    public class User
    {
        private string password;

        public User()
        {

        }

        public User(string name, string password)
        {
            this.Username = name;
            this.Password = password;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //{
        //    get { return this.password; }
        //    set
        //    {
        //        if (string.IsNullOrWhiteSpace(value))
        //        {
        //            throw new ArgumentException("Incorect password");
        //        }
        //        this.password = GetSHA1HashData(value);
        //    }
        //}

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();


        /// <summary>
        /// take any string and encrypt it using SHA1 then
        /// return the encrypted data
        /// </summary>
        /// <param name="data">input text you will enterd to encrypt it</param>
        /// <returns>return the encrypted text as hexadecimal string</returns>
        private static string GetSHA1HashData(string data)
        {
            //create new instance of md5
            SHA1 sha1 = SHA1.Create();

            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();
        }
    }
}
