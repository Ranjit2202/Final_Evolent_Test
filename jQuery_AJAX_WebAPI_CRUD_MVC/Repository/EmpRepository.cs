using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CRUDUsingMVC.Models;
namespace CRUDUsingMVC.Repository
{
    public class EmpRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["TestSchema"].ToString();
            con = new SqlConnection(constr);
        }
        public bool AddEmployee(Tbl_Contact obj)
        {
            connection();
            SqlCommand com = new SqlCommand("CRUD_SP", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Query", 1);
            com.Parameters.AddWithValue("@Id", 0);
            com.Parameters.AddWithValue("@First_Name", obj.First_Name);
            com.Parameters.AddWithValue("@Last_Name", obj.Last_Name);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            com.Parameters.AddWithValue("@Status", obj.Status);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Tbl_Contact> GetAllEmployees()
        {
            connection();
            List<Tbl_Contact> EmpList = new List<Tbl_Contact>();
            SqlCommand com = new SqlCommand("CRUD_SP", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Query", 2);
            com.Parameters.AddWithValue("@Id", 0);
            com.Parameters.AddWithValue("@First_Name", null);
            com.Parameters.AddWithValue("@Last_Name", null);
            com.Parameters.AddWithValue("@Email", null);
            com.Parameters.AddWithValue("@PhoneNumber", null);
            com.Parameters.AddWithValue("@Status", true);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                    new Tbl_Contact
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        First_Name = dr["First_Name"].ToString(),
                        Last_Name = dr["Last_Name"].ToString(),
                        Email = Convert.ToString(dr["Email"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                        Status = Convert.ToBoolean(dr["Status"])
                    }
                    );
            }
            return EmpList;
        }
        public bool UpdateEmployee(Tbl_Contact obj)
        {
            connection();
            SqlCommand com = new SqlCommand("CRUD_SP", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Query", 4);
            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@First_Name", obj.First_Name);
            com.Parameters.AddWithValue("@Last_Name", obj.Last_Name);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            com.Parameters.AddWithValue("@Status", obj.Status);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteEmployee(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("CRUD_SP", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Id);
            com.Parameters.AddWithValue("@Status", false);
            com.Parameters.AddWithValue("@Query", 3);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}