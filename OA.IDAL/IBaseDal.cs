﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.IDAL
{
    public interface IBaseDal<T> where T : class,new()
    {
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex,out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda, bool isAsc);

        T Add(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        bool Delete(int id);

        int DeleteListByLogical(List<int> ids);

    }
}
