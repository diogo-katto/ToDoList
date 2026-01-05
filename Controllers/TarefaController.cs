
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MeuProjeto.Data;
using MeuProjeto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MeuProjeto.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TarefaController : ControllerBase
    {
        private readonly MeuContexto  _context;
        public  TarefaController(MeuContexto context)
        {
           _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefa()
        {
          var tarefas= await _context.Tarefas.ToListAsync();
          return Ok(tarefas);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Tarefa>> GetId(int Id)
         {
          var tarefa= await _context.Tarefas.FindAsync(Id);
          if( tarefa== null)
          {
            return NotFound("Tarefa não encontrada!");
          }
          else return Ok(tarefa);
         }
         [HttpPost]
         public async Task<ActionResult<Tarefa>> PostTarefa(Tarefa tarefa)
          {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return Ok(tarefa);
          }
          [HttpPut("{Id}")]
          public async Task<ActionResult<Tarefa>> PutTarefa(int Id, Tarefa TarefaAtualizada)
          {
            var tarefaExistente = await _context.Tarefas.FindAsync(Id);
            if(tarefaExistente==null)return NotFound();

            tarefaExistente.Nome = TarefaAtualizada.Nome;
            tarefaExistente.Descricao= TarefaAtualizada.Descricao;
            tarefaExistente.Concluida= TarefaAtualizada.Concluida;

            await _context.SaveChangesAsync();
            return Ok(TarefaAtualizada);
          }
          [HttpDelete("{Id}")]
          public async Task<ActionResult<Tarefa>> DeleteTarefa(int Id)
          {
            var tarefaApagar = await _context.Tarefas.FindAsync(Id);

            if(tarefaApagar==null)return NotFound();
            _context.Tarefas.Remove(tarefaApagar);
            await _context.SaveChangesAsync();
           
            return NoContent();
      
          }
          
    }
}