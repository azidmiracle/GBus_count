//This is an exercise problem from Google Kickstart.
//I used C# and windows form

//Problem
//There exist some cities that are built along a straight road.The cities are numbered 1, 2, 3... from left to right.

//There are N GBuses that operate along this road.For each GBus, we know the range of cities that it serves: the i-th gBus serves the cities with numbers between Ai and Bi, inclusive.

//We are interested in a particular subset of P cities. For each of those cities, we need to find out how many GBuses serve that particular city.

//Input
//The first line of the input gives the number of test cases, T.Then, T test cases follow; each case is separated from the next by one blank line. (Notice that this is unusual for Kickstart data sets.)

//In each test case:

//The first line contains one integer N: the number of GBuses.
//The second line contains 2N integers representing the ranges of cities that the buses serve, in the form A1 B1 A2 B2 A3 B3 ... AN BN. That is, the first GBus serves the cities numbered from A1 to B1 (inclusive), and so on.
//The third line contains one integer P: the number of cities we are interested in, as described above. (Note that this is not necessarily the same as the total number of cities in the problem, which is not given.)
//Finally, there are P more lines; the i-th of these contains the number Ci of a city we are interested in.
//Output
//For each test case, output one line containing Case #x: y, where x is the number of the test case (starting from 1), and y is a list of P integers, in which the i-th integer is the number of GBuses that serve city Ci.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBus_count
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            int counter = 1;//initialize the counter for the flight
            
            string line;//line in the text file to be read
            int numberofcase;//number of test cases
            int rangeOfCities;//the arrival location and destination location
            string ALLtoPrintOut = "";
            string toPrintOut;

            List<string> DatafromFile = new List<string>();//create a linkedlist for the data from textfile

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
            new System.IO.StreamReader(@"C:\Users\emely\source\repos\GoogleKickStart\GBus_count\Database\B-large-practice.in");

            while ((line = file.ReadLine()) != null)
            {
                DatafromFile.Add(line);//add to linkedlist
            }

            string[] result = DatafromFile.ToArray();//put the value into array

            numberofcase = int.Parse(result[0]);//get the first value. This is for the number of test cases, T

            //loop through the lines for T times
            for (int T = 1; T < numberofcase + 1; T++)
            {
                //get the gBuses
                rangeOfCities = int.Parse(result[counter]) * 2;//the number of GBuses times 2.

                string rangeOfCitiesValues = result[counter + 1];//The second line contains 2N integers representing the ranges of cities that the buses serve, in the form A1 B1 A2 B2 A3 B3 ... AN BN. That is, the first GBus serves the cities numbered from A1 to B1 (inclusive), and so on.

                int citsIntrstd = int.Parse(result[counter + 2]);//the number of cities we are interested in, as described above. 



                string[] rangeOfCitiesArray = new string [rangeOfCities];//create array for the range of cities

                rangeOfCitiesArray = rangeOfCitiesValues.Split(new[] { ' ' });//since it is separated by space, split the string


                //create List

                List<KeyValuePair<int, int>> cities = new List<KeyValuePair<int, int>>();

                //put those values of rangeOfCitiesArray to the cities list
                for (int x = 0; x < rangeOfCities; x += 2)
                {
                    
                    cities.Add(new KeyValuePair<int, int>(int.Parse(rangeOfCitiesArray[x]), int.Parse(rangeOfCitiesArray[x + 1])));
                }


                //loop through the interested cities. Finally, there are P more lines; the i-th of these contains the number Ci of a city we are interested in.
                string outputct = "";

                for (int y = counter + 3;y < counter + 3 + citsIntrstd; y++)
                {
                    int cntrIntrstdCt = 0;

                    //check if the value is in the tuple list
                    foreach (KeyValuePair<int, int> kvp in cities)
                    {
                        //count as one if the value is within the range of tuple
                        if (int.Parse(result[y]) >= kvp.Key && int.Parse(result[y]) <= kvp.Value)
                        {
                            cntrIntrstdCt = cntrIntrstdCt + 1;
                        }
                    }
                    //save that counter into the variable below
                    outputct = outputct + cntrIntrstdCt.ToString() + " ";
                }


                toPrintOut = ("Case #" + T + ":" + outputct + "\n");

                ALLtoPrintOut = ALLtoPrintOut + toPrintOut;

                counter = counter + 4 + citsIntrstd;//increment the counter

            }

            labelPrint.Text = ALLtoPrintOut;//display in textbox
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
