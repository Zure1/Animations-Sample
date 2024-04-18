using System.Windows.Input;
using MVVM.Sample.Commands;

namespace MVVM.Sample.ViewModels
{
    public class PerformanceViewModel
    {
        public ICommand RunIoTaskCommand { get; }
        public ICommand RunCpuTaskCommand { get; }

        public PerformanceViewModel()
        {
            RunIoTaskCommand = new AsyncCommand(RunIoTaskAsync);
            RunCpuTaskCommand = new AsyncCommand(RunCpuTaskAsync);
        }

        private async Task RunIoTaskAsync()
        {
            await Task.Delay(3000);
            Console.WriteLine("I/O Task complete.");
        }

        private async Task RunCpuTaskAsync()
        {
            // Simulating a CPU-bound task by performing complex calculations
            double result = 0;
            for (int i = 1; i <= 100000000; i++)
            {
                result += Math.Log(i);
            }
            
            // To ensure the method can be awaited and does not block the UI thread,
            // you might still want to make it async even though there's no await inside.
            // This is just to adhere to the signature.
            await Task.CompletedTask;

            // Optionally, you can output the result to see the effect
            Console.WriteLine($"Calculation result: {result}");
        }
    }
}