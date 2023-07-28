using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSA2.Classes
{

    class PJ : Customer
    {
        public string EIN {get; set;}
        public string CIK {get; set;}

        public override double payTaxes(float valFunc)
        {
            this.price = valFunc;
            if(price <=5000){

                this.taxes = this.price * .06;
            } else if(price <= 10000){

                this.taxes = this.price * .08;
            } else{
            
            this.taxes = this.price / 10;
            }

            this.total = this.price + this.taxes;
            return total;
        }

        public bool invalidEIN(string EIN)
        {

            if((EIN.Length == 9) && (EIN.Substring(0, 3)) != "666"){

                return false;

            }   else{

                return true;
            }
        }
    }
}