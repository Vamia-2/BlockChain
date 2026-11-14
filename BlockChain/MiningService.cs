using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            while(true)
            {
                block.Hash = _hashingService.ComputerBlockHash(block);
                if(block.Hash.Substring(0, difficulty) == target ) 
                {   
                    //Lesson 1, 2
                    //Console.WriteLine($"Hash found for block {block.Index}: {block.Hash}");
                    //
                    startTime.Stop();
                    block.MiningDuraction = startTime.Elapsed.TotalMinutes;
                    break;
                }
                if(block.Nonce% 100000 == 0 )
                {
                    Console.WriteLine($"Mining block {block.Index}: Nonce = {block.Nonce}, Hash = {block.Hash}");
                }
                block.Nonce++;
            }
        }
    }
}
