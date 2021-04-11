using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditService
    {
        IDataResult<List<Credit>> GetAll();
        IResult Delete(Credit card);
        IResult Add(Credit card);
        IDataResult<List<Credit>> GetCardsByUserId(int id);
    }
}
