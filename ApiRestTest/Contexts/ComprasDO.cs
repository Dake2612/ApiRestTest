using System;
using ApiRestTest.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiRestTest.Contexts
{
    public class ComprasDO
    {
        public List<Compra> getCompras(ConexionSQLServer context)
        {
            List<Compra> compras = new List<Compra>();
            compras = context.Compra.ToList();
            return compras;
        }

        public List<ComprasPorUsuario> getComprasPorUsuario(ConexionSQLServer context, int id)
        {
            List<ComprasPorUsuario> comprasPorUsuarios = new List<ComprasPorUsuario>();
            SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand comando = conexion.CreateCommand();
            conexion.Open();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "sp_ObtenerComprasPorUsuario";
            comando.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = id;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                ComprasPorUsuario comprasPorUsuario = new ComprasPorUsuario();
                comprasPorUsuario.id = (int)reader["id"];
                comprasPorUsuario.ProductName = (string)reader["ProductName"];
                comprasPorUsuario.ProductCuantity = (int)reader["ProductCuantity"];
                comprasPorUsuario.BuyDate = (DateTime)reader["BuyDate"];
                comprasPorUsuarios.Add(comprasPorUsuario);

            }
            conexion.Close();
            return comprasPorUsuarios;
        }

        public string insertarCompra(ConexionSQLServer context, List<Compra> compras, DateTime now)
        {
            string respuesta = "Compras insertadas con exito";
            int compra = 0;
            for (int i = 0; i < compras.Count; i++)
            {
                int response = 0;
                int compraId = 0;
                SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection();
                SqlCommand comando = conexion.CreateCommand();
                conexion.Open();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "sp_InsertarCompra";
                comando.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = compras[i].UserId;
                comando.Parameters.Add("@ProductId", System.Data.SqlDbType.Int).Value = compras[i].ProductId;
                comando.Parameters.Add("@ProductCuantity", System.Data.SqlDbType.Int).Value = compras[i].ProductCuantity;
                comando.Parameters.Add("@BuyDate", System.Data.SqlDbType.DateTime).Value = now;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    response = (int)reader["ResponseNumber"];
                    compraId = (int)reader["Compra"];
                }
                conexion.Close();
                if(i == 0)
                {
                    compra = compraId;
                }
                else
                {
                    if(compraId != compra)
                    {
                        respuesta = "Se insertaron compras con distintos códigos";
                    }
                }
                if(response != 1)
                {
                    respuesta = "Hubo un error al insertar una o mas compras";
                }
            }
            return respuesta;
        }
    }
}

