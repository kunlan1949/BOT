using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BOT.Model.Game.TwentyOneModel;

namespace BOT.Model.Game
{
    class TwentyOneModel
    {
        public static List<int> value =new() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1 };//点数
       
        public enum Color
        {
            Spade, Heart, Diamond, Club
        }
        
        public enum point { two, three, four, five, six, seven, eight, nine, ten, J, Q, K, A}//点数
    }
    class Poker //定义poker类
    {     //扑克
        private string p1, p2;
        public Poker(string x, point y)//构造函数
        {

            this.p1 = x;
            switch (y)
            {
                case point.two: this.p2 = "2"; break;
                case point.three: this.p2 = "3"; break;
                case point.four: this.p2 = "4"; break;
                case point.five: this.p2 = "5"; break;
                case point.six: this.p2 = "6"; break;
                case point.seven: this.p2 = "7"; break;
                case point.eight: this.p2 = "8"; break;
                case point.nine: this.p2 = "9"; break;
                case point.ten: this.p2 = "10"; break;
                case point.J: this.p2 = "J"; break;
                case point.Q: this.p2 = "Q"; break;
                case point.K: this.p2 = "K"; break;
                case point.A: this.p2 = "A"; break;
            }
        }
    }
}
