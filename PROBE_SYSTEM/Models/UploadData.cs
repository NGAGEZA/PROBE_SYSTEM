using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Npoi.Mapper.Attributes;

namespace PROBE_SYSTEM.Models
{
    public class UploadData
    {
        [Ignore]
        public int Id { get; set; }

        [Npoi.Mapper.Attributes.Column("seq")]
        public int AlternateKey { get; set; }

        [Npoi.Mapper.Attributes.Column("first")]
        public string FirstName { get; set; }

        [Npoi.Mapper.Attributes.Column("last")]
        public string LastName { get; set; }

        [Npoi.Mapper.Attributes.Column("email")]
        public string Email { get; set; }

        [Npoi.Mapper.Attributes.Column("gender")]
        public string Gender { get; set; }
    }
}
