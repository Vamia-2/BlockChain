
using BlockChain.Models;

namespace BlockChain
{
    public class MyBlockChain
    {
        private int _difficulty = 1;

        public List<Block> Chain { get; set; }

        private readonly HashingService _hashingService;
        private readonly MiningService _miningService;

        public readonly decimal _targetBlockTime = 2;
        public readonly int _adjustEveryNBlocks = 2;

        public MyBlockChain()
        {
            Chain = new List<Block>();

            _hashingService = new HashingService();
            _miningService = new MiningService();

            AddGenesisBlock();
        }

        // Створення першого блоку
        private void AddGenesisBlock()
        {
            var genesisBlock = new Block
            {
                Index = 0,
                Data = "Genesis Block",
                Author = "System",
                Transactions = new List<Transaction>(),
                PrevHash = "0",
                TimeStamp = DateTime.UtcNow,
                DifficultyAtMining = _difficulty
            };

            _miningService.MineBlock(genesisBlock, _difficulty);

            Chain.Add(genesisBlock);
        }

        // Додавання звичайного текстового блоку
        public void AddBlock(string data, string author = "Unknown")
        {
            var lastBlock = Chain[Chain.Count - 1];

            var newBlock = new Block
            {
                Index = lastBlock.Index + 1,
                Data = data,
                Author = author,
                Transactions = new List<Transaction>(),
                PrevHash = lastBlock.Hash,
                TimeStamp = DateTime.UtcNow,
                DifficultyAtMining = _difficulty
            };

            _miningService.MineBlock(newBlock, _difficulty);

            Chain.Add(newBlock);

            AdjustDifficulty();
        }

        // Додавання блоку з транзакціями
        public void AddBlock(List<Transaction> transactions, string author = "Unknown")
        {
            var lastBlock = Chain[Chain.Count - 1];

            var newBlock = new Block
            {
                Index = lastBlock.Index + 1,
                Data = "Transactions Block",
                Author = author,
                Transactions = transactions,
                PrevHash = lastBlock.Hash,
                TimeStamp = DateTime.UtcNow,
                DifficultyAtMining = _difficulty
            };

            _miningService.MineBlock(newBlock, _difficulty);

            Chain.Add(newBlock);

            AdjustDifficulty();
        }

        // Зміна складності майнінгу
        private void AdjustDifficulty()
        {
            var recentBlock = Chain
                .Where(b => b.Index > 0)
                .TakeLast(_adjustEveryNBlocks)
                .ToList();

            if (recentBlock.Count == 0)
                return;

            var avgTime = recentBlock.Average(
                b => b.MiningDuraction
            );

            if (avgTime < _targetBlockTime)
            {
                _difficulty++;

                Console.WriteLine(
                    $"Difficulty increased to {_difficulty}"
                );
            }
            else if (avgTime > _targetBlockTime)
            {
                _difficulty = Math.Max(1, _difficulty - 1);

                Console.WriteLine(
                    $"Difficulty decreased to {_difficulty}"
                );
            }
        }

        // Виведення історії складності
        public void PrintDifficultyHistory()
        {
            foreach (var block in Chain)
            {
                Console.WriteLine($"Block Index: {block.Index}");
                Console.WriteLine($"Difficulty: {block.DifficultyAtMining}");
                Console.WriteLine($"Nonce: {block.Nonce}");
                Console.WriteLine(
                    $"Mining Duration: {block.MiningDuraction} seconds"
                );

                Console.WriteLine(new string('-', 40));
            }
        }

        // Перевірка правильності блокчейна
        public bool IsChainValid()
        {
            for (int i = 0; i < Chain.Count; i++)
            {
                var currentBlock = Chain[i];

                // Перевірка хешу
                if (currentBlock.Hash !=
                    _hashingService.ComputerBlockHash(currentBlock))
                {
                    return false;
                }

                // Перевірка складності
                var target = new string(
                    '0',
                    currentBlock.DifficultyAtMining
                );

                if (!currentBlock.Hash.StartsWith(target))
                {
                    return false;
                }

                // Перевірка зв'язку з попереднім блоком
                if (i > 0)
                {
                    var previousBlock = Chain[i - 1];

                    if (currentBlock.PrevHash != previousBlock.Hash)
                    {
                        return false;
                    }

                    if (currentBlock.Index != previousBlock.Index + 1)
                    {
                        return false;
                    }
                }
                else if (currentBlock.PrevHash != "0")
                {
                    return false;
                }
            }

            return true;
        }
    }
}
