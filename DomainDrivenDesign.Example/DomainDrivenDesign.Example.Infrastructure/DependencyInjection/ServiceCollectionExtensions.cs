using Amazon.DynamoDBv2;
using DomainDrivenDesign.Example.Application.Common.Interfaces;
using DomainDrivenDesign.Example.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Example.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            => services.AddScoped<IItemRepository, DynamoDbItemRepository>()
            .AddDefaultAWSOptions(configuration.GetAWSOptions())
            .AddSingleton<object> (x => new AmazonDynamoDBConfig { ServiceURL = configuration.GetValue<string>("AWS:ConnectionString") })
            .AddSingleton<IAmazonDynamoDB, AmazonDynamoDBClient>();
    }
}
