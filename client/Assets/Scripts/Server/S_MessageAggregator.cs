using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace S_Services
{
    /// <summary>
    ///     Takes in messages, holds references to them
    /// and combines them based on priority.
    /// </summary>
    public class MessageAggregator
    {
        private readonly Dictionary<int, Queue<object>> messages = new Dictionary<int, Queue<object>>();

        public void Enqueue(object message, int priority)
        {
            if (messages.ContainsKey(priority))
                messages[priority].Enqueue(message);
            else
            {
                var q = new Queue<object>();
                q.Enqueue(message);
                messages.Add(priority, q);
            }
        }

        public void Dequeue(int size)
        {
            for (int i = 0; i < messages.Count; i++)
            {
                if (!messages.ContainsKey(i))
                    continue;

                var obj = messages[i].Dequeue();
            }
        }
    }
}