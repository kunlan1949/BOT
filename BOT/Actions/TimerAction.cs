using BOT.Model;
using BOT.Module.Send;
using BOT.Utils;
using Db.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BOT.Action
{
    class TimerAction
    {
        public static void LatteryOpen()
        {
            //设定定时执行
            DelayMission.lattery();
            setTaskAtFixedTime((int)DelayMission.Type.Lottery);
        }
        //要执行的任务
        private static void LatteryOpenThings(object state)
        {
            DelayMission.lattery();
            //循环执行
            setTaskAtFixedTime((int)DelayMission.Type.Lottery);
        }


        private static void setTaskAtFixedTime(int type)
        {
            switch (type)
            {
                case (int)DelayMission.Type.Lottery:
                    {
                        DateTime now = DateTime.Now;
                        DateTime Clock = DateTime.Now.AddSeconds(60);
                        if (now > Clock)
                        {
                            //如果当前时间大于设定时间，切换到次日的设定时间
                            Clock = Clock.AddDays(1.0);
                        }

                        //倒计时时间
                        int msUntilFour = (int)((Clock - now).TotalMilliseconds);

                        var t = new Timer(LatteryOpenThings);
                        t.Change(msUntilFour, Timeout.Infinite);
                    }
                    break;
            }


          
        }
    }
}
