using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobsBoardCRUD.Model
{
    public class JobList
    {
        public int ID { get; set; }
        public string Job { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpiresAt { get; set; }
    }
}
