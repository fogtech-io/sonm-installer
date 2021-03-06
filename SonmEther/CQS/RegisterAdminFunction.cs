using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.Contracts;
using Nethereum.ABI.FunctionEncoding.Attributes;
using SonmEther.DTO;
namespace SonmEther.CQS
{
    [Function("RegisterAdmin", "bool")]
    public class RegisterAdminFunction: FunctionMessage
    {
        [Parameter("address", "_admin", 1)]
        public string Admin {get; set;}
    }
}
