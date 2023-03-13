namespace Tron.Wallet.Net.Accounts {
    public interface ITronAccount
    {
        public string PublicKey { get; }
        public string PrivateKey { get; }

        public string Address { get; }

        byte GetAddressPrefix();
    }
}
