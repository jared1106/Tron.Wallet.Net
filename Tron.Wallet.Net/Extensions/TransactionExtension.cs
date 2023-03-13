using Google.Protobuf;
using Tron.Wallet.Net.Crypto;

namespace Tron.Wallet.Net {
    public static class TransactionExtension {
        public static string GetTxid(this TronNet.Protocol.Transaction transaction) {
            var txid = transaction.RawData.ToByteArray().ToSHA256Hash().ToHex();

            return txid;
        }

    }
}
