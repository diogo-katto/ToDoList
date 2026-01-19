using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjeto.DTOs
{
    public class TarefaResponseDto
    {
        public int Id;
        public string Nome;
        public string? Descricao;
        public DateTime CreatedAt;
        public bool Concluida;
    }
}