using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;

namespace Bioscope.Service.Implementation
{
  public class StateService : IStateService
  {
    private readonly IStateRepository _stateRepository;
    public StateService(IStateRepository stateRepository) => _stateRepository = stateRepository;

    public void AddState(State state) => _stateRepository.Add(state);

    public async Task<IEnumerable<State>> GetAllStates() => await _stateRepository.GetAll(x => x.Status != Status.Deleted);

    public async Task<State> GetStateById(long id) => await _stateRepository.GetById(id);

    public void RemoveState(State state) => _stateRepository.Delete(state);

    public void UpdateState(long id, State state) => _stateRepository.Update(state);
  }
}