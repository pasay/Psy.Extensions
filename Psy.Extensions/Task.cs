using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace System.Threading.Tasks
{
    public static class TaskEx
    {
        private class TimerState
        {
            public volatile bool State = false;
        }

        public static void DelayV40(int milliseconds)
        {
            //Stopwatch s = new Stopwatch();
            TimerState state = new TimerState();
            try
            {
                //s.Start();
                Timer t = new Timer(new TimerCallback(TimerProc), state, milliseconds, 0);
                while (state.State == false)
                {
                };
            }
            catch
            {
            }
            //s.Stop();
        }

        private static void TimerProc(object state)
        {
            ((TimerState)state).State = true;
        }
    }
}
