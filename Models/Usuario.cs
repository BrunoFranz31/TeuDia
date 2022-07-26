using System;
using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Http;
namespace Bruno___SENAC.Models
{
    public class Usuario{
      public int id { get; set; }
      public string login { get; set; }
      public string senha { get; set; }
    }
}