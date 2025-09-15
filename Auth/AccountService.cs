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
        JwtService jwtService = new JwtService();
        public AccountService()
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

    public string Login(string userName, string password)
        {
            var user = userRepository.GetByUserName(userName);
            var result =  new PasswordHasher<User>()
                .VerifyHashedPassword(user, user.PasswordHash, password);

            if(result == PasswordVerificationResult.Success)
            {
               return jwtService.GenerateToken(user);
            }
            else
            {
                throw new Exception("Unauthorized");
            }
        }
    }
}