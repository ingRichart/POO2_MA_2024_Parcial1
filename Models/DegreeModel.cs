using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Ricardo.Models
{
    public class DegreeModel : BaseEntity
    {
        public DegreeModel()
        {
        }
        public string Nombre { get; set; }
    }
}