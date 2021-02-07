﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        void Delete(Color color);
        void Update(Color color);
        void Add(Color color);
    }
}