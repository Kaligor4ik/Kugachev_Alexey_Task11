using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    [Serializable]
    class History : Dictionary<DateTime, string>
    {
        public History() : base()
        {
        }

        public History(string newHistory)
        {
            Add(DateTime.Now, newHistory);
        }

        public History(string newHistory, Dictionary<DateTime, string> previousHistory)
        {
            Add(DateTime.Now, newHistory);
            this.Concat(previousHistory);
        }
    }
}
