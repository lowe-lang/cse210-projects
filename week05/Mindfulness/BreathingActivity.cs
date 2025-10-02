using System;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base("Breathing Activity",
                   "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public override void Run()
        {
            Start();
            DateTime endTime = DateTime.Now.AddSeconds(_durationSeconds);

            // Simple cycle: 4 seconds in, 4 seconds out
            while (DateTime.Now < endTime)
            {
                Console.WriteLine();
                Console.Write("Breathe in... ");
                ShowCountdown(4); // show numbers for inhale
                Console.WriteLine();
                Console.Write("Breathe out... ");
                ShowCountdown(4); // show numbers for exhale
            }

            End();
        }
    }
}
