using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bioscope.Service.Implementation
{
  public class DropdownService : IDropdownService
  {
    private readonly IDropdownRepository _dropdownRepository;

    public DropdownService(IDropdownRepository dropdownRepository)
    {
      _dropdownRepository = dropdownRepository;
    }

    public async Task<IEnumerable<SelectListItem>> GetItems<T>(
      Func<T, string> textField, 
      Func<T, string> valueField) where T : class
    {
      var selectList = await _dropdownRepository.AsQueryable<T>()
        .Select(x => new SelectListItem
        {
          Text = textField(x),
            Value = valueField(x),
        }).ToListAsync();
      return selectList;
    }

    public async Task<IEnumerable<SelectListItem>> GetItems<T>(
      Func<T, string> textField,
      Func<T, string> valueField,
      Expression<Func<T, bool>> where) where T : class
    {
      var selectList = await _dropdownRepository.AsQueryable<T>().Where(where)
        .Select(x => new SelectListItem
        {
          Text = textField(x),
            Value = valueField(x),
        }).ToListAsync();

      return selectList;
    }
  }
}