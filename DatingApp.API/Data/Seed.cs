using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class Seed
    {
        private readonly UserManager<User> _userManager;

        public Seed(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public void SeedUsers()
        {
            if (!_userManager.Users.Any())
            {
                var userData = File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    // byte[] passwordHash, passwordSalt;
                    // CreatePasswordHash("password", out passwordHash, out passwordSalt);

                    // user.PasswordHash = passwordHash;
                    // user.PasswordSalt = passwordSalt;
                    // user.UserName = user.UserName.ToLower();

                    _userManager.CreateAsync(user, "password").Wait();
                }
            }
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}