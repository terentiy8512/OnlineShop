using System;
namespace Assignment2.Data
{
    public interface IWebAPIRepo
    {
        public bool UserExistOrNot(Users user);

        public Users AddUser(Users user);

        public bool ValidLogin(string userName, string Password);

        public Orders AddOrder(Orders order);

        public Orders GetOrder(int id);
    }
}
