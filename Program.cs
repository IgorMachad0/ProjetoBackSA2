using System;
using ProjetoSA2.Classes;

namespace ProjetoSA2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<PF> PFlist = new List<PF>();
            List<PJ> PJlist = new List<PJ>();
            float finalPrice;
            int customerType;
            string menu;
            
            void loading(string sectionName){
            
            Console.WriteLine("");
            Console.Write(sectionName);
            for (var counter = 0; counter < 4; counter++){
            
            Thread.Sleep(200);
            Console.Write(".");}

            Thread.Sleep(400);
            Console.Clear();
            Console.WriteLine(@$"
            ");
            }

                        
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.White;  
            Console.WriteLine(); 
            loading("Initializing Main-Menu");
            Console.WriteLine(@$"

____________________________________________________________________________
|                                                                          |
|              Welcome to the custommer registration system!               |
|                                                                          |
|__________________________________________________________________________|
|                                                                          |");
        Start:

Console.WriteLine(@$"*************************** Select an option: ******************************
*                                                                          *
*                       (1) - Register custommer                           *
*                      (2) - View custommers list                          *
*                                                                          *
*                  (3) - Register bussiness custommer                      *
*                 (4) - View bussiness custommers list                     *
*                                                                          *
*                              (0) - Quit                                  *
*                                                                          *
****************************************************************************");

                customerType = 2;
                menu = Console.ReadLine();
                switch (menu){

                    case "1":

                    break;

                    case "2":

                    Console.Clear();
                    if(PFlist.Count == 0){
                    Console.WriteLine("There are no registers yet.");
                    Console.Write("(Press any key to return to Main-Menu.)");
                    Console.ReadKey();
                    Console.Clear();
                    goto Start;
                    }else{
                    
            Console.WriteLine(@$"
____________________________________________________________________________
|                                                                          |
|                            Custommers list                               |
|__________________________________________________________________________|
");
                    foreach(PF eachCustommer in PFlist){
                    
                    Console.Write(@$"Name: {eachCustommer.name} Birth day: {eachCustommer.birthDate} Address: {eachCustommer.address.num} {eachCustommer.address.street} ZIP code: {eachCustommer.address.ZIP} SSN: {eachCustommer.SSN} ID: {eachCustommer.ID}");
                    Console.WriteLine();
                    }

                    Console.WriteLine();
                    Console.Write("(Press any key to return to Main-Menu.)");
                    Console.ReadKey();
                    Console.Clear();
                    goto Start;
                    }
                    
                    case "3":

                    customerType = 1;

                    break;

                    case "4":

                    Console.Clear();                    
                    if(PJlist.Count == 0){
                    Console.WriteLine("There are no registers yet.");
                    Console.Write("(Press any key to return to Main-Menu.)");
                    Console.ReadKey();
                    goto Start;
                    }

                    foreach(PJ eachCustommer in PJlist){
                    
                    Console.Write(@$"Name: {eachCustommer.name} Address: {eachCustommer.address.num} {eachCustommer.address.street} ZIP code: {eachCustommer.address.ZIP} SSN: {eachCustommer.EIN} ID: {eachCustommer.CIK}");
                    Console.WriteLine();
                    }
                    Console.Write("(Press any key to return to Main-Menu.)");
                    Console.ReadKey();
                    goto Start;

                    case "0":

                    Console.WriteLine("");
                    Console.WriteLine("Thanks for using my system!");
                    Console.WriteLine("");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Environment.Exit(0);

                    break;

                    default:

                    Console.WriteLine("Invalid option, please select a valid one.");
                    Console.WriteLine("(Press any key to continue)");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("");
                    goto Start;
                }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;   
            loading("Initializing custommer registration");
            Console.WriteLine(@$"
____________________________________________________________________________
|                       Custommer Registration Form                        |
|__________________________________________________________________________|
|                                                                          |");
                Console.Write("Customer name: ");
                string varName = Console.ReadLine();
                Console.Write("Inform your street's name: ");
                string varStreet = Console.ReadLine();
                Console.Write("What's the number of your place: ");
                int varNumAdress = int.Parse(Console.ReadLine());
                Console.Write("Write your ZIP code: ");
                int varZIPCode = int.Parse(Console.ReadLine());

                if(customerType == 1)
                {

                    Address addrB = new Address();
                    {

                    addrB.street = varStreet;
                    addrB.num = varNumAdress;
                    addrB.ZIP = varZIPCode;
                    addrB.bussinessAddress = true;
                    }

                    PJ pessoaJuridica = new PJ();
                    {
                        pessoaJuridica.name = varName;
                        pessoaJuridica.address = addrB;
                        tryEIN:
                        Console.Write("Write your EIN: ");
                        pessoaJuridica.EIN = Console.ReadLine();
                        if (pessoaJuridica.invalidEIN(pessoaJuridica.EIN))
                        {
                            
                            Console.WriteLine("Customer register failed: invalid EIN.");
                            Console.WriteLine("Enter a valid EIN.");
                            goto tryEIN;
                        }
                        Console.Write("Write your CIK: ");
                        pessoaJuridica.CIK = Console.ReadLine();
                        
                        validPricePJ:

                        Console.Write("Total purchase price: ");
                        float.TryParse(Console.ReadLine(), out finalPrice);
                        if(finalPrice <= 0){

                                Console.WriteLine("Invalid price informed, please try again.");
                                goto validPricePJ;
                        }

                        pessoaJuridica.payTaxes(finalPrice);
                        PJlist.Add(pessoaJuridica);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.White;   
                        loading("Processing");
                        Console.Clear();
                        Console.WriteLine(@$"
____________________________________________________________________________
|                    Custommer registered sucessfully!                     |
|__________________________________________________________________________|
|                                                                          |");
                        Console.WriteLine("");
                        Console.WriteLine("Name............: " + pessoaJuridica.name);
                        Console.WriteLine($"Address.........: St. {0} num.{1} ZIP code: {2}", addrB.street, addrB.num, addrB.ZIP);
                        Console.WriteLine("EIN.............: " + pessoaJuridica.EIN);
                        Console.WriteLine("CIK.............: " + pessoaJuridica.CIK);
                        Console.WriteLine("Purchase Price..: " + pessoaJuridica.price.ToString("C"));
                        Console.WriteLine("Taxes...........: " + pessoaJuridica.taxes.ToString("C"));
                        Console.WriteLine("Price with taxes: " + pessoaJuridica.total.ToString("C"));
                         Console.WriteLine();
                         Console.Write("Press any key to go back to Main-Menu");
                         Console.ReadKey();                        
                    }
                }

                    Address addr = new Address();
                    {

                    addr.street = varStreet;
                    addr.num = varNumAdress;
                    addr.ZIP = varZIPCode;
                    addr.bussinessAddress = false;
                    }
                    
                    PF pessoaFisica = new PF();
                    {
                        
                        Console.Write("Enter your birth day(MM/DD/YYYY): ");
                        pessoaFisica.birthDate = DateTime.Parse(Console.ReadLine());
                        if(!pessoaFisica.validBirthday(pessoaFisica.birthDate)){
                            Console.WriteLine("Customer register failed: underage restriction.");
                            goto Start;
                        }
                        pessoaFisica.name = varName;
                        pessoaFisica.address = addr;
                        Console.Write("Write your SSN: ");
                        pessoaFisica.SSN = Console.ReadLine();
                        Console.Write("Inform your ID: ");
                        pessoaFisica.ID = Console.ReadLine();
                        
                        validPrice:

                        Console.Write("Total purchase price: ");
                        float.TryParse(Console.ReadLine(), out finalPrice);
                        if(finalPrice <= 0){

                                Console.WriteLine("Invalid price informed, please try again.");
                                goto validPrice;
                        }
                        

                        pessoaFisica.payTaxes(finalPrice);

                        PFlist.Add(pessoaFisica);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.White;   
                        loading("Processing");
                        Console.Clear();
                        Console.WriteLine(@$"
____________________________________________________________________________
|                    Custommer registered sucessfully!                     |
|__________________________________________________________________________|
|                                                                          |");
                        Console.WriteLine(""); 
                        Console.WriteLine("Name............: " + pessoaFisica.name);
                        Console.WriteLine("Birth day.......: " + pessoaFisica.birthDate);
                        Console.WriteLine($"Address.........: {0} {1} St., ZIP code: {2}", addr.num, addr.street, addr.ZIP);
                        Console.WriteLine("SSN.............: " + pessoaFisica.SSN);
                        Console.WriteLine("ID..............: " + pessoaFisica.ID);
                        Console.WriteLine("Purchase price..: " + pessoaFisica.price.ToString("C"));
                        Console.WriteLine("Taxes...........: " + pessoaFisica.taxes.ToString("C"));
                        Console.WriteLine("Price with taxes: " + pessoaFisica.total.ToString("C"));
                        Console.WriteLine("");
                         Console.Write("Press any key to go back to Main-Menu");
                         Console.ReadKey();
                    
                }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.White;   
            loading("Initializing Main-Menu");
                goto Start;
        }
    }
}