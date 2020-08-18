using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BoxOfficeTestTask.Repositories.Queries
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            Expression body;
            ParameterExpression parameter;

            if (left == null && right == null)
            {
                throw new InvalidOperationException();
            }
            else if (left == null)
            {
                body = right.Body;
                parameter = right.Parameters[0];
            }
            else if (right == null)
            {
                body = left.Body;
                parameter = left.Parameters[0];
            }
            else
            {
                parameter = Expression.Parameter(typeof(T));

                var leftVisitor = new ReplaceExpressionVisitor(left.Parameters[0], parameter);
                var leftExpr = leftVisitor.Visit(left.Body);

                var rightVisitor = new ReplaceExpressionVisitor(right.Parameters[0], parameter);
                var rightExpr = rightVisitor.Visit(right.Body);

                body = Expression.AndAlso(leftExpr, rightExpr);
            }

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        public static Expression<Func<T, bool>> ValidatedAndAlso<T>(
           this Expression<Func<T, bool>> result, string value,
           Expression<Func<T, bool>> expression)
        {
            return result.ValidatedAndAlso<T>(!string.IsNullOrEmpty(value), expression);
        }

        public static Expression<Func<T, bool>> ValidatedAndAlso<T>(
            this Expression<Func<T, bool>> result, long? value,
            Expression<Func<T, bool>> expression)
        {
            return result.ValidatedAndAlso<T>(value.HasValue, expression);
        }

        public static Expression<Func<T, bool>> ValidatedAndAlso<T>(
          this Expression<Func<T, bool>> result, ulong? value,
          Expression<Func<T, bool>> expression)
        {
            return result.ValidatedAndAlso<T>(value.HasValue, expression);
        }

        public static Expression<Func<T, bool>> ValidatedAndAlso<T>(
          this Expression<Func<T, bool>> result, ushort? value,
          Expression<Func<T, bool>> expression)
        {
            return result.ValidatedAndAlso<T>(value.HasValue, expression);
        }


        public static Expression<Func<T, bool>> ValidatedAndAlso<T>(
          this Expression<Func<T, bool>> result, uint? value,
          Expression<Func<T, bool>> expression)
        {
            return result.ValidatedAndAlso<T>(value.HasValue, expression);
        }

        public static Expression<Func<T, bool>> ValidatedAndAlso<T>(
          this Expression<Func<T, bool>> result, byte? value,
          Expression<Func<T, bool>> expression)
        {
            return result.ValidatedAndAlso<T>(value.HasValue, expression);
        }

        public static Expression<Func<T, bool>> ValidatedAndAlso<T>(
            this Expression<Func<T, bool>> result, int? value,
            Expression<Func<T, bool>> expression)
        {
            return result.ValidatedAndAlso<T>(value.HasValue, expression);
        }

        public static Expression<Func<T, bool>> ValidatedAndAlso<T>(
            this Expression<Func<T, bool>> result, decimal? value,
            Expression<Func<T, bool>> expression)
        {
            return result.ValidatedAndAlso<T>(value.HasValue, expression);
        }

        public static Expression<Func<T, bool>> ValidatedAndAlso<T>(
            this Expression<Func<T, bool>> result, float? value,
            Expression<Func<T, bool>> expression)
        {
            return result.ValidatedAndAlso<T>(value.HasValue, expression);
        }

        public static Expression<Func<T, bool>> ValidatedAndAlso<T>(
            this Expression<Func<T, bool>> result, DateTime? value,
            Expression<Func<T, bool>> expression)
        {
            return result.ValidatedAndAlso<T>(value.HasValue, expression);
        }

        private static Expression<Func<T, bool>> ValidatedAndAlso<T>(
            this Expression<Func<T, bool>> result, bool compare,
            Expression<Func<T, bool>> expression)
        {
            if (compare)
                return result.AndAlso(expression);
            return result;
        }


        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                {
                    return _newValue;
                }

                return base.Visit(node);
            }
        }
    }
}
