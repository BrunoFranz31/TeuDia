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
            return us;}
    
   
           
           
        /*REGISTRO DE TAREFAS*/
        public void Insert_Tarefas(Tarefas compromisso){
                        
        MySqlConnection conexao = new MySqlConnection(enderecoConexao);

        conexao.Open();

        string sqlInsert = "INSERT INTO Tarefas (tarefa, horario, descricao) VALUES (@tarefa, @horario, @descricao)";

        MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);

        comando.Parameters.AddWithValue("@tarefa", compromisso.tarefa);
        comando.Parameters.AddWithValue("@horario", compromisso.horario);
        comando.Parameters.AddWithValue("@descricao", compromisso.descricao);

        comando.ExecuteNonQuery();

        conexao.Close();}

                   /*LISTAGEM DE TAREFAS*/
        public List<Tarefas> Listar_Tarefas(){

        MySqlConnection conexao = new MySqlConnection(enderecoConexao);

        conexao.Open(); 

        string sqlList = "SELECT * FROM Tarefas ORDER BY tarefa";

        MySqlCommand comando = new MySqlCommand(sqlList, conexao);

        MySqlDataReader dados = comando.ExecuteReader();

        List<Tarefas> lista = new List<Tarefas>();
        
        while(dados.Read()){
        
        Tarefas compromisso = new Tarefas();

        compromisso.id_tarefa = dados.GetInt32("id_tarefa");

        if(!dados.IsDBNull(dados.GetOrdinal("tarefa")))
        compromisso.tarefa = dados.GetString("tarefa");

        if(!dados.IsDBNull(dados.GetOrdinal("horario")))
        compromisso.horario = dados.GetString("horario");

        if(!dados.IsDBNull(dados.GetOrdinal("descricao")))
        compromisso.descricao = dados.GetString("descricao");

        lista.Add(compromisso);}
        
        conexao.Close();
       
        return lista;}

        /*EXCLUSÃO DE PACOTES*/
         public void Excluir_T(int id_tarefa){

        MySqlConnection conexao = new MySqlConnection(enderecoConexao);

        conexao.Open();

        string sqlDelete = "DELETE FROM Tarefas WHERE id_tarefa = @id_tarefa";

        MySqlCommand comando = new MySqlCommand(sqlDelete, conexao);

        comando.Parameters.AddWithValue("@id_tarefa", id_tarefa);

        comando.ExecuteNonQuery();

        conexao.Close();
    }

    }
}