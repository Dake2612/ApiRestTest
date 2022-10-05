using System;
using ApiRestTest.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiRestTest.Contexts
{
    public class ProductosDO
    {
        public List<Producto> getProductos(ConexionSQLServer context)
        {
            List<Producto> productos = new List<Producto>();
            productos = context.Producto.ToList();
            return productos;
        }

        public Producto insertProducto(ConexionSQLServer context, Producto product)
        {
            Producto producto = new Producto();
            SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand comando = conexion.CreateCommand();
            conexion.Open();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "sp_InsertarProducto";
            comando.Parameters.Add("@ProductName", System.Data.SqlDbType.NVarChar, 255).Value = product.ProductName;
            comando.Parameters.Add("@ProductWeigth", System.Data.SqlDbType.Float).Value = product.ProductWeigth;
            comando.Parameters.Add("@ProductHeight", System.Data.SqlDbType.Float).Value = product.ProductHeight;
            comando.Parameters.Add("@ProductWidth", System.Data.SqlDbType.Float).Value = product.ProductWidth;
            comando.Parameters.Add("@ProductCount", System.Data.SqlDbType.Int).Value = product.ProductCount;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                producto.id = (int)reader["id"];
                producto.ProductName = (string)reader["ProductName"];
                producto.ProductWeigth = (double)reader["ProductWeigth"];
                producto.ProductHeight = (double)reader["ProductHeight"];
                producto.ProductWidth = (double)reader["ProductWidth"];
                producto.ProductCount = (int)reader["ProductCount"];
            }
            conexion.Close();
            return producto;
        }

        public Producto modificarProducto(ConexionSQLServer context, Producto product)
        {
            Producto producto = new Producto();
            SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand comando = conexion.CreateCommand();
            conexion.Open();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "sp_ModificarProducto";
            comando.Parameters.Add("@ProductId", System.Data.SqlDbType.Int).Value = product.id;
            comando.Parameters.Add("@ProductName", System.Data.SqlDbType.NVarChar, 255).Value = product.ProductName;
            comando.Parameters.Add("@ProductWeigth", System.Data.SqlDbType.Float).Value = product.ProductWeigth;
            comando.Parameters.Add("@ProductHeight", System.Data.SqlDbType.Float).Value = product.ProductHeight;
            comando.Parameters.Add("@ProductWidth", System.Data.SqlDbType.Float).Value = product.ProductWidth;
            comando.Parameters.Add("@ProductCount", System.Data.SqlDbType.Int).Value = product.ProductCount;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                producto.id = (int)reader["id"];
                producto.ProductName = (string)reader["ProductName"];
                producto.ProductWeigth = (double)reader["ProductWeigth"];
                producto.ProductHeight = (double)reader["ProductHeight"];
                producto.ProductWidth = (double)reader["ProductWidth"];
                producto.ProductCount = (int)reader["ProductCount"];
            }
            conexion.Close();
            return producto;
        }

        public string eliminarProducto(ConexionSQLServer context, int id)
        {
            string responseMessage = "";
            SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand comando = conexion.CreateCommand();
            conexion.Open();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "sp_EliminarProducto";
            comando.Parameters.Add("@ProductId", System.Data.SqlDbType.Int).Value = id;
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

