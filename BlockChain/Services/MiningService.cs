
using System.Diagnostics;
using BlockChain.Models;

namespace BlockChain
{
    public class MiningService
    {
        private readonly HashingService _hashingService;

        public MiningService()
        {
            _hashingService = new HashingService();
        }

        public void MineBlock(Block block, int difficulty)
        {
            var target = new string('0', difficulty);

            var startTime = Stopwatch.StartNew();

            while (true)
            {
                block.Hash = _hashingService.ComputerBlockHash(block);

                if (block.Hash.StartsWith(target))
                {
                    startTime.Stop();

                    block.MiningDuraction =
                        (decimal)startTime.Elapsed.TotalSeconds;

                    break;
                }

                block.Nonce++;

                if (block.Nonce % 100000 == 0)
                {
                    Console.WriteLine(
                        $"Mining block {block.Index}: " +
                        $"Nonce = {block.Nonce}, Hash = {block.Hash}"
                    );
                }
            }
        }
    }
}
