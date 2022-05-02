﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Data.Persistence.Extensions
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> New<T>()
        {
            return f => true;
        }

        public static Expression<Func<T,bool>> Or<T>(this Expression<Func<T,bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            var invokedExpression = Expression.Invoke(expression2, expression1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expression1.Body, invokedExpression), expression1.Parameters);
        }

        public static Expression<Func<T,bool>> And<T>(this Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            var invokedExpression = Expression.Invoke(expression2, expression1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expression1.Body, invokedExpression), expression1.Parameters);
        }
    }
}
