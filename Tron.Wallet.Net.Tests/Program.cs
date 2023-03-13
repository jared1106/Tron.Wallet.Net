using Tron.Wallet.Net.Accounts;
using Tron.Wallet.Net.Contracts;
using Tron.Wallet.Net;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace ConsoleApp1 {
    internal class Program {
        static async Task Main(string[] args) {
            Console.WriteLine("Program begin..");

            var privateKey = "D95611A9AF2A2A45359106222ED1AFED48853D9A44DEFF8DC7913F5CBA727366";

            //发送 trx
            var result = await TrxTransferAsync(privateKey, "TGehVcNhud84JDCGrNHKVz9jEAVKUpbuiv", 10000000L);
            Console.WriteLine(JsonConvert.SerializeObject(result));

            //发送 trc20 token usdt
            var transactionId = await EtherTransferAsync(privateKey, "TGehVcNhud84JDCGrNHKVz9jEAVKUpbuiv", 10, string.Empty);
            Console.WriteLine(transactionId);

            Console.WriteLine("Program end..\r\nPress any key to exit.");
            Console.ReadKey();
        }

        #region TrxTransferAsync

        private static async Task<dynamic> TrxTransferAsync(string privateKey, string to, long amount) {
            var record = TronServiceExtension.GetRecord();
            var transactionClient = record.TronClient?.GetTransaction();

            var account = new TronAccount(privateKey, TronNetwork.MainNet);

            var transactionExtension = await transactionClient?.CreateTransactionAsync(account.Address, to, amount)!;

            var transactionId = transactionExtension.Txid.ToStringUtf8();

            var transactionSigned = transactionClient.GetTransactionSign(transactionExtension.Transaction, privateKey);
            var returnObj = await transactionClient.BroadcastTransactionAsync(transactionSigned);

            return new { Result = returnObj.Result, Message = returnObj.Message, TransactionId = transactionId };
        }

        #endregion

        #region EtherTransferAsync

        private static async Task<string> EtherTransferAsync(string privateKey, string toAddress, decimal amount, string? memo) {
            const string contractAddress = "TR7NHqjeKQxGTCi8q8ZY4pL8otSzgjLj6t";

            var record = TronServiceExtension.GetRecord();
            var contractClientFactory = record.ServiceProvider.GetService<IContractClientFactory>();
            var contractClient = contractClientFactory?.CreateClient(ContractProtocol.TRC20);

            var account = new TronAccount(privateKey, TronNetwork.MainNet);

            //设置手续费上限
            const long feeAmount = 30 * 1000000L;

            return await contractClient.TransferAsync(contractAddress, account, toAddress, amount, memo, feeAmount);
        }

        #endregion
    }
}