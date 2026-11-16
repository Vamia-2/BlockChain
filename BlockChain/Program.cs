using BlockChain;

var blockChainService = new MyBlockChain();

var displayService = new DisplayService();

// Lesson 1
// Level 1

blockChainService.AddBlock("User Registration: Alex");

blockChainService.AddBlock("Purchase: Alex bought a laptop");

blockChainService.AddBlock("Fund Transfer: Alex sent Bob 100");

blockChainService.AddBlock("Fund Transfer: Bob sent Charlie 50");

blockChainService.AddBlock("Fund Transfer: Charlie sent Dave 25");

// Виведення блокчейна
displayService.DisplayChain(blockChainService);

// Перевірка блокчейна
var isValid = blockChainService.IsChainValid();

if (isValid)
{
    Console.WriteLine("\nBlockchain is valid");
}
else
{
    Console.WriteLine("\nBlockchain is not valid");
}

// Level 2
// Перевірка впливу Author на хеш

Console.WriteLine("\n========== AUTHOR TEST ==========");

blockChainService.Chain[1].Author = "Alex";

Console.WriteLine(
    "After changing Author: " + blockChainService.IsChainValid()
);