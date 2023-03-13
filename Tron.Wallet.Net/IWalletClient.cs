using Google.Protobuf;
using Grpc.Core;
using Tron.Wallet.Net.Accounts;
using TronNet.Protocol;

namespace Tron.Wallet.Net {
    public interface IWalletClient
    {
        TronNet.Protocol.Wallet.WalletClient GetProtocol();
        WalletSolidity.WalletSolidityClient GetSolidityProtocol();
        ITronAccount GenerateAccount();
        ITronAccount GetAccount(string privateKey);
        ByteString ParseAddress(string address);

        Metadata GetHeaders();
    }
}
