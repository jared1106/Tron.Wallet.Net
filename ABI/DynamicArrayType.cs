using Tron.Wallet.Net.ABI.Decoders;
using Tron.Wallet.Net.ABI.Encoders;

namespace Tron.Wallet.Net.ABI {
    public class DynamicArrayType : ArrayType {
        public DynamicArrayType(string name) : base(name) {
            Decoder = new DynamicArrayTypeDecoder(ElementType);
            Encoder = new DynamicArrayTypeEncoder(ElementType);
        }

        public override string CanonicalName => ElementType.CanonicalName + "[]";

        public override int FixedSize => -1;
    }
}