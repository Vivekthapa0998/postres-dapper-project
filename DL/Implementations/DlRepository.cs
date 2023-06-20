using Dapper;
using DL.Contracts;
using Microsoft.Extensions.Configuration;
using Model;
using Npgsql;
using System.Collections.Generic;
using System.Data;


namespace DL.Implementations
{
    public class DlRepository : IDlRepository
    {
        private IDbConnection _db;

        public DlRepository(IConfiguration configuration)
        {
            _db = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public void Createrepo(Repository repo)
        {
            var sql = "INSERT INTO apistarter.repositories (name, description, owner) VALUES(@Name, @Description, @Owner);";
            _db.Execute(sql, new
            {
                Name = repo.Name,
                Description = repo.Description,
                Owner = repo.Owner
            });
        }

        public void Deleterepo(int id)
        {
            var sql = "DELETE FROM apistarter.repositories WHERE id = @id;";
            _db.Execute(sql, new
            {
                id = id
            });
        }

        public List<Repository> Getall()
        {
            var sql = "SELECT * FROM apistarter.repositories";
            return _db.Query<Repository>(sql).ToList();
        }

        public Repository GetById(int id)
        {
            var sql = "SELECT * FROM apistarter.repositories WHERE id = @id";
            return _db.QuerySingleOrDefault<Repository>(sql, new { id = id });
        }

        public void Updaterepo(Repository repo)
        {
            var sql = "UPDATE apistarter.repositories SET name = @Name, description = @Description, owner = @Owner " +
                      "WHERE id = @Id";
            _db.Execute(sql, new
            {
                Id = repo.Id,
                Name = repo.Name,
                Description = repo.Description,
                Owner = repo.Owner
            });
        }
    }
}
