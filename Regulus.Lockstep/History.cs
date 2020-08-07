using System.Collections.Generic;
using System.Linq;

namespace Regulus.Lockstep
{
    public class History<TRecord>
    {
        private readonly Queue<Step<TRecord>> _Steps;

        public History()
        {
            _Steps = new Queue<Step<TRecord>>();
        }

        public Step<TRecord> Write(IEnumerable<TRecord> records)
        {
            Step<TRecord> step = new Step<TRecord> { Records = records.ToArray() };
            _Steps.Enqueue(step);

            return step;
        }

        public IEnumerable<Step<TRecord>> GetEnumerable()
        {
            foreach (Step<TRecord> step in _Steps)
            {
                yield return step;
            }
        }
    }
}