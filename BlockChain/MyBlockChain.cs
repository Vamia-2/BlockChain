using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class MyBlockChain
    {
        public List<Block> Chain {  get; set; }
        private readonly HashingService _hashingService;
        private readonly MiningService _miningService;
        public int Difficulty { get; private set; } = 4;
        public readonly decimal _targetBlockTime = 10; //seconds 10
        public readonly int _adjustEveryNBlocks = 5; //

        public MyBlockChain(int difficulty)
        {
            Chain = new List<Block>();
            _hashingService = new HashingService();
            _miningService = new MiningService();
            AddGenesisBlock();
            this.Difficulty = difficulty;
        }
        private void AddGenesisBlock()
        {
            var genesisBlock = new Block
            {
                Index = 0,
                Data = "",
                PrevHash = "0",
                TimeStamp = DateTime.UtcNow,

            };
            _miningService.MineBlock(genesisBlock, 1);
            //genesisBlock.Hash = _hashingService.ComputerBlockHash(genesisBlock);
            Chain.Add(genesisBlock);
        }
        public void AddBlock(string data)
        {
            var lastBlock = Chain[Chain.Count - 1];
            var newBlock = new Block
            {
                Index = lastBlock.Index+1,
                Data = data,
                PrevHash = lastBlock.Hash,
                TimeStamp = DateTime.UtcNow
            };
            _miningService.MineBlock(newBlock, Difficulty);
            //newBlock.Hash = _hashingService.ComputerBlockHash(newBlock);
            Chain.Add(newBlock);
            AdjustDifficulty();
        }
        private void AdjustDifficulty()
        {
            var recentBlock = Chain.Where(b => b.Index > 0).TakeLast(_adjustEveryNBlocks).ToList();
            if (recentBlock.Count == 0) return;

            var avgTime = recentBlock.Average(b => b.MiningDuraction);
            if(avgTime < _targetBlockTime)
            {
                Difficulty=Math.Max(1, Difficulty - 1);
                Console.WriteLine($"Difficulty  decreased to {Difficulty}");
            }
        }
        public bool IsChainValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                var currentBlock = Chain[i];
                var previousBlock = Chain[i - 1];

                if(currentBlock.Index == 0)
                {
                    continue;
                }
                if(currentBlock.Hash != _hashingService.ComputerBlockHash(currentBlock))
                {
                    return false;
                }

                if (currentBlock.PrevHash != previousBlock.Hash)
                {
                    return false;
                }
                if(currentBlock.Hash.Substring(0, Difficulty) != new string('0', Difficulty))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
