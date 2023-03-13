using Tron.Wallet.Net.ABI.FunctionEncoding.Attributes;

namespace Tron.Wallet.Net.Contracts {
    [Function("balanceOf", "uint256")]
    public class BalanceOfFunction : FunctionMessage {
        [Parameter("address", "owner", 1)]
        public string Owner { get; set; }

    }

    [FunctionOutput]
    public class BalanceOfFunctionOutput : IFunctionOutputDTO {
        [Parameter("uint256", 1)]
        public long Balance { get; set; }
    }
}
