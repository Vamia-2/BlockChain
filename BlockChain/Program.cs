using BlockChain;
using BlockChain.Models;
using BlockChain.Services;

var blockChain = new MyBlockChain();
var displayService = new DisplayService();
var transactionService = new TransactionService();


while (true)
{
    Console.WriteLine("\n========== BLOCKCHAIN MENU ==========");
    Console.WriteLine("1. Add Block");
    Console.WriteLine("2. Display Chain");
    Console.WriteLine("3. Validate Chain");
    Console.WriteLine("4. Add 20 Blocks");
    Console.WriteLine("5. Exit");
    Console.WriteLine("6. Print Difficulty History");
    Console.WriteLine("7. Add Transaction Block");
    Console.WriteLine("8. Test Author Hash");

    Console.Write("\nChoose option: ");

    var enter = Console.ReadLine();

    switch (enter)
    {
        case "1":
            Console.Write("Enter block data: ");
            string data = Console.ReadLine() ?? "";

            Console.Write("Enter author: ");
            string author = Console.ReadLine() ?? "Unknown";

            blockChain.AddBlock(data, author);

            Console.WriteLine("Block added successfully!");
            break;

        case "2":
            displayService.DisplayChain(blockChain);
            break;

        case "3":
            bool isValid = blockChain.IsChainValid();

            Console.WriteLine(
                $"Is blockchain valid? {isValid}"
            );
            break;

        case "4":
            Console.Write("Enter author: ");
            string batchAuthor = Console.ReadLine() ?? "Unknown";

            for (int i = 0; i < 20; i++)
            {
                blockChain.AddBlock(
                    $"Block {i + 1} Data",
                    batchAuthor
                );
            }

            Console.WriteLine("20 blocks added successfully!");
            break;

        case "5":
            Console.WriteLine("Goodbye!");
            return;

        case "6":
            blockChain.PrintDifficultyHistory();

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
            break;

        case "7":
            Console.Write("Enter sender: ");
            string from = Console.ReadLine() ?? "";

            Console.Write("Enter recipient: ");
            string to = Console.ReadLine() ?? "";

            Console.Write("Enter amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid amount!");
                break;
            }

            Console.Write("Enter author: ");
            string transactionAuthor = Console.ReadLine() ?? "Unknown";

            try
            {
                var transaction = transactionService.CreateTransaction(
                    from,
                    to,
                    amount
                );

                blockChain.AddBlock(
                    new List<Transaction> { transaction },
                    transactionAuthor
                );

                Console.WriteLine("Transaction block added!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            break;

        case "8":
            if (blockChain.Chain.Count > 1)
            {
                Console.WriteLine(
                    "Blockchain before changing Author: " +
                    blockChain.IsChainValid()
                );

                blockChain.Chain[1].Author = "Another Author";

                Console.WriteLine(
                    "Blockchain after changing Author: " +
                    blockChain.IsChainValid()
                );
            }
            else
            {
                Console.WriteLine("First add a block!");
            }

            break;

        default:
            Console.WriteLine("Invalid option!");
            break;
    }
}