﻿using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IDAL
{
    public partial interface IDbSession
    {
        //IUserInfoDal UserInfoDal{get;}

        //IOrderInfoDal OrderInfoDal { get; }

        int SaveChanges();
    }
}
