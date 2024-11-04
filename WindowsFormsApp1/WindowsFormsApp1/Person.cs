using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Person
    {
        public Person() { }
        public Person(string Name ,string Email ,string Id) 
        {
            this.Name = Name;
            this.Id= Id;    
            this.Email = Email;

        }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        public string Id {  get; set; }
    }
}
