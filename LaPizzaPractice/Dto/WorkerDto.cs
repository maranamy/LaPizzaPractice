using System;
using System.Collections.Generic;
using System.Text;

namespace LaPizzaPractice.Dto
{
    public class WorkerDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Role { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
