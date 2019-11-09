using System;

namespace Bioscope.Infrastructure
{
  public interface IEntityTransaction : IDisposable
  {
    void Commit();
    void Rollback();
  }
}