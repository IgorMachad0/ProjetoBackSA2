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
            int customerType = 1;
            string menu;
            DirectoryInfo path = new DirectoryInfo(Directory.GetCurrentDirectory());
            
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

                menu = Console.ReadLine();
                switch (menu){

                    case "1":
                    
                    customerType = 1;
                    
                    break;

                    case "2":

                    Console.Clear();
                    Console.WriteLine(@$"
____________________________________________________________________________
|                                                                          |
|                            Custommers list                               |
|__________________________________________________________________________|

");
                    var txtFiles = path.EnumerateFiles("PF*.txt");
                    if(!txtFiles.Any()){
                    Console.WriteLine("There are no registers yet.");
                    
                    }else{
                    foreach (var currentFile in txtFiles){
                        
                        using(StreamReader sr = new StreamReader($"{currentFile}")){
                            string line;
                            while((line = sr.ReadLine()) != null){
                                Console.WriteLine($"{line}");

                            }

                        }

                    }
                    Console.Write(@$"
****************************************************************************
");
                    }
                    Console.Write("(Press any key to return to Main-Menu.)");
                    Console.ReadKey();
                    Console.Clear();
                    goto Start;


                    case "3":

                    customerType = 2;

                    break;

                    case "4":

                    Console.Clear();                    
                    Console.WriteLine(@$"
____________________________________________________________________________
|                                                                          |
|                        Bussiness custommers list                         |
|__________________________________________________________________________|
");
                    var PJtxtFiles = path.EnumerateFiles("PJ*.txt");

                    if(!PJtxtFiles.Any()){
                    Console.WriteLine("There are no registers yet.");
                    
                    }else{
                    foreach (var currentFile in PJtxtFiles){
                        
                        using(StreamReader sr = new StreamReader($"{currentFile}")){
                            string line;
                            while((line = sr.ReadLine()) != null){
                                Console.WriteLine($"{line}");

                            }

                        }

                    }
                    Console.Write(@$"
****************************************************************************
");
                    }
                    Console.Write("(Press any key to return to Main-Menu.)");
                    Console.ReadKey();
                    Console.Clear();
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
                Address addr = new Address();
                {
                    addr.street = varStreet;
                    addr.num = varNumAdress;
                    addr.ZIP = varZIPCode;

                }

                if(customerType == 1)
                {
                    PF pessoaFisica = new PF();
                    {
                        
                        Console.Write("Enter your birth day(MM/DD/YYYY): ");
                        pessoaFisica.birthDate = DateTime.Parse(Console.ReadLine());
                        if(!pessoaFisica.validBirthday(pessoaFisica.birthDate)){
                            Console.WriteLine("Customer register failed: underage restriction.");
                            goto Start;
                        }
                        pessoaFisica.exposiblebDate = pessoaFisica.birthDate.ToString();
                        pessoaFisica.exposiblebDate = pessoaFisica.exposiblebDate.Substring(0, 10);
                        pessoaFisica.name = varName;
                        pessoaFisica.address = addr;
                        pessoaFisica.address.bussinessAddress = false;
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

                    using (StreamWriter bananas = new StreamWriter($"PF{pessoaFisica.SSN}.txt"))
                    {bananas.WriteLine(@$"

****************************************************************************
Name............: " + pessoaFisica.name);
                    bananas.WriteLine($"Address.........: {pessoaFisica.address.num} {pessoaFisica.address.street} St. ZIP code: {pessoaFisica.address.ZIP}");
                    bananas.WriteLine("Birth day.......: " + pessoaFisica.exposiblebDate);
                    bananas.WriteLine("EIN.............: " + pessoaFisica.SSN);
                    bananas.WriteLine("CIK.............: " + pessoaFisica.ID);

                    }

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
                        Console.WriteLine("Birth day.......: " + pessoaFisica.exposiblebDate);
                        Console.WriteLine($"Address.........: {pessoaFisica.address.num} {pessoaFisica.address.street} St., ZIP code: {pessoaFisica.address.ZIP}");
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
            loading("Initializing Main-Menu");
                goto Start;

                }
                    PJ pessoaJuridica = new PJ();
                    {
                        pessoaJuridica.name = varName;
                        pessoaJuridica.address = addr;
                        pessoaJuridica.address.bussinessAddress = true;
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

                    }

                    using (StreamWriter bananas = new StreamWriter($"PJ{pessoaJuridica.EIN}.txt"))
                    {bananas.WriteLine(@$"

****************************************************************************
Name............: " + pessoaJuridica.name);
                    bananas.WriteLine($"Address.........: {pessoaJuridica.address.num} {pessoaJuridica.address.street} St. ZIP code: {pessoaJuridica.address.ZIP}");
                    bananas.WriteLine("EIN.............: " + pessoaJuridica.EIN);
                    bananas.WriteLine("CIK.............: " + pessoaJuridica.CIK);

                    }

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.BackgroundColor = ConsoleColor.White;   
                    loading("Processing");
                    Console.Clear();
                    Console.WriteLine(@$"
____________________________________________________________________________
|                    Custommer registered sucessfully!                     |
|__________________________________________________________________________|
");
                        Console.WriteLine("Name............: " + pessoaJuridica.name);
                        Console.WriteLine($"Address.........:  {pessoaJuridica.address.num} {pessoaJuridica.address.street} St. ZIP code: {pessoaJuridica.address.ZIP}");
                        Console.WriteLine("EIN.............: " + pessoaJuridica.EIN);
                        Console.WriteLine("CIK.............: " + pessoaJuridica.CIK);
                        Console.WriteLine("Purchase Price..: " + pessoaJuridica.price.ToString("C"));
                        Console.WriteLine("Taxes...........: " + pessoaJuridica.taxes.ToString("C"));
                        Console.WriteLine("Price with taxes: " + pessoaJuridica.total.ToString("C"));
                         
                         Console.WriteLine();
                         Console.Write("Press any key to go back to Main-Menu");
                         Console.ReadKey();                        
                         Console.ForegroundColor = ConsoleColor.DarkGray;
                         loading("Initializing Main-Menu");
                         goto Start;

        }
    }
}