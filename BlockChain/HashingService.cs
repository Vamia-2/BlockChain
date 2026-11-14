using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class HashingService
    {
        public string ComputerBlockHash(Block block)
        {
            var blockData = $"{block.Index}{block.PrevHash}{block.TimeStamp}{block.Data}{block.Nonce}{block.DifficultyAtMining}";
            return ComputerHash(blockData);
        }
        private string ComputerHash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
