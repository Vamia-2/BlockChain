using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class Block
    {
        //Нумерація блоку в ланцюжку
        public int Index {  get; set; }

        //Хеш попереднього блоку
        public string Hash { get; set; }

        //Дані блоку
        public string Data { get; set; }

        //Хеш попереднього блоку
        public string PrevHash { get; set; }

        //Час створення блоку
        public DateTime TimeStamp { get; set; }
        //
        public long Nonce { get; set; }
        //Тривалість
        public decimal MiningDuraction { get; set; }

    }
}
