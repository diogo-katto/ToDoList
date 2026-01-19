
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MeuProjeto.Data;
using MeuProjeto.DTOs;
using MeuProjeto.Models;
using MeuProjeto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MeuProjeto.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TarefasController : ControllerBase
  {
    private readonly ITarefaService _service;
    public TarefasController(ITarefaService service)
    {
      _service = service;
    }
    [HttpPost]
    public async Task<ActionResult> Create(TarefaCreateDto dto)
    {
      var result = await _service.Create(dto);
      return CreatedAtAction(nameof(GetById), new {id = result.Id}, result);
    }
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
      var result = await _service.GetAll();
      return Ok(result);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(int Id)
    {
      try
      {
        var result = await _service.GetById(Id);
        return Ok(result);
      }
      catch(Exception ex)
      {
        return NotFound(ex.Message);
      }
    }
    [HttpPut("{Id}")]
    public async Task<IActionResult> Update(int Id, TarefaUpdateDto dto)
    {
      try
      {
        var result = await _service.Update(Id, dto);
        return Ok(result);
      }
      catch(Exception ex)
      {
        return NotFound(ex.Message);
      }
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int Id)
    {
      try
      {
        await _service.Delete(Id);
        return NoContent();
      }
      catch(Exception ex)
      {
        return NotFound(ex.Message);
      }
    }
  }
}