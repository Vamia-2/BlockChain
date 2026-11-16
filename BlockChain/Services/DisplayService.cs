
using BlockChain.Models;

namespace BlockChain
{
    public class DisplayService
    {
        public void DisplayChain(MyBlockChain blockChain)
        {
            Console.WriteLine("\n========== BLOCKCHAIN ==========\n");

            foreach (var block in blockChain.Chain)
            {
                Console.WriteLine($"Index: {block.Index}");
                Console.WriteLine($"Author: {block.Author}");
                Console.WriteLine($"Data: {block.Data}");
                Console.WriteLine($"Hash: {block.Hash}");
                Console.WriteLine($"PrevHash: {block.PrevHash}");
                Console.WriteLine($"TimeStamp: {block.TimeStamp}");
                Console.WriteLine($"Nonce: {block.Nonce}");

                Console.WriteLine(
                    $"Mining Duration: {block.MiningDuraction} seconds"
                );

                Console.WriteLine(
                    $"Difficulty: {block.DifficultyAtMining}"
                );

                if (block.Transactions.Count > 0)
                {
                    Console.WriteLine("Transactions:");

                    foreach (var transaction in block.Transactions)
                    {
                        Console.WriteLine(transaction);
                    }
                }

                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
