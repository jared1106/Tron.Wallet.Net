﻿using Microsoft.Extensions.Options;

namespace ConsoleApp1;

using Microsoft.Extensions.DependencyInjection;
using Tron.Wallet.Net;

public record TronRecord(IServiceProvider ServiceProvider, ITronClient? TronClient, IOptions<TronNetOptions>? Options);

public static class TronServiceExtension {
    private static IServiceProvider AddTronNet() {
        IServiceCollection services = new ServiceCollection();
        services.AddTronNet(x => {
            x.Network = TronNetwork.MainNet;
            x.Channel = new GrpcChannelOption { Host = "grpc.trongrid.io", Port = 50051 };
            x.SolidityChannel = new GrpcChannelOption { Host = "grpc.trongrid.io", Port = 50052 };

            // 波场主链  API Key，申请地址  http://www.trongrid.io
            x.ApiKey = "80a8b20f-a917-43a9-a2f1-809fe6eec0d6";
        });
        services.AddLogging();
        return services.BuildServiceProvider();
    }

    public static TronRecord GetRecord() {
        var provider = AddTronNet();
        var client = provider.GetService<ITronClient>();
        var options = provider.GetService<IOptions<TronNetOptions>>();

        return new TronRecord(provider, client, options);
    }
}