
namespace BlockChain
{
    public class DisplayService
    {
        public void DisplayChain(MyBlockChain blockChain)
        {
            Console.WriteLine("\n========== BLOCKCHAIN ==========");

            foreach (var block in blockChain.Chain)
            {
                Console.WriteLine($"Index: {block.Index}");
                Console.WriteLine($"Author: {block.Author}");
                Console.WriteLine($"Hash: {block.Hash}");
                Console.WriteLine($"Data: {block.Data}");
                Console.WriteLine($"PrevHash: {block.PrevHash}");
                Console.WriteLine($"TimeStamp: {block.TimeStamp}");
                Console.WriteLine($"Nonce: {block.Nonce}");

                Console.WriteLine(
                    $"Mining Duration: {block.MiningDuraction} seconds"
                );

                Console.WriteLine(
                    $"Difficulty: {block.DifficultyAtMining}"
                );

                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
