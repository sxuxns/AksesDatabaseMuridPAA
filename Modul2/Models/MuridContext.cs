using Modul2.RepositoriData;
using Npgsql;
using System;

namespace Modul2.Models
{
    public class MuridContext
    {
        private string __constr;
        private string __ErrorMsg;

        public MuridContext(string pConstr)
        {
            __constr = pConstr;
        }
        public List<Murid> ListMurid()
        {
            List<Murid> list1 = new List<Murid>();
            string query = string.Format(@"SELECT id_murid, nama, alamat, email FROM users.murid;");
            SqlRepositoriData db = new SqlRepositoriData(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.getNpgsqlCommand(query);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list1.Add(new Murid()
                    {
                        id_murid = int.Parse(reader["id_murid"].ToString()),
                        nama = reader["nama"].ToString(),
                        alamat = reader["alamat"].ToString(),
                        email = reader["email"].ToString()
                    });
                }
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
            return list1;
        }

        // Create
        public void AddMurid(Murid murid)
        {
            string query = string.Format(@"INSERT INTO users.murid (nama, alamat, email) VALUES ('{0}', '{1}', '{2}');",
                murid.nama, murid.alamat, murid.email);
            SqlRepositoriData db = new SqlRepositoriData(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.getNpgsqlCommand(query);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }


        // Update
        public void UpdateMurid(Murid murid)
        {
            string query = string.Format(@"UPDATE users.murid SET nama = '{0}', alamat = '{1}', email = '{2}' WHERE id_murid = {3};",
                murid.nama, murid.alamat, murid.email, murid.id_murid);
            SqlRepositoriData db = new SqlRepositoriData(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.getNpgsqlCommand(query);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }

        // Delete
        public void DeleteMurid(int id)
        {
            string query = string.Format(@"DELETE FROM users.murid WHERE id_murid = {0};", id);
            SqlRepositoriData db = new SqlRepositoriData(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.getNpgsqlCommand(query);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }
    }
}
