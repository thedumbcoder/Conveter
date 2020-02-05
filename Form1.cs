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
          List<IndexItem> indexitems = new List<IndexItem>();
          public Form1()
          {
               InitializeComponent();
               button2.Enabled = false;
               button3.Enabled = false;

          }

          string currentdatebhav = string.Empty;
          string currentdateindex = string.Empty;



          void converttotxt()
          {
               var tlistFiltered = items.Where(item => item.SERIES == "EQ").ToList();

               string advance = "_ADVANCE," + currentdatebhav + ",630,630,630,630,0,0";
               string decline = "_DECLINE," + currentdatebhav + ",630,630,630,630,0,0";
               string unchanged = "_UNCHANGED," + currentdatebhav + ",630,630,630,630,0,0";

               List<string> values = new List<string>();

               values.Add(advance);
               values.Add(decline);
               values.Add(unchanged);
               foreach (ListItem ITEM in tlistFiltered)
               {

                    string data = ITEM.SYMBOL + "," + ITEM.TIMESTAMP + "," + ITEM.OPEN + "," + ITEM.HIGH + "," + ITEM.LOW + "," + ITEM.CLOSE + "," + ITEM.TOTTRDQTY + "," + ITEM.extrafield;
                    values.Add(data);
               }

               string filename= currentdatebhav + ".txt";
               using (TextWriter tw = new StreamWriter(filename))
               {
                    foreach (String s in values)
                         tw.WriteLine(s);
               }

               MessageBox.Show("Conversion Done");
               label2.Text = "Converted File Save at location: " + Directory.GetCurrentDirectory() + "/" + filename;

          }

          void converttotxt2()
          {


               string header = "Index Name,Index Date,Open Index Value,High Index Value,Low Index Value,Closing Index Value,Volume";
 

               List<string> values = new List<string>();

               values.Add(header);
             
               foreach (IndexItem ITEM in indexitems)
               {

                    string data = ITEM.Index_Name + "," + ITEM.Index_Date + "," + ITEM.Open_Index_Value + "," + ITEM.High_Index_Value + "," + ITEM.Low_Index_Value + "," + ITEM.Closing_Index_Value + "," + ITEM.Volume ;
                    values.Add(data);
               }

               string filename ="Index"+ currentdateindex + ".txt";
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

                  
                  int digits = Convert.ToString(monthIndex).Length;
                   

                    if (digits>1)
                    {
                        return year + monthIndex + date;
                    }
                    else
                    {
                        return year + "0" + monthIndex + date;

                    }


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

                        var x = parseDate(parser["TIMESTAMP"]);


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
                              currentdatebhav = item.TIMESTAMP;
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

          private void button3_Click(object sender, EventArgs e)
          {
               if (textBox1.Text != string.Empty)
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
                    int digits = Convert.ToString(monthIndex).Length;

                    if (digits > 1)
                    {
                        return year + monthIndex + date;
                    }
                    else
                    {
                        return year + "0" + monthIndex + date;
                    }

                   

                }

                    using (GenericParser parser = new GenericParser())
                    {
                         parser.SetDataSource(textBox1.Text);

                         parser.FirstRowHasHeader = true;
                         parser.SkipStartingDataRows = 0;
                         parser.MaxBufferSize = 4096;
                         parser.TextQualifier = '\"';

                         while (parser.Read())
                         {

                              IndexItem item = new IndexItem()
                              {
                                   Index_Name = parser["Index Name"],
                                   Index_Date = parseDate(parser["Index Date"]),
                                   Open_Index_Value = parser["Open Index Value"],
                                   High_Index_Value = parser["High Index Value"],
                                   Low_Index_Value = parser["Low Index Value"],
                                   Closing_Index_Value = parser["Closing Index Value"],
                                   Volume = parser["Volume"],
                                 
                              };
                              currentdateindex = item.Index_Date;
                              indexitems.Add(item);
                         }

                         converttotxt2();
                    }
               }

               else
               {
                    MessageBox.Show("Please select Index File");
               }
          }

          private void button4_Click(object sender, EventArgs e)
          {
               OpenFileDialog openFileDialog2 = new OpenFileDialog
               {

                    Title = "Browse Index Copy",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "csv",
                    Filter = "csv files (*.csv)|*.csv",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
               };

               if (openFileDialog2.ShowDialog() == DialogResult.OK)
               {
                    textBox1.Text = openFileDialog2.FileName;
                    button3.Enabled = true;
               }

          }

       
     }
     }

