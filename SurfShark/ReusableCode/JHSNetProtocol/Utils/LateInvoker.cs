﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace JHSNetProtocol
{
    public struct LateInvokerTask
    {
        public float TickRate;
        public float DueTime;
        public int RepeatTimes; //0 = delete; -1 = infinite; 0++ = tick
        public Action Run;
    }

    public class LateInvoker
    {
        int RunEveryMS = 16;
        private static object s_Sync = new object();
        static volatile LateInvoker s_Instance;
        Queue<LateInvokerTask> Tasks = new Queue<LateInvokerTask>();
        public static LateInvoker Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_Sync)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new LateInvoker();
                            s_Instance.Init();
                        }
                    }
                }
                return s_Instance;
            }
        }

        void Init()
        {
            SetTicksPerSecond();
            new Thread(new ThreadStart(Update)).Start();
        }

        void Update()
        {
            while (true)
            {
                Thread.Sleep(RunEveryMS);
                lock (Tasks)
                {
                    List<LateInvokerTask> Recycle = new List<LateInvokerTask>();
                    while (Tasks.Count > 0)
                    {
                        LateInvokerTask DoWork = Tasks.Dequeue();
                        if (DoWork.DueTime < JHSTime.Time)
                        {
                            DoWork.Run.Invoke();
                            if (DoWork.RepeatTimes == -1)
                            {
                                DoWork.DueTime = JHSTime.Time + DoWork.TickRate;
                                Recycle.Add(DoWork);
                            }
                            else if (DoWork.RepeatTimes > 0)
                            {
                                DoWork.DueTime = JHSTime.Time + DoWork.TickRate;
                                DoWork.RepeatTimes -= 1;
                                if (DoWork.RepeatTimes > 0)
                                    Recycle.Add(DoWork);
                            }
                        }
                        else
                        {
                            Recycle.Add(DoWork);
                        }

                    }
                    Tasks = new Queue<LateInvokerTask>(Recycle);
                }
            }
        }

        internal void _InvokeWithDelay(Action Method, float TickRate)
        {
            lock (Tasks)
            {
                Tasks.Enqueue(new LateInvokerTask() { Run = Method, DueTime = JHSTime.Time + TickRate, RepeatTimes = 0, TickRate = TickRate });
            }
        }

        internal void _InvokeRepeating(Action Method, float TickRate, int RepeatTimes)
        {
            lock (Tasks)
            {
                Tasks.Enqueue(new LateInvokerTask() { Run = Method, DueTime = JHSTime.Time + TickRate, RepeatTimes = RepeatTimes, TickRate = TickRate });
            }
        }

        /// <summary>
        /// Parameter TickRate means invoke delay in seconds, this function will execute the action one time.
        /// </summary>
        /// <param name="Method"></param>
        /// <param name="TickRate"></param>
        public static void InvokeWithDelay(Action Method, float TickRate)
        {
            Instance._InvokeWithDelay(Method, TickRate);
        }

        /// <summary>
        /// Parameter TickRate means invoke delay in seconds and Parameter Repeat Times means how many time to keep invoking the function, -1 means infinite times.
        /// </summary>
        /// <param name="Method"></param>
        /// <param name="TickRate"></param>
        /// <param name="RepeatTimes"></param>
        public static void InvokeRepeating(Action Method, float TickRate, int RepeatTimes = -1)
        {
            Instance._InvokeRepeating(Method, TickRate, RepeatTimes);
        }

        /// <summary>
        /// Like in games this function will set a tick rate eg. 30 equals 30 Frames per second in this case LateInvoker will try its best to execute all functions 30 times per second.
        /// </summary>
        /// <param name="Ticks"></param>
        public static void SetTicksPerSecond(int Ticks = 30)
        {
            Instance.RunEveryMS = 1000 / Ticks;
        }

    }
}
