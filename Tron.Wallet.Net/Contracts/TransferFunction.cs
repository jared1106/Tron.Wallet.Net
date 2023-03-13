using System.Numerics;
using Tron.Wallet.Net.ABI.FunctionEncoding.Attributes;

namespace Tron.Wallet.Net.Contracts {
    [Function("transfer", "bool")]
    public class TransferFunction : FunctionMessage {
        [Parameter("address", "_to", 1)]
        public string To { get; set; }

        [Parameter("uint256", "_value", 2)]
        public BigInteger TokenAmount { get; set; }
    }
}
