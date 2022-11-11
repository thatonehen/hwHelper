using System;
using System.IO;
using System.Threading;
namespace checkWorkHW
{

    class functions
    {
        public static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }
        public static int Divide(int num1, int num2)
        {
            return num1 / num2;
        }
        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }
        public static int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }
        public static int Solve(int num1, int num2, string op)
        {
            switch (op)
            {
                case "*":
                    return Multiply(num1, num2);

                case "x":
                    return Multiply(num1, num2);

                case "/":
                    return Divide(num1, num2);

                case "-":
                    return Subtract(num1, num2);

                case "+":
                    return Add(num1, num2);

                default:
                    return 0;
            }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            int thoughtAnswer;
            int num1;
            int num2;
            bool logs = true;
            int i = 0;
            bool response = false;
            bool invResponse = false;
            bool devMode = true;
            string a = "abc";
            string folderName = @"C:\Users\ThatO\source\repos\checkWorkHW\checkWorkHW\bin\Debug\net5.0";
            string pathString = Path.Combine(folderName, "Logs");
            if (!Directory.Exists(pathString))
            {
                while (!response){
                    if (!invResponse)
                    {
                        i++;
                        Console.WriteLine("Hello! This seems to be your first time entering this program. Would you like to enable dev logs?");
                        Console.WriteLine("Y/N:");
                    }
                    else
                    {
                        if(i > 15)
                        {
                            Console.WriteLine("STOP WRITING INVALID RESPONSES REEEEE");
                            Console.WriteLine("FINE. IF YOU KEEP DOING THIS, NO MORE LOGS FOR YOU.");
                            logs = false;
                            invResponse = false;
                            response = true;
                        }
                        else
                        {
                            i++;
                            Console.WriteLine(a + " is is an invalid response. Would you like to enable dev logs?");
                            Console.WriteLine("Y/N:");
                        }
                    }
                    a = Console.ReadLine();
                    if(a == "Y")
                    {
                        response = true;
                        logs = true;
                        invResponse = false;
                    }else if(a == "N"){
                        response = true;
                        logs = false;
                        invResponse = false;
                    }
                    else
                    {
                        invResponse = true;
                    }
                }
                
                Directory.CreateDirectory(pathString);
            }
            
            string date = DateTime.Now.ToString("MM-dd-yyyy_h mm ss");
            Console.WriteLine(date);
            string fileName = date + ".log";
            pathString = System.IO.Path.Combine(pathString, fileName);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PROBLEM VERIFIER V1");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("PROBLEM VERIFIER V1");
            Console.WriteLine("Enter first number: ");
            string firstNum = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter operator(x = multiplication, / = divison, - = subtraction, and + = addition)");
            string op = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter second number: ");
            string secondNum = Console.ReadLine();
            
            try
            {
                num1 = (int)Convert.ToInt64(firstNum);
                num2 = (int)Convert.ToInt64(secondNum);
                
            }
            catch (Exception e)
            {
                if (logs)
                {
                    Console.WriteLine("Error detected, saved to logs.");
                    File.WriteAllText(fileName, e.Message);
                    for (int d = 5; d > 0; d--)
                    {
                        Console.WriteLine("Closing in " + d.ToString() + " seconds.");
                        Thread.Sleep(1000);
                    }
                    Environment.Exit(0);
                }  else
                {
                    Console.WriteLine("Error detected, closing in 5 seconds.");
                    for (int g = 5; g > 0; g--)
                    {
                        Console.WriteLine("Closing in " + g.ToString() + " seconds.");
                        Thread.Sleep(1000);
                    }
                    Environment.Exit(0);
                }

            }
            if (!devMode)
            {
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Skipped waiting time due to dev mode.");
            }
            num1 = (int)Convert.ToInt64(firstNum);
            num2 = (int)Convert.ToInt64(secondNum);
            int ans = functions.Solve(num1, num2, op);
            Console.WriteLine("Enter the answer you THINK the problem is:");
            string ethoughtAnswer = Console.ReadLine();
            try
            {
                thoughtAnswer = (int)Convert.ToInt64(ethoughtAnswer);
            }
            catch (Exception e)
            {
                if (logs)
                {
                    Console.WriteLine("Error detected, saved to logs."); 
                    File.WriteAllText(fileName, e.Message);
                    Console.WriteLine("Closing in 5 seconds.");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Error detected, closing in 5 seconds.");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }

            }
            thoughtAnswer = (int)Convert.ToInt64(ethoughtAnswer);
            if (thoughtAnswer == ans)
            {
                Console.WriteLine("Correct!");
            }else if(thoughtAnswer < ans)
            {
                Console.WriteLine("Your answer was lower.");
            }
            else
            {
                Console.WriteLine("Your answer was higher.");
            }
        }
    }
}
