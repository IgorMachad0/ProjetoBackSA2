namespace ProjetoSA2.Classes
{

        class PF : Customer
        {
            public string SSN{get; set;}
            public string ID{get; set;}
            public DateTime birthDate{get; set;}
            
            public bool validBirthday(DateTime birthDate)
            {

                DateTime Today = DateTime.Today;
                double years = (Today - birthDate).TotalDays / 365;
                if(years >= 18){
                    return true;
                }else{
                    return false;
                }    
            }

        public override double payTaxes(float valFunc)
        {
            this.price = valFunc;
            if(price <=1500){

                this.taxes = 0;
            } else if(price <= 5000){

                this.taxes = this.price * .03;
            } else{
            
            this.taxes = this.price / 20;
            }

            this.total = this.price + this.taxes;
            return total;
        }

        }
}