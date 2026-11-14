using BlockChain;

//Lesson 1
//var blockChainService = new MyBlockChain();
//Lesson 1, 2
var blockChain = new MyBlockChain(5);
var displayService = new DisplayService();

//Lesson 1
//Level 1
//blockChainService.AddBlock("User Registration: Alex");
//blockChainService.AddBlock("Purchase: Alex bought a laptop");
//blockChainService.AddBlock("Fund Transfer: Alex sent Bob 100");
//blockChainService.AddBlock("Fund Transfer: Bob sent Charlie 50");
//blockChainService.AddBlock("Fund Transfer: Charlie sent Dave 25");



//displayService.DisplayChain(blockChainService);
//var isValid = blockChainService.IsChainValid();

//if (isValid)
//{
//    Console.WriteLine("Blockchain is valid");
//}
//else
//{
//    Console.WriteLine("Blockchain is not valid");
//}

//Console.ReadLine();

//blockChainService.Chain[2].Data = "bob send charlie 1000";
//displayService.DisplayChain(blockChainService);

//isValid = blockChainService.IsChainValid();
//if(isValid)
//{
//    Console.WriteLine("Blockchain is Valid");
//}
//else
//{
//    Console.WriteLine("Blockshain is not valid");
//}





//Lesson 2
blockChain.AddBlock("Alex send 1 BTC to Bob");
blockChain.AddBlock("Bob send 0.5 BTC to Charlie");
blockChain.AddBlock("Charlie send 0.2 BTC to Dave");
//Level 1
blockChain.AddBlock("User Registration: Ivan");
blockChain.AddBlock("Action: Displayed User Name Successfully");
displayService.DisplayChain(blockChain);
Console.WriteLine("Is Valid:"+ blockChain.IsChainValid());