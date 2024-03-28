using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;

namespace gruppovyxa
{
    public class Timer
    {
        private DispatcherTimer timer;
        private int secondsLeft;

        // Событие, которое будет вызываться при каждом тике таймера
        public event Action<string> TimerTicked;

        public void InitializeTimer(int a)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1); // таймер срабатывает каждую секунду
            secondsLeft = a;
        }

        public void StartTimer()
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (secondsLeft > 0)
            {
                secondsLeft--;
                string currentTime = UpdateTimerDisplay();
                TimerTicked?.Invoke(currentTime); // Вызываем событие и передаем текущее время
            }
            else
            {
                timer.Stop();
            }
        }

        private string UpdateTimerDisplay()
        {
            TimeSpan time = TimeSpan.FromSeconds(secondsLeft);
            return time.ToString(@"mm\:ss");
        }
    }
}
