using System;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleRules
{
    public class WhenStatement<T>
    {
        internal Expression<Func<T, bool>> ConditionExpression { get; set; }
        internal Action<T> TrueAction { get; set; }
        internal Action<T> FalseAction { get; set; }

        internal WhenStatement(Expression<Func<T,bool>> condition)
        {
            ConditionExpression = condition;
        }

        public WhenStatement<T> Or(Expression<Func<T, bool>> expression)
        {
            var expr1 = Expression.Lambda<Func<T, bool>>(
                ConditionExpression.Body, ConditionExpression.Parameters);
            var expr2 = Expression.Invoke(expression, expr1.Parameters.Cast<Expression>());

            var newExpression = Expression.Lambda<Func<T, bool>>(
                Expression.OrElse(expr1.Body, expr2), expr1.Parameters);

            ConditionExpression = newExpression;

            return this;
        }

        public WhenStatement<T> And(Expression<Func<T, bool>> expression)
        {
            var expr1 = Expression.Lambda<Func<T, bool>>(
                ConditionExpression.Body, ConditionExpression.Parameters);
            var expr2 = Expression.Invoke(expression, expr1.Parameters.Cast<Expression>());

            var newExpression = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(expr1.Body, expr2), expr1.Parameters);

            ConditionExpression = newExpression;

            return this;
        }

        public WhenStatement<T> Then(Action<T> action)
        {
            TrueAction = action;
            return this;
        }

        public void Else(Action<T> action)
        {
            FalseAction = action;
        }

        internal bool Evaluate(T argument)
        {
            var condition = ConditionExpression.Compile();
            return condition(argument);
        }

        internal bool IsComplete()
        {
            var conditionExists = ConditionExpression != null;
            var TrueActionExists = TrueAction != null;

            return conditionExists & TrueActionExists;
        }
    }
}
