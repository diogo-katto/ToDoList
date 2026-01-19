using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjeto.DTOs
{
    public class TarefaUpdateDto
    {
        public string? Nome {get; set;}
        public string? Descricao{get;set;}
        public bool? Concluida{get;set;}
    }
}