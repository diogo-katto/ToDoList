using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuProjeto.DTOs;

namespace MeuProjeto.Services
{
   public interface ITarefaService
{
    Task<TarefaResponseDto> Create(TarefaCreateDto dto);
    Task<TarefaResponseDto> Update(int id, TarefaUpdateDto dto);
    Task<TarefaResponseDto> GetById(int id);
    Task<IEnumerable<TarefaResponseDto>> GetAll();
    Task Delete(int id);
}

}