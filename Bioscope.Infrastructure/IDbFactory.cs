using System;
using Microsoft.EntityFrameworkCore;

namespace Bioscope.Infrastructure
{
  public interface IDbFactory<TContext> : IDisposable where TContext : DbContext
  {
    TContext Init();
  }
}