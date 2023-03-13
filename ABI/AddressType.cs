using Tron.Wallet.Net.ABI.Decoders;
using Tron.Wallet.Net.ABI.Encoders;

namespace Tron.Wallet.Net.ABI
{
    public class AddressType : ABIType
    {
        public AddressType() : base("address")
        {
            //this will need to be only a string type one, converting to hex
            Decoder = new AddressTypeDecoder();
            Encoder = new AddressTypeEncoder();
        }
    }
}