﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IDAL
{
    public partial interface IDbSession
    {
				 IActionInfoDal ActionInfoDal{get;}	
				 IOrderInfoDal OrderInfoDal{get;}	
				 IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal{get;}	
				 IRoleInfoDal RoleInfoDal{get;}	
				 IUserInfoDal UserInfoDal{get;}	
			}
}
