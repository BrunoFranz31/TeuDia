using System;
using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Http;

namespace Bruno___SENAC.Models
{
    public class UsuarioRepository
    {

        /*ENDEREÇO DE CONEXÃO*/
        private const  string enderecoConexao = "Database=teudia; Datasource=localhost; Username=root;";

        // *LOGIN*/
        public Usuario Login(Usuario user){
            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlLogin = "SELECT * FROM usuarios WHERE login = @login AND senha = @senha";
            MySqlCommand comando = new MySqlCommand(sqlLogin, conexao);

            comando.Parameters.AddWithValue("@login", user.login);
            comando.Parameters.AddWithValue("@senha", user.senha);

            MySqlDataReader dados = comando.ExecuteReader();

            Usuario us = null;

            if(dados.Read()){
                us = new Usuario();
                us.id = dados.GetInt32("id");

            if(!dados.IsDBNull(dados.GetOrdinal("login")))
            us.login = dados.GetString("login");

            if(!dados.IsDBNull(dados.GetOrdinal("senha")))
            us.senha = dados.GetString("senha");
            }

            conexao.Close();
            return us;
        }
    
    }
}