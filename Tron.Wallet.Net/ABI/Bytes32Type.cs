using Tron.Wallet.Net.ABI.Decoders;
using Tron.Wallet.Net.ABI.Encoders;

namespace Tron.Wallet.Net.ABI {
    public class Bytes32Type : ABIType {
        public Bytes32Type(string name) : base(name) {
            Decoder = new Bytes32TypeDecoder();
            Encoder = new Bytes32TypeEncoder();
        }
    }
}