﻿using ImgBoard.Dal.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Manipulation.Repositories.Contracts
{
    public interface IImageRepository : IGenericRepository<DbImage>
    {
    }
}
