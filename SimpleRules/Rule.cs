using System;
using System.Linq.Expressions;

namespace SimpleRules
{
    public class Rule<T>
    {
        public string Message { get; set; }
        public WhenStatement<T> Condition { get; set; }

        public WhenStatement<T> When(Expression<Func<T, bool>> expression)
        {
            Condition = new WhenStatement<T>(expression);
            return Condition;
        }

        public bool Evaluate(T obj)
        {
            if (!Condition.Evaluate(obj))
            {
                if (Condition.FalseAction != null)
                {
                    Condition.FalseAction(obj);
                }
                return false;
            }

            if (Condition.TrueAction != null)
            {
                Condition.TrueAction(obj);
            }
            return true;
        }

        internal bool IsComplete()
        {
            if (Condition == null)
            {
                return false;
            }
            if (!Condition.IsComplete())
            {
                return false;
            }
            return true;
        }
    }
}
