﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Prices.Web.Server.Data
{
    public interface IRepository<T> where T : TableEntity, new()
    {
        Task<List<T>> GetAll();
        Task<List<T>> ByPartitionKey(string value);
        Task Add(T item);
    }

    public class Repository<T> : IRepository<T> where T : TableEntity, new()
    {
        private readonly CloudTable _tableClient;

        protected Repository(CloudTable tableClient)
        {
            _tableClient = tableClient;
        }

        public async Task<List<T>> GetAll()
        {
            var tableQuery = new TableQuery<T>();

            var results = await _tableClient.ExecuteQuerySegmentedAsync(tableQuery, new TableContinuationToken());
            return results.Results.OrderBy(result => result.Timestamp).ToList();
        }

        public async Task<List<T>> ByPartitionKey(string value)
        {
            var tableQuery = new TableQuery<T>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, value));
            var results = await _tableClient.ExecuteQuerySegmentedAsync(tableQuery, new TableContinuationToken());
            return results.Results.OrderBy(result => result.Timestamp).ToList();
        }

        public async Task Add(T item)
        {
            await _tableClient.ExecuteAsync(TableOperation.Insert(item));
        }
    }
}