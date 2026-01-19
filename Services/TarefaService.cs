using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuProjeto.Controllers;
using MeuProjeto.Data;
using MeuProjeto.DTOs;
using MeuProjeto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MeuProjeto.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly MeuContexto _context;
        public  TarefaService (MeuContexto context)
        {
            _context = context;
        }

        public async Task<TarefaResponseDto> Create(TarefaCreateDto dto)
        {
            var tarefa = new Tarefa
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
        };

        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();

        return new TarefaResponseDto
        {
            Id = tarefa.Id,
            Nome = tarefa.Nome,
            Descricao = tarefa.Descricao,
            Concluida = tarefa.Concluida,
        };
        }


        public async Task<TarefaResponseDto> Update(int Id, TarefaUpdateDto dto)
        {
            var tarefa =await _context.Tarefas.FindAsync(Id);
            if(tarefa == null) throw new Exception("Tarefa não encontrada!");

            if (dto.Nome != null) tarefa.Nome = dto.Nome;

            if (dto.Descricao != null) tarefa.Descricao= dto.Descricao;
            if (dto.Concluida.HasValue) tarefa.Concluida= dto.Concluida.Value;
            await _context.SaveChangesAsync();

            return new TarefaResponseDto
            {
                Id = tarefa.Id,
                Nome = tarefa.Nome,
                Concluida= tarefa.Concluida
            };
        }
        public async Task<IEnumerable<TarefaResponseDto>> GetAll()
        {
            return await _context.Tarefas
            .Select(t => new TarefaResponseDto
            {
                Id = t.Id,
                Nome = t.Nome,
                Concluida= t.Concluida
            })
            .ToListAsync();
        }
        public async Task<TarefaResponseDto> GetById(int Id)
        {
            var tarefa = await _context.Tarefas.FindAsync(Id);
            if(tarefa == null) throw new Exception("Tarefa não encontrada!");
            return new TarefaResponseDto
            {
                Id = tarefa.Id,
                Nome= tarefa.Nome,
                Descricao= tarefa.Descricao,
                Concluida = tarefa.Concluida
            };
        }
        public async Task Delete (int Id)
        {
            var tarefa = await _context.Tarefas.FindAsync(Id);
            if(tarefa ==null) throw new Exception("Tarefa não encontrada!");
            
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

        }

        
    }
}