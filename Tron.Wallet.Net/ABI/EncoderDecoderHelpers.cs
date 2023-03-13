using Tron.Wallet.Net.ABI.Decoders;

namespace Tron.Wallet.Net.ABI {
    public class EncoderDecoderHelpers {
        public static int GetNumberOfBytes(byte[] encoded) {
            var intDecoder = new IntTypeDecoder();
            var numberOfBytesEncoded = encoded.Take(32);
            return intDecoder.DecodeInt(numberOfBytesEncoded.ToArray());
        }
    }
}