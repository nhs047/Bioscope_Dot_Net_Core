using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;

namespace Bioscope.Service.Abstraction
{
  public interface IStateService
  {
    Task<IEnumerable<State>> GetAllStates();
    Task<State> GetStateById(long id);
    void AddState(State state);
    void UpdateState(long id, State state);
    void RemoveState(State state);
  }
}