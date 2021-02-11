using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Delete(Color color);
        IResult Update(Color color);
        IResult Add(Color color);
    }
}
