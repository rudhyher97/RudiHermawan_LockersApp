using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokerTest
{
    public class Menu
    {
        public string LoginTest = string.Empty;
        private static List<Loker> listData = new List<Loker>();
        public string Judul;
        public Menu()
        {
            
            Loker lockers = new Loker();

            Judul = "===== SYSTEM LOKER ONLINE =====";
            lockers.OnlyNumber = "Please Input Number Only";
        }
        public bool login(string username, string password)
        {
            bool isvalid = true;
            if (username == "admin" && password == "admin")
            {
                isvalid = true;
             }
            else
            {
                              
                isvalid = false;
            }
            return isvalid;
        }
        public bool InputIntMode(string val, int index)
        {
            Loker lockers = new Loker();
            lockers.InputInt = true;
            lockers.InputInt = int.TryParse(val,out index);
            if (!lockers.InputInt)
            {
                lockers.InputInt = false;
               
            }
            return lockers.InputInt;
        }

        public static void backMenu()
        {
            Loker obj = new Loker();
            Menu menu = new Menu();
            string Inputval = string.Empty;
            int paramsMenu = 0;
            back:
            Console.WriteLine("\n 0. Back To Menu");
            Console.Write("Enter Chooise : ");
            Inputval = Console.ReadLine();
            bool Mode = menu.InputIntMode(Inputval, paramsMenu);
            if(!Mode)
            {
                Console.WriteLine(obj.OnlyNumber);
                backMenu();
                return;
            }            
            paramsMenu = Convert.ToInt32(Inputval);

            if (paramsMenu == 0)
            {
                Console.Clear();

                MainMenu();
            }
            else
            {
                Console.WriteLine("incorect input menu!!");
                goto back;
            }
        }
        public static void MainMenu()
        {
            Loker obj = new Loker();
            Menu objMenu = new Menu();
            Console.WriteLine(objMenu.Judul);
            Console.WriteLine("");
            Console.WriteLine("");
            int menu = 0;
            string stringMenu=string.Empty;
            Console.WriteLine("|| 1. Create Loker   ||");
            Console.WriteLine("|| 2. Status Loker   ||");
            Console.WriteLine("|| 3. Input Loker    ||");
            Console.WriteLine("|| 4. Leave Loker    ||");
            Console.WriteLine("|| 5. Search Loker   ||");
            Console.WriteLine("|| 6. Exit           ||\n");

            Console.Write("Enter Chooise : ");
            stringMenu = Console.ReadLine();
          
            bool Mode = objMenu.InputIntMode(stringMenu, menu);
            if (!Mode)
            {
                Console.WriteLine(obj.OnlyNumber);
                backMenu();
                return;
            }
            menu = Convert.ToInt32(stringMenu);
            logicProgram(menu);
            

        }


        private static void logicProgram(int paramsMenu)
        {

            Loker obj = new Loker();
            Menu objMenu = new Menu();
            
            bool Mode;
            string InputString = string.Empty;
            int InputInt32 = 0;
            string InsertString = string.Empty;

            switch (paramsMenu)
            {

                case 1:
                    if(listData.Count >0)
                    {
                        Console.WriteLine("Locker already created..!");
                        backMenu();
                        return;
                    }

                    Console.Clear();
                    Console.WriteLine("==== Input Locker ====");
                    Console.WriteLine("\n");
                                      
                    Console.Write("Input Numbers of Lockers :");
                    InputString = Console.ReadLine();
                    
                    Mode = objMenu.InputIntMode(InputString, InputInt32);
                    if (!Mode)
                    {
                        Console.WriteLine(obj.OnlyNumber);
                        backMenu();
                        return;
                    }
                        InputInt32 = Convert.ToInt32(InputString);
                        listData = new List<Loker>();
                        for (int i = 0; i < InputInt32; i++)
                        {
                            listData.Add(new Loker() { NamaLoker = string.Empty, NomorLoker = string.Empty, FLAG = 0 });
                        }
                        Console.WriteLine("Create Locker Successfuly with " + InputString + " Lockers");
                        backMenu();
                    
                    
                    break;
                case 2:

                    if (listData.Count() < 1 || listData == null)
                    {
                        Console.Clear();
                        Console.WriteLine("==== Status Loker ====");
                        Console.WriteLine("\n");
                        Console.WriteLine("No Data Found");
                        backMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("==== Status Locker ====");
                        Console.WriteLine("\n");
                        int No = 1;
                        Console.WriteLine("No Locker    || Type Identitas || Available || No Identitas");
                        foreach (Loker item in listData)
                        {
                            Console.WriteLine(No + "           || " + item.NamaLoker + "               || " + (item.FLAG == 0 ? "Y" : "N") + "         || " + item.NomorLoker);
                            No++;
                        }

                        backMenu();
                    }
                    break;
                case 3:
                    
                    if (listData.Count() < 1 || listData == null)
                    {
                        Console.Clear();
                        Console.WriteLine("==== Input Loker  ====");
                        Console.WriteLine("\n");
                        Console.WriteLine("Loker must be Created");
                        backMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("==== Input Loker  ====");
                        Console.WriteLine("\n");
                    input:
                        Console.WriteLine("Input Locker Type: 1.KTP / 2.SIM");
                        InputString = Console.ReadLine();     
                        Mode = objMenu.InputIntMode(InputString, InputInt32);
                        if (!Mode)
                        {
                            Console.WriteLine(obj.OnlyNumber);
                            backMenu();
                            return;
                        }
                        InputInt32 = Convert.ToInt32(InputString);
                        if (InputInt32 == 1 || InputInt32 == 2)
                        {
                            InsertString = (InputInt32 == 1 ? "KTP" : "SIM");
                        }
                        else
                        {
                            Console.WriteLine("please input 1 or 2");
                            goto input;
                        }
                        Console.WriteLine("Input Loker Number : ");
                        InputString = Console.ReadLine();
                        Mode = objMenu.InputIntMode(InputString, InputInt32);
                        if (!Mode)
                        {
                            Console.WriteLine(obj.OnlyNumber);
                            backMenu();
                            return;
                        }
                        InputInt32 = Convert.ToInt32(InputString);
                        List<string> EmtyTbl = new List<string>();
                       
                        foreach (Loker items in listData)
                        {
                            string namaLoker = items.NamaLoker;
                            if (items.NamaLoker == string.Empty && items.NomorLoker == string.Empty)
                            {
                                items.NamaLoker = InsertString;
                                items.NomorLoker = InputInt32.ToString();
                                items.FLAG = 1;
                                break;
                            }
                            else if (items.NamaLoker != string.Empty && items.NomorLoker != string.Empty)
                            {
                                EmtyTbl.Add(items.NamaLoker);

                            }

                        }
                        if (listData.Count() == EmtyTbl.Count())
                        {
                            Console.WriteLine("Sory Loker is succesfuly!");
                        }

                        backMenu();
                    }
                    break;
                case 4:

                    if (listData.Count() < 1 || listData == null)
                    {
                        Console.Clear();
                        Console.WriteLine("==== Leaved Loker ====");
                        Console.WriteLine("\n");
                        Console.WriteLine("No Data Found");
                        backMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("==== Leave Loker ====");
                        Console.WriteLine("\n");
                        int No = 1;
                        Console.WriteLine("No Locker    || Type Identitas || Available || No Identitas");
                        foreach (Loker item in listData)
                        {
                            Console.WriteLine(No + "           || " + item.NamaLoker + "               || " + (item.FLAG == 0 ? "Y" : "N") + "         || " + item.NomorLoker);
                            No++;
                        }
                    leave:
                        Console.Write("Choose No Locker : ");
                        InputString = Console.ReadLine();
                        Mode =objMenu.InputIntMode(InputString, InputInt32);
                        if (!Mode)
                        {
                            Console.WriteLine(obj.OnlyNumber);
                            backMenu();
                            return;
                        }
                        InputInt32 = Convert.ToInt32(InputString);
                        No = 1;
                        try
                        {
                            listData[(InputInt32 - 1)] = new Loker() { NamaLoker = string.Empty, NomorLoker = string.Empty, FLAG = 0 };
                            Console.WriteLine("Leave Locker Successfully");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("No Locker incorrect!");
                            goto leave;
                        }
                        backMenu();
                    }
                    break;
                case 5:

                    if (listData.Count() < 1 || listData == null)
                    {
                        Console.Clear();
                        Console.WriteLine("==== Search Locker ====");
                        Console.WriteLine("\n");
                        Console.WriteLine("No Data Found");
                        backMenu();
                    }
                    else
                    {
                        List<Loker> findList = new List<Loker>();
                        //string typeLoker = string.Empty;
                        Console.Clear();
                        Console.WriteLine("==== Search Locker ====");
                        Console.WriteLine("\n");
                        int No = 1;
                        Console.WriteLine("No Locker    || Type Identitas || Available || No Identitas");
                        foreach (Loker item in listData)
                        {

                            Console.WriteLine(No + "           || " + item.NamaLoker + "               || " + (item.FLAG == 0 ? "Y" : "N") + "         || " + item.NomorLoker);
                            No++;
                        }

                        Console.WriteLine("Search Data Locker : ");
                        InsertString = Console.ReadLine();

                        Console.Clear();
                        No = 1;
                        Console.WriteLine("No Locker    || Type Identitas || Available || No Identitas");
                        //Console.WriteLine(listData.Exists(x => x.NamaLoker == typeLoker));

                        findList = listData.Where(c => c.NamaLoker == (InputString == string.Empty?"-": InputString) || c.NomorLoker == (InputString == string.Empty ? "-" : InputString)).ToList();
                        foreach (Loker item in findList)
                        {

                            Console.WriteLine(No + "           || " + item.NamaLoker + "               || " + (item.FLAG == 0 ? "Y" : "N") + "         || " + item.NomorLoker);
                            No++;
                        }
                        if (findList.Count() == 0 || findList.Count==null)
                        {
                            Console.WriteLine("No Data Found!");
                        }
                        backMenu();
                    }
                    break;
                case 6:

                    Console.Clear();
                    Console.WriteLine("press any key to Exit");
                    
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please input menu between 1-6");
                    Console.WriteLine("==============================");
                    Console.WriteLine("");
                    MainMenu();
                    break;

            }

        }
    }
}

