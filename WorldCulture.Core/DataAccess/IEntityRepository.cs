﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace WorldCulture.Core.DataAccess
{
    public interface IEntityRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
