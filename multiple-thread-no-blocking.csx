#! "netcoreapp2.0"

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

async Task Foo(int num) {
    Console.WriteLine("Thread {0} - Start {1}", Thread.CurrentThread.ManagedThreadId, num);

    var x = 0;
    var n = 10000;
    for(var i = 0; i < n; i++)
        for(var j = 0; j < n; j++)
            x += i + j*j + 73*(j+i);

    Console.WriteLine("Thread {0} - End {1}", Thread.CurrentThread.ManagedThreadId, num);
}

var TaskList = new List<Task>();

for (int i = 0; i < 3; i++)
{
    int idx = i;
    TaskList.Add(Task.Run(() => Foo(idx)));
}

Task.WaitAll(TaskList.ToArray());
