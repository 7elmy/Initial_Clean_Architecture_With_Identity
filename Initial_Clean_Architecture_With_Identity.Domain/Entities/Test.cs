using Initial_Clean_Architecture_With_Identity.Domain.Constants;
using Initial_Clean_Architecture_With_Identity.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Initial_Clean_Architecture_With_Identity.Domain.Entities
{
    public class Test : ITrackableEntity
    {
        public int Id { get; set; }
        public string TestString { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
