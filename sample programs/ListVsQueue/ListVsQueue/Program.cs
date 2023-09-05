using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ListVsQueue
{
    public class Tasks
    {
        //creating filestream
        public static StreamWriter fileStream;

        public Tasks(StreamWriter streamWriter)
        {
            //getting path while creating instance
            fileStream = streamWriter;
        }
        //task method for list,queue,priority queue
        public void TaskMethod(int generatedRandomNumber)
        {
            //creating list for task class
            List<Task> tasks = new List<Task>();

            //for  list method
            Task listTask = Task.Run(() =>
            {
                //list  is fill with random numbers
                ListMethod(generatedRandomNumber);
            });
            //listmethod is added in task
            tasks.Add(listTask);

            //for  Queue method

            Task queueTask = Task.Run(() =>
            {
                //Queue  is fill with random numbers

                QueueMethod(generatedRandomNumber);
            });
            //Queuemethod is added in task

            tasks.Add(queueTask);

            //for  PriorityQueue method

            Task priorityQueueTask = Task.Run(() =>
            {
                //PriorityQueue  is filled with random numbers

                PriorityQueueMethod(generatedRandomNumber);
            });
            //PriorityQueueMethod is added in task

            tasks.Add(priorityQueueTask);

            //wait until all the task to be completed 
            Task.WaitAll(tasks.ToArray());
        }
        //this method is calculating how much time needed for random numbers added in list
        public void ListMethod(int generatedRandomNumber)
        {
            DateTime startTime;
            DateTime stopTime;

            List<int> myList = new List<int>();

            startTime = DateTime.Now;
            //printing in both console and text file
            WriteLine("List Start Time is " + startTime);

            var listTime = Stopwatch.StartNew();

            for (int i = 0; i < 1000000000; i++)
            {
                myList.Add(generatedRandomNumber);
            }
            listTime.Stop();

            stopTime = DateTime.Now;
            //printing in both console and text file
            WriteLine("List Stop Time is " + stopTime);
            WriteLine("List Executime is " + listTime.ElapsedMilliseconds + "ms ");
        }
        //this method is calculating how much time needed for random numbers added in queue

        public void QueueMethod(int generatedRandomNumber)
        {
            DateTime startTime;
            DateTime stopTime;

            Queue<int> myQueue = new Queue<int>();

            startTime = DateTime.Now;
            WriteLine("Queue Start Time is " + startTime);

            var queueTime = Stopwatch.StartNew();

            for (int i = 0; i < 1000000000; i++)
            {
                myQueue.Enqueue(generatedRandomNumber);
            }
            queueTime.Stop();

            stopTime = DateTime.Now;

            WriteLine("Queue Stop Time is " + stopTime);
            WriteLine("Queue Executime is " + queueTime.ElapsedMilliseconds + "ms ");
        }
        //this method is calculating how much time needed for random numbers added in list Priority Queue

        public void PriorityQueueMethod(int generatedRandomNumber)
        {
            DateTime startTime;
            DateTime stopTime;

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            startTime = DateTime.Now;
            WriteLine("PriorityQueue Start Time is " + startTime);

            var priorityQueueTime = Stopwatch.StartNew();

            for (int i = 0; i < 1000000000; i++)
            {
                pq.Enqueue(generatedRandomNumber, generatedRandomNumber);
            }
            priorityQueueTime.Stop();

            stopTime = DateTime.Now;

            WriteLine("PriorityQueue Stop Time is " + stopTime);
            WriteLine("PriorityQueue Executime is " + priorityQueueTime.ElapsedMilliseconds + "ms ");
        }

        public static void WriteLine(string text)
        {
            //for printing in both console and text file
            Console.WriteLine(text);
            fileStream.WriteLine(text);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //generating random number
            Random random = new Random();
            int generatedRandomNumber = random.Next(1000000, 2000000);
            Console.WriteLine("The Generated Random number is " + generatedRandomNumber);

            //giving path to the constructor
            using (StreamWriter fileStream = new StreamWriter("E:\\Data\\C#\\sample programs\\ListVsQueue\\ListVsQueue\\Output.txt"))
            {
                Tasks taskClass = new Tasks(fileStream);

                //calling the task method
                taskClass.TaskMethod(generatedRandomNumber);
            }
        }
    }
}
