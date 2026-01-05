using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuProjeto.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuProjeto.Data
{
    public class MeuContexto : DbContext
    {
       public DbSet<Tarefa> Tarefas{get;set;}

       public MeuContexto(DbContextOptions<MeuContexto> options)
                            :base(options)
        {
            
        }
        
        
    }
}