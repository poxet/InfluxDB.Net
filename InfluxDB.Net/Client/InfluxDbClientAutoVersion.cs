using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfluxDB.Net.Models;

namespace InfluxDB.Net
{
    internal class InfluxDbClientAutoVersion : IInfluxDbClient
    {
        private readonly IInfluxDbClient _influxDbClient;

        public InfluxDbClientAutoVersion(InfluxDbClientConfiguration influxDbClientConfiguration)
        {
            _influxDbClient = new InfluxDbClient(influxDbClientConfiguration);
            var errorHandlers = new List<ApiResponseErrorHandlingDelegate>();
            var result = _influxDbClient.Ping(errorHandlers).Result;
            var databaseVersion = result.Body;

            if (databaseVersion.StartsWith("0.9"))
            {
                if (databaseVersion == "0.9.2")
                {
                    _influxDbClient = new InfluxDbClientV092(influxDbClientConfiguration);
                }
            }
            else
            {
                throw new InvalidOperationException(string.Format("Version {0} is not yet supported by the Auto configuration.", databaseVersion));
            }
        }
        
        public async Task<InfluxDbApiResponse> Ping(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await _influxDbClient.Ping(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> CreateDatabase(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, Database database)
        {
            return await _influxDbClient.CreateDatabase(errorHandlers, database);
        }

        public async Task<InfluxDbApiResponse> DropDatabase(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string name)
        {
            return await _influxDbClient.DropDatabase(errorHandlers, name);
        }

        public async Task<InfluxDbApiResponse> ShowDatabases(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await _influxDbClient.ShowDatabases(errorHandlers);
        }

        public async Task<InfluxDbApiWriteResponse> Write(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, WriteRequest request, string timePrecision)
        {
            return await _influxDbClient.Write(errorHandlers,request, timePrecision);
        }

        public async Task<InfluxDbApiResponse> Query(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string name, string query)
        {
            return await _influxDbClient.Query(errorHandlers, name, query);
        }

        public async Task<InfluxDbApiResponse> CreateClusterAdmin(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, User user)
        {
            return await _influxDbClient.CreateClusterAdmin(errorHandlers, user);
        }

        public async Task<InfluxDbApiResponse> DeleteClusterAdmin(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string name)
        {
            return await _influxDbClient.DeleteClusterAdmin(errorHandlers, name);
        }

        public async Task<InfluxDbApiResponse> DescribeClusterAdmins(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await _influxDbClient.DescribeClusterAdmins(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> UpdateClusterAdmin(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, User user, string name)
        {
            return await _influxDbClient.UpdateClusterAdmin(errorHandlers, user, name);
        }

        public async Task<InfluxDbApiResponse> CreateDatabaseUser(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, User user)
        {
            return await _influxDbClient.CreateDatabaseUser(errorHandlers, database, user);
        }

        public async Task<InfluxDbApiResponse> DeleteDatabaseUser(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, string name)
        {
            return await _influxDbClient.DeleteDatabaseUser(errorHandlers, database, name);
        }

        public async Task<InfluxDbApiResponse> DescribeDatabaseUsers(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database)
        {
            return await _influxDbClient.DescribeDatabaseUsers(errorHandlers, database);
        }

        public async Task<InfluxDbApiResponse> UpdateDatabaseUser(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, User user, string name)
        {
            return await _influxDbClient.UpdateDatabaseUser(errorHandlers, database, user, name);
        }

        public async Task<InfluxDbApiResponse> AuthenticateDatabaseUser(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, string user, string password)
        {
            return await _influxDbClient.AuthenticateDatabaseUser(errorHandlers, database, user, password);
        }

        public async Task<InfluxDbApiResponse> GetContinuousQueries(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database)
        {
            return await _influxDbClient.GetContinuousQueries(errorHandlers, database);
        }

        public async Task<InfluxDbApiResponse> DeleteContinuousQuery(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, int id)
        {
            return await _influxDbClient.DeleteContinuousQuery(errorHandlers, database, id);
        }

        public async Task<InfluxDbApiResponse> DropSeries(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, string name)
        {
            return await _influxDbClient.DropSeries(errorHandlers, database, name);
        }

        public async Task<InfluxDbApiResponse> ForceRaftCompaction(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await _influxDbClient.ForceRaftCompaction(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> Interfaces(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await _influxDbClient.Interfaces(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> Sync(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await _influxDbClient.Sync(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> ListServers(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await _influxDbClient.ListServers(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> RemoveServers(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, int id)
        {
            return await _influxDbClient.RemoveServers(errorHandlers, id);
        }

        public async Task<InfluxDbApiResponse> CreateShard(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, Shard shard)
        {
            return await _influxDbClient.CreateShard(errorHandlers, shard);
        }

        public async Task<InfluxDbApiResponse> GetShards(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await _influxDbClient.GetShards(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> DropShard(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, int id, Shard.Member servers)
        {
            return await _influxDbClient.DropShard(errorHandlers, id, servers);
        }

        public async Task<InfluxDbApiResponse> GetShardSpaces(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await _influxDbClient.GetShardSpaces(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> DropShardSpace(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, string name)
        {
            return await _influxDbClient.DropShardSpace(errorHandlers, database, name);
        }

        public async Task<InfluxDbApiResponse> CreateShardSpace(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, ShardSpace shardSpace)
        {
            return await _influxDbClient.CreateShardSpace(errorHandlers, database, shardSpace);
        }

        public IFormatter GetFormatter()
        {
            return _influxDbClient.GetFormatter();
        }

        public InfluxVersion GetVersion()
        {
            return _influxDbClient.GetVersion();
        }
    }
}