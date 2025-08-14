using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Common.Utils
{
    public static class ExprExtensions
    {
        /// <summary>
        /// Combina dos expresiones con AND. Soporta nulls y mantiene un único parámetro.
        /// </summary>
        public static Expression<Func<T, bool>> AndAlso<T>(
            this Expression<Func<T, bool>>? left,
            Expression<Func<T, bool>>? right)
        {
            if (left is null && right is null)
                return _ => true;                       // neutro lógico

            if (left is null)
                return right!;

            if (right is null)
                return left;

            var param = left.Parameters[0];
            var rightBody = new ReplaceParamVisitor(right.Parameters[0], param).Visit(right.Body)!;
            var body = Expression.AndAlso(left.Body, rightBody);

            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        private sealed class ReplaceParamVisitor : ExpressionVisitor
        {
            private readonly ParameterExpression _from, _to;
            public ReplaceParamVisitor(ParameterExpression from, ParameterExpression to)
            {
                _from = from; _to = to;
            }

            protected override Expression VisitParameter(ParameterExpression node)
                => node == _from ? _to : base.VisitParameter(node);
        }
    }
}
