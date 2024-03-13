using Dapper;
using GestaoProdutos.Models.Domain.Entities;
using GestaoProdutos.Models.Domain.Enums;
using GestaoProdutos.Models.Domain.Interfaces;
using GestaoProdutos.Models.Infrastructure.Queries;
using System.Data;
using static Dapper.SqlMapper;

namespace GestaoProdutos.Models.Infrastructure.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly IDbConnection _dbConnection;

        public FilmeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Create(Filme entity)
        {
            TSqlQueryType queryType = TSqlQueryType.CREATE_FILMES;
            string sql = SQlManager.GetSql(queryType);
            sql = ReplaceQueryParameters(queryType, entity, sql);
            var result = _dbConnection.Execute(sql);
        }

        public void Delete(int id)
        {
            TSqlQueryType queryType = TSqlQueryType.DELETE_FILMES;
            string sql = SQlManager.GetSql(queryType);
            sql = ReplaceQueryParameters(queryType, new Filme { Id = id }, sql);
            _dbConnection.Execute(sql);
        }

        public List<Filme> GetAll()
        {
            TSqlQueryType queryType = TSqlQueryType.LIST_FILMES;
            string sql = SQlManager.GetSql(queryType);
            var result =  _dbConnection.Query<Filme>(sql).ToList();
            return result;
        }

        public Filme GetById(int id)
        {
            TSqlQueryType queryType = TSqlQueryType.GET_FILMES;
            string sql = SQlManager.GetSql(queryType);
            sql = ReplaceQueryParameters(queryType, new Filme { Id = id }, sql);
            var result = _dbConnection.QueryFirstOrDefault<Filme>(sql);
            return result;
        }

        public void Update(Filme entity)
        {
            TSqlQueryType queryType = TSqlQueryType.UPDATE_FILMES;
            string sql = SQlManager.GetSql(queryType);
            sql = ReplaceQueryParameters(queryType, entity, sql);
            _dbConnection.Execute(sql);
        }

        private string ReplaceQueryParameters(TSqlQueryType queryType, Filme entity, string querySql)
        {
            string sql = querySql;

            switch (queryType)
            {
                case TSqlQueryType.CREATE_FILMES:
                    sql = sql
                        .Replace("@nome", entity.Nome)
                        .Replace("@genero", entity.Genero)
                        .Replace("@ano", entity.Ano.ToString());
                    break;

                case TSqlQueryType.UPDATE_FILMES:
                    sql = sql
                        .Replace("@id", entity.Id.ToString())
                        .Replace("@nome", entity.Nome)
                        .Replace("@genero", entity.Genero)
                        .Replace("@ano", entity.Ano.ToString());
                    break;

                case TSqlQueryType.GET_FILMES:
                    sql = sql
                        .Replace("@id", entity.Id.ToString());
                    break;

                case TSqlQueryType.DELETE_FILMES:
                    sql = sql
                        .Replace("@id", entity.Id.ToString());
                    break;
            }

            return sql;
        }
    }
}
