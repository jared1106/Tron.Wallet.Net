namespace Tron.Wallet.Net.Contracts {
    public interface IContractClientFactory {
        IContractClient CreateClient(ContractProtocol protocol);
    }
}
