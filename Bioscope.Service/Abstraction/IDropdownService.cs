using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bioscope.Service.Abstraction
{
  public interface IDropdownService
  {
    Task<IEnumerable<SelectListItem>> GetItems<T>(
      Func<T, string> textField,
      Func<T, string> valueField
    ) where T : class;

    Task<IEnumerable<SelectListItem>> GetItems<T>(
      Func<T, string> textField,
      Func<T, string> valueField,
      Expression<Func<T, bool>> where
    ) where T : class;
  }
}