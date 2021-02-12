using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService 
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IResult Add(Rental rental);
        IDataResult<Rental> GetById(int id);
    }
}
