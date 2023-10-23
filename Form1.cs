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
            Thread threadC = new Thread(threads.Thread2);
            threadC.Name = "Thread C";
            Thread threadD = new Thread(threads.Thread2);
            threadD.Name = "Thread D";

            threadA.Priority = ThreadPriority.Highest;
            threadB.Priority = ThreadPriority.Normal;
            threadC.Priority = ThreadPriority.AboveNormal;
            threadD.Priority = ThreadPriority.BelowNormal;

            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();
            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            Console.WriteLine("- Thread Ends -");
        }
    }

    class MyThreadClass
    {
        public void Thread1()
        {
            for (int x = 0; x < 3; x++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name + " Process = " + x);
                Thread.Sleep(500);
            }
        }
        public void Thread2()
        {
            for (int x = 1; x < 6; x++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name + " Process = " + x);
                Thread.Sleep(1500);
            }
        }
    }
}
