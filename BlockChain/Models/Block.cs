
namespace BlockChain.Models
{
    public class Block
    {
        // Номер блоку в ланцюжку
        public int Index { get; set; }

        // Хеш поточного блоку
        public string Hash { get; set; } = "";

        // Дані блоку
        public string Data { get; set; } = "";

        // Автор запису
        public string Author { get; set; } = "Unknown";

        // Список транзакцій
        public List<Transaction> Transactions { get; set; } = new();

        // Хеш попереднього блоку
        public string PrevHash { get; set; } = "";

        // Час створення блоку
        public DateTime TimeStamp { get; set; }

        // Лічильник майнінгу
        public long Nonce { get; set; }

        // Тривалість майнінгу
        public decimal MiningDuraction { get; set; }

        // Складність під час майнінгу
        public int DifficultyAtMining { get; set; }
    }
}
