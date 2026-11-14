using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class DisplayService
    {
        public void DisplayChain(MyBlockChain blockChain)
        {
            Console.WriteLine("Block");
            foreach (var block in blockChain.Chain) 
            {
                Console.WriteLine($"Index: {block.Index}");
                Console.WriteLine($"Hash: {block.Hash}");
                Console.WriteLine($"Data: {block.Data}");
                Console.WriteLine($"PrevHash: {block.PrevHash}");
                Console.WriteLine($"TimeStamp: {block.TimeStamp}");
                Console.WriteLine($"Nonce: {block.Nonce}");
                Console.WriteLine($"Mining Duraction: {block.MiningDuraction} seconds");
                Console.WriteLine(new string('-', 30));

            }
        }
    }
}
