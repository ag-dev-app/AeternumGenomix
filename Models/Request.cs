using AeternumGenomix.Formatters.MultipartDataMediaFormatter.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AeternumGenomix.Models
{
    public class Request
    {
        public HttpFile jsonFile { get; set; }
        public List<string> fields { get; set; }
    }
}
