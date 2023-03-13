using Tron.Wallet.Net.ABI.Decoders;
using Tron.Wallet.Net.ABI.Encoders;

namespace Tron.Wallet.Net.ABI {
    public class BytesElementaryType : ABIType {
        public BytesElementaryType(string name, int size) : base(name) {
            Decoder = new BytesElementaryTypeDecoder(size);
            Encoder = new BytesElementaryTypeEncoder(size);
        }
    }
}