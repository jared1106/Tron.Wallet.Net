using Tron.Wallet.Net.ABI.Model;

namespace Tron.Wallet.Net.ABI.FunctionEncoding {
    public class ParameterOutput {
        public Parameter Parameter { get; set; }
        public int DataIndexStart { get; set; }
        public object Result { get; set; }

    }
}