using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSA2.Classes
{
    public abstract class Customer
    {

        public string name {get; set;}
        public Address address {get; set;}
        public double price {get; protected set;}
        public double taxes {get; protected set;}
        public double total {get; protected set;}
        
        public abstract double payTaxes(float valFunc);
    }
}