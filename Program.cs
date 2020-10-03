using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            String y, z, x, m, id, name, lastname, password, password2, savings, information, line0;
            string[] lines;  
            int n;      
            TextWriter write;
            StringBuilder output = new StringBuilder();
            List<Person> people = new List<Person>();

            y = args[0];
            if (!File.Exists(y))
            {
                output.AppendLine("Cedula,Nombres,Apellidos,Contraseña,Ahorros,Paquete");
                File.AppendAllText(y, output.ToString());
            }

            lines = File.ReadAllLines(y);
            int count = 0;
            foreach(var l in lines)
            {
                count++;
                if (count > 1)
                {
                    people.Add(Person.FromLine(l)); 
                }                       
            }
           do
            {
                n = 0;

                Console.WriteLine("-------------------------------------");
                Console.WriteLine("[1] Grabar");
                Console.WriteLine("[2] Listar");
                Console.WriteLine("[3] Buscar");
                Console.WriteLine("[4] Editar");
                Console.WriteLine("[5] Eliminar");
                Console.WriteLine("[6] Salir");
                Console.WriteLine("-------------------------------------");
                z = Console.ReadLine();  

                switch(z)
                {
                    case "1":
                    Menu:
                        do
                        {
                            Console.Write("Cedula: ");
                            id = Program.OnlyNumbers();

                            if(Program.Into(id, people))
                            {
                                Console.WriteLine("Esta cedula esta en uso");
                                goto Menu;
                            }

                            Console.Write("Nombres: ");
                            name = Program.AllText();
                            Console.Write("Apellidos: ");
                            lastname = Program.AllText();
                            do
                            {                              
                                Console.Write("Contraseña: ");
                                password = Program.Password();
                                Console.Write("Confirmar contraseña: ");
                                password2 = Program.Password();

                                if(password2 != password)
                                {
                                    Console.WriteLine("Las contraseñas no coinciden");
                                }

                            }while(password2 != password);
                            Console.Write("Ahorros: ");
                            savings = Program.DecimalNumbers();
                            information = Convert.ToString(Program.Input_Data());

                            Console.WriteLine("Grabar(G), Reintentar(R), Salir(S)?");
                            x = Console.ReadLine().ToLower();
                            
                            switch (x)
                            {
                                case "g":
                                    line0 = id + "," + name + "," + lastname + "," + password + "," + savings + "," + information; 
                                    people.Add(Person.FromLine(line0));                                     
                                break;
                                case "r":
                                break;
                                case "s": 
                                break;                   
                                default: 
                                    Console.WriteLine("La opción seleccionada no esta disponible");
                                break;
                            }                            
                        } while (x != "s");                                                
                    break;

                    case "2":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Cedula,Nombres,Apellidos,Contraseña,Ahorros,Informacion");
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (Person p in people)
                        {
                            Console.WriteLine($"{p}");               
                        }
                    break;
                    case "3":
                        Console.Write("Introduzca la cedula del registro a buscar: ");
                        id = Program.OnlyNumbers();

                        if(Program.Into(id, people))
                        {
                            foreach (Person p in people)
                            {
                                if(p.id == id)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Cedula,Nombres,Apellidos,Contraseña,Ahorros,Informacion");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"{p}");
                                    break;
                                }  
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("El dato ingresado no esta registrado");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    break;                        
                    case "4":
                        Console.Write("Introduzca la cedula del registro a modificar: ");
                        m = Program.OnlyNumbers();

                        if(Program.Into(m, people))
                        {
                            foreach (Person p in people)
                            {
                                if(p.id == m)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Cedula,Nombres,Apellidos,Contraseña,Ahorros,Informacion");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"{p}");

                                    Menu1:                                    
                                    Console.Write("Nueva cedula: ");
                                    id = Program.OnlyNumbers();

                                    if(Program.Into(id, people) && id != m)
                                    {
                                        Console.WriteLine("Esta cedula esta en uso");
                                        goto Menu1;
                                    }

                                    Console.Write("Nuevos nombres: ");
                                    name = Program.AllText();
                                    Console.Write("Nuevos apellidos: ");
                                    lastname = Program.AllText();
                                    do
                                    {                              
                                        Console.Write("Nueva contraseña: ");
                                        password = Program.Password();
                                        Console.Write("Confirmar contraseña: ");
                                        password2 = Program.Password();

                                        if(password2 != password)
                                        {
                                            Console.WriteLine("Las contraseñas no coinciden");
                                        }

                                    }while(password2 != password);
                                    Console.Write("Nuevos Ahorros: ");
                                    savings = Program.DecimalNumbers();
                                    information = Convert.ToString(Program.Input_Data());

                                    line0 = id + "," + name + "," + lastname + "," + password + "," + savings + "," + information;
                                    people[n] = Person.FromLine(line0);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Registro se edito correctamente");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }
                                n++;  
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("El dato ingresado no esta registrado");
                            Console.ForegroundColor = ConsoleColor.White;
                        }                   
                    break;
                    case "5":
                        Console.Write("Introduzca la cedula del registro a eliminar: ");
                        id = Program.OnlyNumbers();

                        if(Program.Into(id, people))
                        {
                            foreach (Person p in people)
                            {
                                if(p.id == id)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Cedula,Nombres,Apellidos,Contraseña,Ahorros,Informacion");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"{p}");
                                    Console.Write("Confirmar eliminacion [S/N]: ");
                                    m = Console.ReadLine().ToLower();

                                    switch(m)
                                    {
                                        case "s":
                                            people.Remove(p);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Registro eliminado correctamente");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        break;
                                        case "n":
                                        break;
                                        default:
                                            Console.WriteLine("La opcion seleccionada no esta disponible");
                                        break;
                                    }
                                    break;
                                }  
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("El dato ingresado no esta registrado");
                            Console.ForegroundColor = ConsoleColor.White;
                        }                        
                    break;

                    case "6":
                    break;

                    default:
                        Console.WriteLine("La opción seleccionada no esta disponible");
                    break;
                }  

            } while (z != "6"); 

            write = new StreamWriter(y);
            write.WriteLine("Cedula,Nombres,Apellidos,Contraseña,Ahorros,Paquete");
            foreach (Person p in people)
            {
                write.WriteLine(Person.Return(p));                                
            }
            write.Close();
        }
        static string AllText()
        {
            char x;
            String y = "";

            do
            {
                x = Console.ReadKey(true).KeyChar;

                if(x == Convert.ToChar(ConsoleKey.Enter)) 
                {
                    if(y != "")
                    {
                        Console.WriteLine(x);
                    }                    
                }  
                else if (x ==Convert.ToChar(ConsoleKey.Backspace)) 
                {
                    if(y != "")
                    {
                        Console.CursorLeft = Console.CursorLeft - 1;
                        Console.Write(' ');
                        Console.CursorLeft = Console.CursorLeft - 1;                        
                        y = y.Remove(y.Length - 1);                
                    }
                }  
                else
                {
                    Console.Write(x);
                    y = (y + Convert.ToString(x));                            
                }        
            } while ((x != Convert.ToChar(ConsoleKey.Enter)) || (y == ""));
            return y;
        }
        static String OnlyNumbers()
        {
            char x;
            string y = "";

            do
            {
                x = Console.ReadKey(true).KeyChar;

                if(x == Convert.ToChar(ConsoleKey.Enter) && y != "") 
                {
                    Console.WriteLine(x);
                }  
                else if (x ==Convert.ToChar(ConsoleKey.Backspace)) 
                {
                    if(y != "")
                    {
                        Console.CursorLeft = Console.CursorLeft - 1;
                        Console.Write(' ');
                        Console.CursorLeft = Console.CursorLeft - 1;
                        y = y.Remove(y.Length - 1);                                       
                    }
                }  
                else
                {
                    if(x == '0' || x == '1' || x == '2' || x == '3' || x == '4' || x == '5' || x == '6' || x == '7' || x == '8' || x == '9')
                    {
                        Console.Write(x);
                        y = (y + Convert.ToString(x));                              
                    }      
                }        
            } while (x != Convert.ToChar(ConsoleKey.Enter) || y == "");
            return y;
        }
        static string Password()
        {
            char x;
            string y = "";

            do
            {
                x = Console.ReadKey(true).KeyChar;

                if(x == Convert.ToChar(ConsoleKey.Enter)) 
                {
                    if(y != "")
                    {
                        Console.WriteLine(x);
                    }                    
                }  
                else if (x ==Convert.ToChar(ConsoleKey.Backspace)) 
                {
                    if(y != "")
                    {
                        Console.CursorLeft = Console.CursorLeft - 1;
                        Console.Write(' ');
                        Console.CursorLeft = Console.CursorLeft - 1;
                        y = y.Remove(y.Length - 1);                
                    }
                }  
                else
                {
                    Console.Write('*');
                    y = (y + Convert.ToString(x));                                
                }        
            } while (x != Convert.ToChar(ConsoleKey.Enter) || y == "");
            return y;
        }
        static String DecimalNumbers()
        {
            char x;            
            string y = "";

            do
            {
                x = Console.ReadKey(true).KeyChar;

                if(x == Convert.ToChar(ConsoleKey.Enter) && y != "") 
                {
                    Console.WriteLine(x);
                }
                else if (x ==Convert.ToChar(ConsoleKey.Backspace)) 
                {
                    if(y != "")
                    {
                        Console.CursorLeft = Console.CursorLeft - 1;
                        Console.Write(' ');
                        Console.CursorLeft = Console.CursorLeft - 1;
                        y = y.Remove(y.Length - 1);                
                    }
                }  
                else
                {
                    if(x == '0' || x == '1' || x == '2' || x == '3' || x == '4' || x == '5' || x == '6' || x == '7' || x == '8' || x == '9' || (x == '.' && (y.Contains(".") == false && y != "")))
                    {
                        Console.Write(x);
                        y = (y + Convert.ToString(x));                              
                    }      
                }        
            } while (x != Convert.ToChar(ConsoleKey.Enter) || y == "");
            return y;
        }
        static int Input_Data()
        {
            int a = 0, c;
            char b;

            do
            {
                Console.Write("Introduzca su sexo [M/F]: ");
                b = Convert.ToChar(Console.ReadLine().ToLower());

                switch(b)
                {
                    case 'm':
                    break;
                    case 'f':
                        a = a | 8;
                    break;
                    default:
                        Console.WriteLine("La opcion seleccionada no esta disponible");
                    break;
                }                    
            } while (b != 'm' && b != 'f');

            do
            {
                Console.Write("Introduzca su estado civil [S/C]: ");
                b = Convert.ToChar(Console.ReadLine().ToLower());

                switch(b)
                {
                    case 's':
                    break;
                    case 'c':
                        a = a | 4;
                    break;
                    default:
                        Console.WriteLine("La opcion seleccionada no esta disponible");
                    break;
                }                    
            } while (b != 's' && b != 'c');

            do
            {
                Console.Write("Introduzca su grado academico actual [I/M/G/P]: ");
                b = Convert.ToChar(Console.ReadLine().ToLower());

                switch(b)
                {
                    case 'i':
                    break;
                    case 'm':
                        a = a | 1;
                    break;
                    case 'g':
                        a = a | 2;
                    break;
                    case 'p':
                        a = a | 3;
                    break;
                    default:
                        Console.WriteLine("La opcion seleccionada no esta disponible");
                    break;
                }                    
            } while (b != 'm' && b != 'i' && b != 'g' && b != 'p');

            do
            {
                Console.Write("Introduzca su edad: ");
                c = Convert.ToInt32(Program.OnlyNumbers());
            } while (c > 120);

            c = c << 4;
            a = a | c;
            return a;
        }
        static bool Into(string id, List<Person> people)
        {
            foreach (Person p in people)
            {
                if(p.id == id)
                {
                    return true;
                }                            
            } 
            return false;         
        }
    }
}