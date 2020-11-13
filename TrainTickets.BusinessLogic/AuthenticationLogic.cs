using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SplitMoney.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Domain.Models;

namespace TrainTickets.BusinessLogic
{
   public class AuthenticationLogic
    {
        public AuthenticationLogic()
        {

        }
        public byte [] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        public string EncryptPassword(string password,byte [] salt)
        {
            var encryptedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return encryptedPassword;
        }

        
        public bool ComparePasswords(string inputPassword, Person user)
        {
            byte[] salt = user.salt;

            var encryptedInputPassword = EncryptPassword(inputPassword, salt);

            if (encryptedInputPassword == user.Password)
            {
                return true;
            }

            return false;
        }
    }
}
