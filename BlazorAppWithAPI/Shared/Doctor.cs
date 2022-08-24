using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppWithAPI.Shared
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Registration { get; set; }
        public string? DateofIssue { get; set; }
        public string? DateofValid { get; set; }
    }
}
