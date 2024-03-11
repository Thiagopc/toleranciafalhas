using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToleranciaFalhas.domain.Entities;
using ToleranciaFalhas.domain.Interfaces.Event;
using ToleranciaFalhas.domain.Interfaces.Repositories;

namespace ToleranciaFalhas.infra.Repositories.Db.Dapper
{
    public class ConnectionDbReader<T> : IBaseReadRepository<T> where T : class
    {
        private string _connectionString = "User ID=postgres;Password=sjaijsaJ923s_9232js;Host=read.c3oq2okygbx8.us-east-1.rds.amazonaws.com;Port=5432;Database=estudo;";
        private List<string> _tabelaspermitidas = new List<string> { "cliente", "" };
        private string urlsqs = "https://sqs.us-east-1.amazonaws.com/381492228201/myfila.fifo";
        private readonly ISqsEvent _sqs;

        public ConnectionDbReader(ISqsEvent sqs)
        {
            this._sqs = sqs;
        }





        public async Task<List<T>> List(string tablename)
        {

            if (!this._tabelaspermitidas.Contains(tablename))
                throw new ArgumentException("nome tabela inválido");


            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                return (await dbConnection.QueryAsync<T>($"SELECT * FROM {tablename}")).ToList();
            }
        }


        public async Task Save(string content) =>
            await this._sqs.SendEventAsync(this.urlsqs, content);



    }
}
