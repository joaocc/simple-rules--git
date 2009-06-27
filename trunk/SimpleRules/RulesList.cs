using System.Linq;
using System.Collections.Generic;

namespace SimpleRules
{
    public class RulesList<T>
    {
        private Dictionary<string, Rule<T>> _rules;
        private List<string> _messages;

        public IEnumerable<string> Messages
        {
            get { return _messages; }
        }

        public RulesList()
        {
            _rules = new Dictionary<string, Rule<T>>();
            _messages = new List<string>();
        }

        public Rule<T> Add(string message)
        {
            var newRule = new Rule<T> { Message = message };
            _rules.Add(message, newRule);
            return newRule;
        }

        public void Remove(string message)
        {
            if (!_rules.ContainsKey(message))
            {
                return;
            }
            _rules.Remove(message);
        }

        public int Count()
        {
            return _rules.Count();
        }

        public void Evaluate(T item)
        {
            RemoveIncompleteRules();
            RunRules(item);
        }

        private void RunRules(T item)
        {
            foreach (var keyValuePair in _rules)
            {
                var rule = keyValuePair.Value;
                if (!rule.Evaluate(item))
                {
                    continue;
                }

                if (_messages.Contains(rule.Message))
                {
                    continue;
                }
                _messages.Add(rule.Message);
            }
        }

        private void RemoveIncompleteRules()
        {
            var incompleteRules = _rules
                .Where(r => !r.Value.IsComplete())
                .ToArray();

            foreach (var rule in incompleteRules)
            {
                _rules.Remove(rule.Key);
            }
        }

        public bool ContainsRule(string name)
        {
            return _rules.ContainsKey(name);
        }

        public IEnumerable<Rule<T>> FindIncompleteRules()
        {
            return _rules.Values.Where(r => !r.IsComplete()).ToArray();
        }
    }
}
