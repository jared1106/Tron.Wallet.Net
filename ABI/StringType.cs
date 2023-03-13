using Tron.Wallet.Net.ABI.Decoders;
using Tron.Wallet.Net.ABI.Encoders;

namespace Tron.Wallet.Net.ABI {
    public class StringType : ABIType {
        public StringType() : base("string") {
            Decoder = new StringTypeDecoder();
            Encoder = new StringTypeEncoder();
        }

        public override int FixedSize => -1;
    }
}