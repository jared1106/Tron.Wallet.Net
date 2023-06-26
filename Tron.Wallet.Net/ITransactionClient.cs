using System.Threading.Tasks;

namespace TronNet {
    using TronNet.Protocol;

    public interface ITransactionClient {
        Task<TransactionExtention> CreateAccountPermissionUpdateTransactionAsync(string fromAddress, string toAddress);

        Task<TransactionExtention> CreateTransactionAsync(string from, string to, long amount);

        Transaction GetTransactionSign(Transaction transaction, string privateKey);

        Task<Return> BroadcastTransactionAsync(Transaction transaction);
    }
}
