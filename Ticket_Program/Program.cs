using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;

namespace Ticket_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // relative path to file
            string file = "..\\..\\..\\Data.txt";
            // container to hold lines of strings
            List<string> Datalist = new List<string>();

            int counter = 0;
            // read from file and add to List 
            // container
            foreach (string line in System.IO.File.ReadLines(file))
            {
                Datalist.Add(line);
                //Console.WriteLine(line);

                counter++;
            }

            //Console.WriteLine("There are this many lines of code in your List: " + counter);



                Console.Write("Ticket Program");
            Console.WriteLine("Select an option: ");
            Console.WriteLine("1. Create Ticket ");
            Console.WriteLine("2. See All Tickets");
            Console.WriteLine("3. Write to file");
            Console.WriteLine("4. exit");

            bool ValidResponse = true;

            while (ValidResponse)
            {
                Console.Write("Option: ");
                String response = Console.ReadLine();

                if (response != "1" || response != "2" || response != "3")
                {
                    ValidResponse = false;
                }

                // if user select 1 
                if (response == "1")
                {
                    // must get input for these headers
                    //TicketID,Summary,Status,Priority,Submitter,Assigned,Watching

                    Console.Write("Enter ticket ID: ");
                    String TicketID = Console.ReadLine();

                    Console.Write("Enter ticket summary: ");
                    String Summary = Console.ReadLine();

                    Console.Write("Enter ticket status: ");
                    String Status = Console.ReadLine();

                    Console.Write("Enter ticket priority: ");
                    String Priority = Console.ReadLine();

                    Console.Write("Enter the name of the submitter: ");
                    string Submitter = Console.ReadLine();

                    Console.Write("Who is this ticket assigned to: ");
                    String Assigned = Console.ReadLine();

                    Console.Write("Enter person watching ticket: ");
                    String Watching = Console.ReadLine();


                    String TicketInfo = TicketID + "," + Summary + ","
                        + Status + "," + Priority + ","
 +
 Submitter + "|" + Assigned + "|" +
 Watching;
                    // Add the Ticket Info String to List
                    Datalist.Add(TicketInfo);

                    ValidResponse = true;
                }
                if (response == "2")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                        // accumulators needed for GPA
                        int count = 0;
                        // read data from file
                        StreamReader sReader = new StreamReader(file);
                        while (!sReader.EndOfStream)
                        {
                            string line = sReader.ReadLine();
                            // if this is the first line, toss it, it's the headers
                            if (count++ == 0) continue;
                            // convert string to array
                            string[] dataArray = line.Split(',');

                            // for loop to access the index
                            for (int i = 0; i < dataArray.Length; i++)
                            {
                                // remove pipes
                                dataArray[i] = dataArray[i].Replace('|', ' ');

                                // if first element, don't print the comma
                                if (i == 0)
                                {
                                    Console.Write(dataArray[i]);
                                }
                                else
                                {
                                    Console.Write(", " + dataArray[i]);
                                }
                            }

                            // display array data
                            Console.WriteLine("");
                            // add to accumulators
                            count += 1;
                        }
                        /*else
                    {
                        Console.WriteLine("File does not exist");
                    }
                        */

                        sReader.Close();
                        ValidResponse = true;

                    } }
                if (response == "3") {
                    
                           StreamWriter sWriter  = new StreamWriter(file);
                    //sw.WriteLine("{0}|{1}", name, grade);
                    foreach (var line in Datalist) {
                        sWriter.WriteLine(line);
                    }

                    sWriter.Close();
                        ValidResponse = true;

                }        


            } // end of ValidResponse loop


            Console.WriteLine("End of Program");
        }
    }
}