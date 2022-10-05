using System;
using ApiRestTest.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiRestTest.Contexts
{
    public class UsuarioDO
    {
        public List<Usuario> getUsuarios(ConexionSQLServer context)
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = context.Usuario.ToList();
            return usuarios;
        }

        public Usuario insertUsuario(ConexionSQLServer context, Usuario user)
        {
            Usuario usuario = new Usuario();
            SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand comando = conexion.CreateCommand();
            conexion.Open();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "sp_InsertarUsuario";
            comando.Parameters.Add("@UserEmail", System.Data.SqlDbType.NVarChar, 255).Value = user.UserEmail;
            comando.Parameters.Add("@UserPassword", System.Data.SqlDbType.NVarChar, 255).Value = user.UserPassword;
            comando.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar, 255).Value = user.UserName;
            comando.Parameters.Add("@UserLastName", System.Data.SqlDbType.NVarChar, 255).Value = user.UserLastName;
            comando.Parameters.Add("@UserDNI", System.Data.SqlDbType.NVarChar, 255).Value = user.UserDNI;
            comando.Parameters.Add("@UserAge", System.Data.SqlDbType.Int).Value = user.UserAge;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                usuario.id = (int)reader["UserId"];
                usuario.UserEmail = (string)reader["UserEmail"];
                usuario.UserName = (string)reader["UserName"];
                usuario.UserLastName = (string)reader["UserLastName"];
                usuario.UserDNI = (string)reader["UserDNI"];
                usuario.UserAge = (int)reader["UserAge"];
            }
            conexion.Close();
            return usuario;
        }

        public Usuario modificarUsuario(ConexionSQLServer context, Usuario user)
        {
            Usuario usuario = new Usuario();
            SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand comando = conexion.CreateCommand();
            conexion.Open();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "sp_ModificarUsuario";
            comando.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = user.id;
            comando.Parameters.Add("@UserEmail", System.Data.SqlDbType.NVarChar, 255).Value = user.UserEmail;
            comando.Parameters.Add("@UserPassword", System.Data.SqlDbType.NVarChar, 255).Value = user.UserPassword;
            comando.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar, 255).Value = user.UserName;
            comando.Parameters.Add("@UserLastName", System.Data.SqlDbType.NVarChar, 255).Value = user.UserLastName;
            comando.Parameters.Add("@UserDNI", System.Data.SqlDbType.NVarChar, 255).Value = user.UserDNI;
            comando.Parameters.Add("@UserAge", System.Data.SqlDbType.Int).Value = user.UserAge;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                usuario.id = (int)reader["UserId"];
                usuario.UserEmail = (string)reader["UserEmail"];
                usuario.UserName = (string)reader["UserName"];
                usuario.UserLastName = (string)reader["UserLastName"];
                usuario.UserDNI = (string)reader["UserDNI"];
                usuario.UserAge = (int)reader["UserAge"];
            }
            conexion.Close();
            return usuario;
        }

        public string eliminarUsuario(ConexionSQLServer context, int id)
        {
            string responseMessage = "";
            SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand comando = conexion.CreateCommand();
            conexion.Open();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "sp_EliminarUsuario";
            comando.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = id;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                responseMessage = (string)reader["ResponseMessage"];
            }
            conexion.Close();
            return responseMessage;
        }
    }
}

