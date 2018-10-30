using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.Contracts;
using Nethereum.ABI.FunctionEncoding.Attributes;
namespace SonmEther.CQS
{
    public class SonmDeployment:ContractDeploymentMessage
    {
        
        public static string BYTECODE = "608060405234801561001057600080fd5b5060008054600160a060020a0319908116339081179091161790556107be8061003a6000396000f3006080604052600436106100ab5763ffffffff60e060020a60003504166301345a9081146100b05780631a3d5f82146100d75780631dd784d61461010c578063289e77b3146101215780634ed05aa01461015e578063715018a61461017f5780637929a4b9146101965780638da5cb5b146101b7578063a70a7af0146101cc578063d3623432146101ed578063de2daf5a14610214578063ebf35d6f14610229578063f2fde38b1461024a575b600080fd5b3480156100bc57600080fd5b506100c561026b565b60408051918252519081900360200190f35b3480156100e357600080fd5b506100f8600160a060020a0360043516610271565b604080519115158252519081900360200190f35b34801561011857600080fd5b506100f8610345565b34801561012d57600080fd5b50610142600160a060020a0360043516610385565b60408051600160a060020a039092168252519081900360200190f35b34801561016a57600080fd5b50610142600160a060020a03600435166103f3565b34801561018b57600080fd5b50610194610411565b005b3480156101a257600080fd5b506100f8600160a060020a0360043516610470565b3480156101c357600080fd5b5061014261048e565b3480156101d857600080fd5b506100f8600160a060020a036004351661049d565b3480156101f957600080fd5b506100f8600160a060020a036004358116906024351661055c565b34801561022057600080fd5b506100f8610606565b34801561023557600080fd5b506100f8600160a060020a0360043516610644565b34801561025657600080fd5b50610194600160a060020a03600435166106a6565b60065481565b336000908152600360209081526040808320600160a060020a038516845290915281205460ff161515600114806102ac57506102ac826106c9565b15156102b757600080fd5b600160a060020a03821660008181526001602081815260408084208054600160a060020a0319163390811790915580855260028352818520805460ff19908116909517905560038352818520868652909252808420805490931690925590519092917f4940ef08d5aed63b7d3d3db293d69d6ed1d624995b90e9e944839c8ea0ae450d91a35060015b919050565b60003361035181610385565b600160a060020a03161461036457600080fd5b50336000908152600560205260409020805460ff1916600190811790915590565b600160a060020a0380821660009081526001602052604081205490911615806103c85750600160a060020a03808316600081815260016020526040902054909116145b156103d4575080610340565b50600160a060020a039081166000908152600160205260409020541690565b600160a060020a039081166000908152600460205260409020541690565b600054600160a060020a0316331461042857600080fd5b60008054604051600160a060020a03909116917ff8df31144d9c2f0f6b59d69b8b98abd5459d07f2742c4df920b25aae33c6482091a260008054600160a060020a0319169055565b600160a060020a031660009081526005602052604090205460ff1690565b600054600160a060020a031681565b6000336104a981610385565b600160a060020a0316146104bc57600080fd5b3360009081526002602052604090205460ff16156104d957600080fd5b81600160a060020a03166104ec83610385565b600160a060020a0316146104ff57600080fd5b600160a060020a0382166000818152600360209081526040808320338085529252808320805460ff191660011790555190917fe398d33bf7e881cdfc9f34c743822904d4e45a0be0db740dd88cb132e4ce2ed991a3506001919050565b600081600160a060020a031661057184610385565b600160a060020a03161480156105a1575033600160a060020a03841614806105a1575033600160a060020a038316145b15156105ac57600080fd5b600160a060020a038084166000818152600160205260408082208054600160a060020a031916905551928516927f7822736ed69a5fe0ad6dc2c6669e8053495d711118e5435b047f9b83deda4c379190a350600192915050565b3360009081526005602052604081205460ff16151560011461062757600080fd5b50336000908152600560205260409020805460ff19169055600190565b60003361065081610385565b600160a060020a03161461066357600080fd5b33600160a060020a038316141561067957600080fd5b50600160a060020a031660009081526004602052604090208054600160a060020a03191633179055600190565b600054600160a060020a031633146106bd57600080fd5b6106c681610722565b50565b33600090815260046020526040812054600160a060020a0316801580159061071b5750600160a060020a0380821660009081526003602090815260408083209387168352929052205460ff1615156001145b9392505050565b600160a060020a038116151561073757600080fd5b60008054604051600160a060020a03808516939216917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e091a360008054600160a060020a031916600160a060020a03929092169190911790555600a165627a7a723058204f8858130e89db1e70f200e773cf72fa1a4279c2c5550eaa6ba9022144133d790029";
        
        public SonmDeployment():base(BYTECODE) { }
        
        public SonmDeployment(string byteCode):base(byteCode) { }
        

    }
}
