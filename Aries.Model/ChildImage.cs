using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aries.Model
{
    public class ChildImage
    {
        public Guid Id { get; set; }

        public int ChildId { get; set; }

        public string FileName { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public byte[] Blob { get; set; }

        public string Description { get; set; }
    }
}
