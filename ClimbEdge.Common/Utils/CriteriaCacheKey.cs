using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Common.Utils
{
    public class CriteriaCacheKey
    {
        public static string For<T, K>(Expression<Func<T, K>> criteria)
        {
            return ExpressionNormalizer.Normalize(criteria);
        }
    }
    internal sealed class ExpressionNormalizer : ExpressionVisitor
    {
        public static string Normalize(LambdaExpression expression)
        {
            var normalizer = new ExpressionNormalizer();
            return normalizer.Visit(expression).ToString();
        }
    }
}
