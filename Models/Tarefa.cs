using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjeto.Models
{
    public class Tarefa
    {
       public string? Nome {get;set;}
       public string? Descricao{get;set;}
       public DateTime DateTime{get;set;}
        public int Id {get;set;}
        public bool Concluida{get;set;}
    }
}