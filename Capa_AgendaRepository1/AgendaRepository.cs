using Capa_ModeloEntidades1;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Capa_AgendaRepository1
{
    public class AgendaRepository
    {
        private string ConnectionString;
       

        public AgendaRepository()
        {
            ConnectionString = @"Persist Security Info=False;Integrated Security=True;Initial Catalog=ExamenBack;Data Source=TOSHIBA\SQL2012_AMGLOCAL;Connect Timeout=30;";            
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }


        public void Add(Agenda Age)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Agenda (id, Name, City, Phone, CodeCountry, Email) VALUES (NEWID(), @Name, @City, @Phone, @CodeCountry, @Email)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Age);
            }
        }

        public IEnumerable<Agenda> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Agenda";
                dbConnection.Open();
                return dbConnection.Query<Agenda>(sQuery);
            }
        }

        public Agenda GetById(Guid id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Agenda WHERE id=@id";
                dbConnection.Open();
                return dbConnection.Query<Agenda>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(Guid id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Agenda WHERE id=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Agenda Age)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Agenda SET id=@id, Name=@Name, City=@City, Phone=@Phone, CodeCountry=@CodeCountry, Email@Email WHERE id=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Age);
            }
        }
    }
}
