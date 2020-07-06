using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestAsync
{
    public class AsyncClass
    {
        public async Task TestStart()
        {
            await this.TestAsync();
        }

        private async Task TestAsync()
        {
            Console.WriteLine("test");
            //Thread.Sleep(1000);

            // task1を実行する
            var task1 = this.ShowStartText();

            // task2を実行する
            var task2 = ShowTextLoop();
            task2.Start();

            // task3を実行する
            var task3 = this.ShowEndText();

            // task2の終了を待機する
            await task2;

            // task2が終了しているため、task1と同一のスレッドで処理を実行する
            Console.WriteLine($"TestAsyncメソッド：{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("test2");

            // task1,task3を終了する
            await task1;
            await task3;
        }

        private Task ShowTextLoop()
        {
            return new Task(() =>
            {
                for (var i = 0; i < 100; i++)
                {
                    Console.WriteLine($"{i}周目");
                }
                Console.WriteLine($"ShowTextLoopメソッド：{Thread.CurrentThread.ManagedThreadId}");
            });
        }

        private Task ShowStartText()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("開始");
                Console.WriteLine($"ShowStartTextメソッド：{Thread.CurrentThread.ManagedThreadId}");
            });
        }

        private Task ShowText(string text)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"{text}");
            });
        }

        private Task ShowEndText()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("終了");
                Console.WriteLine($"ShowEndTextメソッド：{Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}
