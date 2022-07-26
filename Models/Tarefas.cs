using System;
using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Http;

namespace Bruno___SENAC.Models
{
    public class Tarefas{
      public int id_tarefa { get; set; }
      public string tarefa { get; set; }
      public string horario { get; set; }
      public string descricao { get; set; }
    }
}