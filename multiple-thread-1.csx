#! "netcoreapp2.0"

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

async Task Foo(int num) {
    Console.WriteLine("Thread {0} - Start {1}", Thread.CurrentThread.ManagedThreadId, num);

    await Task.Delay(1000);

    Console.WriteLine("Thread {0} - End {1}", Thread.CurrentThread.ManagedThreadId, num);
}

var TaskList = new List<Task>();

for (int i = 0; i < 3; i++)
{
    int idx = i;
    TaskList.Add(Task.Run(() => Foo(idx)));
}

Task.WaitAll(TaskList.ToArray());
