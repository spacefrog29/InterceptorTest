using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorTest.Entities
{
    public interface IAuditable
    {
        public DateTime CreatedDate { get; set; }   
        public DateTime LastModifiedDate { get; set; }
    }
}
