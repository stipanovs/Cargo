﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities;
using CargoLogistic.DAL.Repository;

namespace CargoLogistic.DAL.Interfaces
{
    public interface ILocalityRepository : IRepository<Locality>
    {
        Locality GetByName(string name);
    }
}
