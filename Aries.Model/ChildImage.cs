using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aries.Model
{
    public class ChildImage
    {
        public int ChildId { get; set; }

        public DateTime Date { get; set; }

        public bool IsMain { get; set; }

        public string Title { get; set; }

        public byte[] Blob { get; set; }
    }
}
