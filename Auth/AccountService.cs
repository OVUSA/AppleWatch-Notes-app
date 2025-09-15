using AppleWatch_Notes_app.Data;
using AppleWatch_Notes_app.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Auth
{
    public class AccountService

    {
        UserRepository userRepository = new UserRepository();
        public AccountService(UserRepository userRepository)
        {
            
        }
        public void Register(string userName, string userPassword)
        {
            var user = new User()
            {
                Name = userName,
                userId = Guid.NewGuid().ToString(),

            };
           var passwordHash =  new PasswordHasher<User>().HashPassword(user,userPassword);
            user.PasswordHash = passwordHash;
            userRepository.Add(user);
        }

    public void Login(string userName, string password)
        {
            var user = userRepository.GetByUserName(userName);
            new PasswordHasher<User>()
                .VerifyHashedPassword(user, user.PasswordHash, password);
        }
    }
}