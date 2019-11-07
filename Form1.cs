using GenericParsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conveter
{
     public partial class Form1 : Form
     {
          List<ListItem> items = new List<ListItem>();
          public Form1()
          {
               InitializeComponent();
               button2.Enabled = false;

          }

          string currentdate = string.Empty;

       


          void converttotxt()
          {
               var tlistFiltered = items.Where(item => item.SERIES == "EQ").ToList();

               string advance = "_ADVANCE," + currentdate + ",630,630,630,630,0,0";
               string decline = "_DECLINE," + currentdate + ",630,630,630,630,0,0";
               string unchanged = "_UNCHANGED," + currentdate + ",630,630,630,630,0,0";

               List<string> values = new List<string>();

               values.Add(advance);
               values.Add(decline);
               values.Add(unchanged);
               foreach (ListItem ITEM in tlistFiltered)
               {

                    string data = ITEM.SYMBOL + "," + ITEM.TIMESTAMP + "," + ITEM.OPEN + "," + ITEM.HIGH + "," + ITEM.LOW + "," + ITEM.CLOSE + "," + ITEM.TOTTRDQTY + "," + ITEM.extrafield;
                    values.Add(data);
               }

               string filename = "BhavCopyAMI" + DateTime.Now.ToString("dd-mm-yyyy") + ".txt";
               using (TextWriter tw = new StreamWriter(filename))
               {
                    foreach (String s in values)
                         tw.WriteLine(s);
               }

               MessageBox.Show("Conversion Done");
               label2.Text = "Converted File Save at location: " + Directory.GetCurrentDirectory() + "/" + filename;

          }



          private void Form1_Load(object sender, EventArgs e)
          {


          

           


               }

          private void txtbhavcopy_TextChanged(object sender, EventArgs e)
          {

          }

          private void button1_Click(object sender, EventArgs e)
          {
               OpenFileDialog openFileDialog1 = new OpenFileDialog
               {
               
                    Title = "Browse Bhav Copy",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "csv",
                    Filter = "csv files (*.csv)|*.csv",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
               };

               if (openFileDialog1.ShowDialog() == DialogResult.OK)
               {
                    txtbhavcopy.Text = openFileDialog1.FileName;
                    button2.Enabled = true;
               }
           


             

          }

          private void button2_Click(object sender, EventArgs e)
          {
               if(txtbhavcopy.Text!=string.Empty)
               {
                    string parseDate(string indate)
                    {
                         DateTime date1 = Convert.ToDateTime(indate);
                         var month = date1.ToString("MMMM");
                         var year = date1.ToString("yyyy");
                         var date = date1.ToString("dd");

                         string desiredMonth = month;
                         string[] MonthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
                         int monthIndex = Array.IndexOf(MonthNames, desiredMonth) + 1;
                         return year + monthIndex + date;

                    }

                    using (GenericParser parser = new GenericParser())
                    {
                         parser.SetDataSource(txtbhavcopy.Text);

                         parser.FirstRowHasHeader = true;
                         parser.SkipStartingDataRows = 0;
                         parser.MaxBufferSize = 4096;
                         parser.TextQualifier = '\"';

                         while (parser.Read())
                         {

                              ListItem item = new ListItem()
                              {
                                   SYMBOL = parser["SYMBOL"],
                                   TIMESTAMP = parseDate(parser["TIMESTAMP"]),
                                   SERIES = parser["SERIES"],
                                   OPEN = parser["OPEN"],
                                   HIGH = parser["HIGH"],
                                   LOW = parser["LOW"],
                                   CLOSE = parser["CLOSE"],
                                   TOTTRDQTY = parser["TOTTRDQTY"],
                                   extrafield = "0"
                              };
                              currentdate = item.TIMESTAMP;
                              items.Add(item);
                         }

                         converttotxt();
                    }
               }

              else
               {
                    MessageBox.Show("Please select BhavCopy File");
               }



          }
     }
     }

