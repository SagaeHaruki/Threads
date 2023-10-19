using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics; // Use this to Debug if the program didn't try to print in the console

namespace Threads
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyThreadClass threads = new MyThreadClass();
            Console.WriteLine("- Thread Starts - ");

            Thread threadA = new Thread(threads.Thread1);
            threadA.Name = "Thread A";
            Thread threadB = new Thread(threads.Thread1);
            threadB.Name = "Thread B";
            Thread threadC = new Thread(threads.Thread1);
            threadC.Name = "Thread C";

            threadA.Start();
            Thread.Sleep(100);
            threadB.Start();
            Thread.Sleep(100);
            threadC.Start();
            threadA.Join();
            threadB.Join();
            threadC.Join();
            

            Console.WriteLine("- Thread Ends -");
        }
    }

    class MyThreadClass
    {
        public void Thread1()
        {
            for (int x = 0; x < 6; x++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name + " Process = " + x);
                Thread.Sleep(1500);
            }
        }
    }
}
