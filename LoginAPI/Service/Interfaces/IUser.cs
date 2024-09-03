using LoginApi.Models;
using System;

namespace LoginApi.Service.Interfaces
{
    public interface IUser
    {
        void CreateUser(User user);
        User GetUser(string username, string password);
        void UpdateUser(User user);
        void Delete(string id);
    }
}
