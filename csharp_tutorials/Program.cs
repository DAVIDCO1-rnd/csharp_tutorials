using System;
using System.Threading;

public class Example
{
    public static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            // have to wait or threadpool never gives out threads to requests
            //Thread.Sleep(50);
            // queue thread request
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), i);
        }
        // have to wait here or the background threads in the thread
        // pool would not run before the main thread exits.
        Console.WriteLine("Main Thread waiting to complete...");
        bool working = true;
        int workerThreads = 0;
        int completionPortThreads = 0;
        int maxWorkerThreads = 0;
        int maxCompletionPortThreads = 0;
        // get max threads in the pool
        ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxCompletionPortThreads);
        while (working)
        {
            // get available threads
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            if (workerThreads == maxWorkerThreads)
            {
                // allow to quit
                working = false;
            }
            else
            {
                // sleep before checking again
                Thread.Sleep(500);
            }
        }
        Console.WriteLine("Main Thread completing...");
        Console.ReadLine();
    }
    static int counter;
    static void ThreadProc(Object stateInfo)
    {
        //show we did something with this thread...
        //Console.WriteLine("Thread {0} running...", stateInfo);
        Thread.Sleep(100);
        Interlocked.Increment(ref counter);
        Console.WriteLine("Counter = {0}", counter);
    }
}