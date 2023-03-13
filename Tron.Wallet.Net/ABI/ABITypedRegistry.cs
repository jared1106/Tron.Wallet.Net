using System.Collections.Concurrent;
using Tron.Wallet.Net.ABI.FunctionEncoding.Attributes;
using Tron.Wallet.Net.ABI.Model;

namespace Tron.Wallet.Net.ABI {
    public static class ABITypedRegistry {
        private static ConcurrentDictionary<Type, FunctionABI> _functionAbiRegistry = new ConcurrentDictionary<Type, FunctionABI>();
        private static AttributesToABIExtractor _abiExtractor = new AttributesToABIExtractor();

        public static FunctionABI GetFunctionABI<TFunctionMessage>() {
            return GetFunctionABI(typeof(TFunctionMessage));
        }

        public static FunctionABI GetFunctionABI(Type functionABIType) {
            if (!_functionAbiRegistry.ContainsKey(functionABIType)) {
                var functionAbi = _abiExtractor.ExtractFunctionABI(functionABIType);
                _functionAbiRegistry[functionABIType] = functionAbi ?? throw new ArgumentException(functionABIType.ToString() + " is not a valid Function Type");
            }
            return _functionAbiRegistry[functionABIType];
        }
    }
}
