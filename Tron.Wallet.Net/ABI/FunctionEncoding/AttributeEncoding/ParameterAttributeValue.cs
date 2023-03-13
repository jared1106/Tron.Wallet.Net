using System.Reflection;
using Tron.Wallet.Net.ABI.FunctionEncoding.Attributes;

namespace Tron.Wallet.Net.ABI.FunctionEncoding.AttributeEncoding {
    public class ParameterAttributeValue {
        public ParameterAttribute ParameterAttribute { get; set; }
        public object Value { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
    }
}