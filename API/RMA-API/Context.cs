using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RMA_API.Models;

namespace RMA_API.Context
{
  public class TodoContext : DbContext
  {
    public DbSet<TodoItem> TodoItems { get; set; }
    public IConfiguration Configuration { get; }

    public TodoContext(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseMySql(
          Configuration["ConnectionString"],
          Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.32-mysql")
        );
      }
    }
  }
}