using BOT.Helper;
using BOT.Model;
using Db.Bot;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Actions.genshin
{
    class GenshinGachaAction
    {
        public static string splitWord = "|";


        public static List<GachaValueReturn> residentGachaOne(Genshin gen)
        {
            List<GachaValueReturn> list = new();
            GenshinDataAction.ResidentOneMark(gen);
            GachaValueReturn gacha;

            //四五星保底
            if (gen.Resident4Count / 10 >= 1 && gen.Resident5Count / 20 >= 1)
            {
                gacha= getResidentGacha(true, true);
                GenshinDataAction.Role4Mark(gen, gacha);
                GenshinDataAction.Role5Mark(gen, gacha,true);
            }
            //四星保底
            else if (gen.Resident4Count / 10 >= 1)
            {
                gacha = getResidentGacha(true, false);
                GenshinDataAction.Role4Mark(gen, gacha);
            }
            //五星保底
            else if (gen.Resident5Count / 20 >= 1)
            {
                gacha = getResidentGacha(false, true);
                GenshinDataAction.Role5Mark(gen, gacha, true);
            }
            else
            {
                gacha = getResidentGacha(false, false);
                if (gacha.level == 5)
                {
                    //重置低保计次
                    GenshinDataAction.Role5Mark(gen, gacha, false);
                }
                else if (gacha.level == 4)
                {
                    GenshinDataAction.Role4Mark(gen, gacha);
                }
                else
                {
                    gen.ResidentWeapon3 += 1;
                    gen.Update();
                }
            }

            list.Add(gacha);
            return list;
        }


        //常驻十连
        public static List<GachaValueReturn> residentGachaTen(Genshin gen,bool isGold)
        {
            GachaValueReturn gacha;
            List<GachaValueReturn> list = new();
            var rowLength = 10;
            int rowNumber = 1;
            //五星低保
            if (isGold)
            {
                rowNumber = 2;
                gacha = getResidentGacha(false, true);
                //重置低保计数
                GenshinDataAction.Role5Mark(gen,gacha,true);
                list.Add(gacha);
            }

            //四星低保
            gacha = getResidentGacha(true, false);
            GenshinDataAction.Role4Mark(gen, gacha);
            list.Add(gacha);

            for (; rowNumber < rowLength; rowNumber++)
            {
                gacha = getResidentGacha(false, false);
                
                if (gacha.level == 5)
                {
                    //重置低保计次
                    GenshinDataAction.Role5Mark(gen, gacha,false);
                }
                else if(gacha.level == 4)
                {
                    GenshinDataAction.Role4Mark(gen, gacha);
                }
                else
                {
                    gen.ResidentWeapon3 += 1;
                }
                gen.Update();
                list.Add(gacha);
            }
            return list;
        }
        //角色Up十连
        public static List<GachaValueReturn> gachaRoleUpTen(bool isProtectUp, bool isGold, bool isGoldUp)
        {

            GachaValueReturn gacha;
            List<GachaValueReturn> list = new();
            var isProtect = false;
            var rowLength = 10;
            var gold = isGold;
            int rowNumber = 1;
            //五星低保
            if (gold)
            {
                rowNumber = 2;
                //二次五星Up低保
                if (isGoldUp)
                {
                    gacha = getRoleUpGacha(isProtect, false, true, true);
                    list.Add(gacha);
                }
                else
                {
                    gacha = getRoleUpGacha(isProtect, false, true, false);
                    list.Add(gacha);
                }
            }

            //四星低保
            if (isProtectUp)
            {
                gacha = getRoleUpGacha(true, true, false, false);
                list.Add(gacha);
            }
            else
            {
                gacha = getRoleUpGacha(true, false, false, false);
                list.Add(gacha);
            }


            //其他抽奖机会
            for (; rowNumber < rowLength; rowNumber++)
            {
                gacha = getRoleUpGacha(false, false, false, false);
                list.Add(gacha);
            }
            return list;
        }
        public static List<GachaValueReturn> gachaWeaponUpTen(bool isProtectUp, bool isGold, bool isGoldUp)
        {
            GachaValueReturn gacha;
            List<GachaValueReturn> list = new();
            var isProtect = false;
            var rowLength = 10;
            var gold = isGold;
            int rowNumber = 1;
            //五星低保
            if (gold)
            {
                rowNumber = 2;
                //二次五星Up低保
                if (isGoldUp)
                {
                    gacha = getWeaponUpGacha(isProtect, false, true, true);
                    list.Add(gacha);
                }
                else
                {
                    gacha = getWeaponUpGacha(isProtect, false, true, false);
                    list.Add(gacha);
                }
            }

            //四星低保
            if (isProtectUp)
            {
                gacha = getWeaponUpGacha(true, true, false, false);
                list.Add(gacha);
            }
            else
            {
                gacha = getWeaponUpGacha(true, false, false, false);
                list.Add(gacha);
            }


            //其他抽奖机会
            for (; rowNumber < rowLength; rowNumber++)
            {
                gacha = getWeaponUpGacha(false, false, false, false);
                list.Add(gacha);
            }
            return list;
        }
        ////武器Up十连
        //public static List<GachaValueReturn> gachaWeaponUpTen(bool isProtectUp,bool isGold, bool isGoldUp)
        //{
        //    List<GachaValueReturn> list = new();
        //    var isProtect = false;
        //    var rowLength = 10;
        //    var gold = isGold;
        //    var up = isGoldUp;
        //    for (int rowNumber = 0; rowNumber < rowLength; rowNumber++)
        //    {
        //        var gacha = new GachaReturn();
        //        if (gold)
        //        {
        //            if (up)
        //            {
        //                gacha = getWeaponUpGacha(rowNumber, rowLength, isProtect,isProtectUp, gold, up);
        //                up = false;
        //            }
        //            else
        //            {
        //                gacha = getWeaponUpGacha(rowNumber, rowLength, isProtect, isProtectUp, gold, up);
        //            }
        //            gold = false;
        //        }
        //        else
        //        {
        //            gacha = getWeaponUpGacha(rowNumber, rowLength, isProtect, isProtectUp, gold, up);
        //        }
        //        list.Add(gacha.gachaVelue);
        //        isProtect = gacha.isProtect;
        //    }
        //    return list;
        //}


        //常驻
        private static GachaValueReturn getResidentGacha(bool isProtect, bool isGold)
        {
            var gacha = new GachaValueReturn();

            var m = isGaChaCheck(GachaUp.Resident5);
            //触发强制大保底出金
            if (isGold)
            {
                m = true;
            }
            if (m)
            {
                //获得常驻五星角色或武器
                gacha = getFromLevel5();
            }
            else
            {
                var n = isGaChaCheck(GachaUp.Resident4);
                if (isProtect)
                {
                    n = true;
                }

                if (n)
                {
                    //获得常驻四星角色或武器
                    gacha = getFromLevel4();
                }
                else
                {
                    gacha = getFromLevelOther();
                }
            }
            return gacha;
        }



        //角色Up
        private static GachaValueReturn getRoleUpGacha(bool isProtect, bool isProtectUp, bool isGold, bool isGoldUp)
        {
            var gacha = new GachaValueReturn();

            var m = isGaChaCheck(GachaUp.Role5Up);

            //触发强制大保底出金
            if (isGold)
            {
                m = true;
            }

            if (m)
            {
                //强制触发二轮保底出Up金
                if (isGoldUp)
                {
                    //100%获得up池五星角色
                    gacha = getFromUpRole5();
                }
                else
                {
                    //50%获得up池五星角色
                    //50%获得常驻池五星角色
                    gacha = getFromUpRoleLevel5();
                }
            }
            else
            {
                var n = isGaChaCheck(GachaUp.Role4Up);
                if (isProtect)
                {
                    n = true;
                }

                //抽中则从4级Up奖池中随机(爆率与常驻池一致)
                if (n)
                {
                    if (isProtectUp)
                    {
                        //100%获得up池四星角色
                        gacha = getFromUpRole4();
                    }
                    else
                    {
                        //50%获得up池四星角色
                        //50%获得常驻池四星物品
                        gacha = getFromUpRoleLevel4();
                    }
                }
                else
                {
                    gacha = getFromLevelOther();
                }

            }
            return gacha;
        }

        /// <summary>
        /// 武器Up
        /// </summary>
        /// <param name="index">第几项</param>
        /// <param name="rowLength">总次数</param>
        /// <param name="isProtect">四星低保</param>
        /// <param name="isProtectUp">二次四星Up低保</param>
        /// <param name="isGold">五星低保</param>
        /// <param name="isGoldUp">二次五星Up低保</param>
        /// <returns></returns>
        private static GachaValueReturn getWeaponUpGacha(bool isProtect, bool isProtectUp, bool isGold, bool isGoldUp)
        {
            var gacha = new GachaValueReturn();


            var m = isGaChaCheck(GachaUp.Weapon5Up);

            //触发强制大保底出金
            if (isGold)
            {
                m = true;
            }

            if (m)
            {
                //强制触发二轮保底出Up金
                if (isGoldUp)
                {
                    //100%概率获得本期Up武器
                    gacha = getFromUpWeapon5();
                }
                else
                {
                    //75%概率获得本期Up武器
                    //25%概率获得其他五星物品
                    gacha = getFromUpWeaponLevel5();
                    ////失去低保
                    //isProtect = true;
                    //gacha.isProtect = isProtect;
                }
            }
            else
            {

                var n = isGaChaCheck(GachaUp.Weapon4Up);
                if (isProtect)
                {
                    n = true;
                }
                if (n)
                {
                    if (isProtectUp)
                    {
                        //100%概率获得本期四星Up武器
                        gacha = getFromUpWeapon4();
                    }
                    else
                    {
                        //75%概率获得本期四星Up武器
                        //25%概率获得其他四星物品
                        gacha = getFromUpWeaponLevel4();
                    }
                }
                else
                {
                    gacha = getFromLevelOther();
                }




            }
            return gacha;
        }



        private static GachaValueReturn getFromUpWeaponLevel5()
        {
            Random rdmNum = getGRand();
            var v = rdmNum.Next(0, 4);
            var value = new GachaValueReturn();
            if (v == 0)
            {
                value = getFromWeapon5();
            }
            else
            {
                value = getFromUpWeapon5();
            }
            return value;
        }

        private static GachaValueReturn getFromUpWeaponLevel4()
        {
            Random rdmNum = getGRand();
            var v = rdmNum.Next(0, 4);
            var value = new GachaValueReturn();
            if (v == 0)
            {
                //25%获得其他四星武器或四星角色
                value = getFromLevel4();
            }
            else
            {
                //75%获得本期Up四星武器
                value = getFromUpWeapon4();
            }
            return value;
        }


        private static GachaValueReturn getFromLevel5()
        {
            Random rdmNum = getGRand();
            var v = rdmNum.Next(0, 2);
            var value = new GachaValueReturn();
            if (v == 0)
            {
                //50%获得常驻池五星角色
                value = getFromRole5();
            }
            else
            {
                //50%获得常驻池五星武器
                value = getFromWeapon5();
            }
            return value;
        }

        private static GachaValueReturn getFromUpRoleLevel5()
        {
            Random rdmNum = getGRand();
            var v = rdmNum.Next(0, 2);
            var value = new GachaValueReturn();
            if (v == 0)
            {
                //50%获得常驻池五星角色
                value = getFromRole5();
            }
            else
            {
                //50%获得up池五星角色
                value = getFromUpRole5();
            }
            return value;
        }

        private static GachaValueReturn getFromUpRoleLevel4()
        {
            Random rdmNum = getGRand();
            var v = rdmNum.Next(0, 2);
            var value = new GachaValueReturn();
            if (v == 0)
            {
                //50%获得up池四星角色
                value = getFromUpRole4();
            }
            else
            {
                //50%获得常驻池四星物品
                value = getFromLevel4();
            }
            return value;
        }


        //按照1：1的概率均匀从武器和角色池中选择4星物品
        private static GachaValueReturn getFromLevel4()
        {
            Random rdmNum = getGRand();
            var v = rdmNum.Next(0, 2);
            var value = new GachaValueReturn();
            if (v == 0)
            {
                value = getFromRole4();
            }
            else
            {
                value = getFromWeapon4();
            }
            return value;
        }

        //获取非五星四星物品
        //目前只有三星武器
        private static GachaValueReturn getFromLevelOther()
        {
            Random rdmNum = getGRand();
            //var v = rdmNum.Next(0, 90);
            var value = new GachaValueReturn();
            value = getFromWeapon3();
            //if (v == 0)
            //{
            //    value = getFromRoleOther();
            //}
            //else
            //{
            //    value = getFromWeapon3();
            //}
            return value;
        }
        //按照Up角色池中选择5星物品
        private static GachaValueReturn getFromUpRole5()
        {
            Random rdmNum = getGRand();
            var upRole5 = ConfigHelper.GetSectionValues("5星up角色");
            var index = rdmNum.Next(upRole5.Length);
            var re = new GachaValueReturn()
            {
                value = upRole5[index],
                type = 0,
                level = 5
            };
            return re;
        }
        //从常驻角色池中选择5星物品
        private static GachaValueReturn getFromRole5()
        {
            Random rdmNum = getGRand();
            var role5 = ConfigHelper.GetSectionValues("5星常驻角色");
            var index = rdmNum.Next(role5.Length);
            var re = new GachaValueReturn()
            {
                value = role5[index],
                type = 0,
                level = 5
            };
            return re;
        }
        //从up角色池中选择4星物品
        private static GachaValueReturn getFromUpRole4()
        {
            Random rdmNum = getGRand();
            var upRole4 = ConfigHelper.GetSectionValues("4星up角色");
            var index = rdmNum.Next(upRole4.Length);
            var re = new GachaValueReturn()
            {
                value = upRole4[index],
                type = 0,
                level = 4
            };
            return re;
        }




        //从常驻角色池中选择4星物品
        private static GachaValueReturn getFromRole4()
        {
            Random rdmNum = getGRand();
            var role4 = ConfigHelper.GetSectionValues("4星常驻角色");
            var index = rdmNum.Next(role4.Length);
            var re = new GachaValueReturn()
            {
                value = role4[index],
                type = 0,
                level = 4
            };
            return re;
        }

        //private static GachaValueReturn getFromRoleOther()
        //{
        //    Random rdmNum = getGRand();
        //    var roleOther = ConfigHelper.GetSectionValues("4星白给角色");
        //    var index = rdmNum.Next(roleOther.Length);
        //    var re = new GachaValueReturn()
        //    {
        //        value = roleOther[index],
        //        type = 0,
        //        level = 4
        //    };
        //    return re;
        //}


        //从常驻武器池中选择5星物品
        private static GachaValueReturn getFromWeapon5()
        {
            Random rdmNum = getGRand();
            var weapon5 = ConfigHelper.GetSectionValues("5星常驻武器");
            var index = rdmNum.Next(weapon5.Length);
            var re = new GachaValueReturn()
            {
                value = weapon5[index],
                type = 1,
                level = 5
            };
            return re;
        }
        //从up武器池中选择5星物品
        private static GachaValueReturn getFromUpWeapon5()
        {
            Random rdmNum = getGRand();
            var upWeapon5 = ConfigHelper.GetSectionValues("5星up武器");
            var index = rdmNum.Next(upWeapon5.Length);
            var re = new GachaValueReturn()
            {
                value = upWeapon5[index],
                type = 1,
                level = 5
            };
            return re;
        }
        //从up武器池中选择4星物品
        private static GachaValueReturn getFromUpWeapon4()
        {
            Random rdmNum = getGRand();
            var upWeapon4 = ConfigHelper.GetSectionValues("4星up武器");
            var index = rdmNum.Next(upWeapon4.Length);
            var re = new GachaValueReturn()
            {
                value = upWeapon4[index],
                type = 1,
                level = 4
            };
            return re;
        }
        //从常驻武器池中选择4星物品
        private static GachaValueReturn getFromWeapon4()
        {
            Random rdmNum = getGRand();
            var weapon4 = ConfigHelper.GetSectionValues("4星常驻武器");
            var index = rdmNum.Next(weapon4.Length);
            var re = new GachaValueReturn()
            {
                value = weapon4[index],
                type = 1,
                level = 4
            };
            return re;
        }
        //从常驻武器池中选择3星物品
        private static GachaValueReturn getFromWeapon3()
        {
            Random rdmNum = getGRand();
            var weapon3 = ConfigHelper.GetSectionValues("3星武器");
            var index = rdmNum.Next(weapon3.Length);
            var re = new GachaValueReturn()
            {
                value = weapon3[index],
                type = 1,
                level = 3
            };
            return re;
        }


        //public static void Test()
        //{
        //    // Get your template and output file paths
        //    var templateFile = new FileInfo(@$"{AppDomain.CurrentDomain.BaseDirectory}\example.xlsx");
        //    //var outputFile = new FileInfo("C:\\Temp\\output.xlsx");

        //    using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(templateFile))
        //    {
        //        List<MyObject> objectList = new List<MyObject>();

        //        for (int rowNumber = 0; rowNumber < 1000; rowNumber++)
        //        {
        //            MyObject genericObject = new MyObject();
        //            genericObject.Count = rowNumber;
        //            genericObject.Value = isGaChaCheck(51);

        //            objectList.Add(genericObject);
        //        }
        //        fastExcel.Write(objectList, "Sheet1", true);
        //    }

        //    //Console.WriteLine(isGaChaCheck(51));
        //    //var randomizerNum = RandomizerFactory.GetRandomizer(new FieldOptionsNumber {Max=1,Seed=""});
        //    //string num = randomizerNum.Generate();
        //    //Console.WriteLine(num);

        //    //foreach(var c in ConfigHelper.GetSectionValues("4星常驻角色"))
        //    //{
        //    //    Console.WriteLine(c);
        //    //}


        //}
        //public class MyObject
        //{
        //    public int Count { get; set; }
        //    public bool Value { get; set; }
        //}
        private static bool isGaChaCheck(int weight)
        {
            bool isCheck = false;
            Random rdm = new Random(DateTime.Now.Millisecond);

            // 记录开始时间
            //DateTime t1 = DateTime.Now;
            // 生成1000个数字
            int[] data = new int[1000];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }
            // 打乱这副牌
            for (int i = 0; i < data.Length; i++)
            {
                int idx1 = i;
                int idx2 = rdm.Next(data.Length);
                int tmp = data[idx1];
                data[idx1] = data[idx2];
                data[idx2] = tmp;
            }
            // 取这副牌的前6条记录，结果放在 result 中
            int[] result = new int[weight];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = data[i];
            }

            Random rdmNum = getGRand();
            int p = data[rdmNum.Next(data.Length)];

            if (result.Contains(p))
            {
                isCheck = true;
            }

            //// 终止时间
            //DateTime t2 = DateTime.Now;
            //// 打印总共用时，我测试是0.6510372秒
            //Console.WriteLine((t2 - t1).TotalMilliseconds);
            //for (int i = 0; i < result.Length; i++)
            //{
            //	Console.Write(" ");
            //	Console.Write(result[i]);
            //}
            return isCheck;

        }

        private static Random getGRand()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();//生成字节数组
            int iRoot = BitConverter.ToInt32(buffer, 0);//利用BitConvert方法把字节数组转换为整数
            Random rdmNum = new Random(iRoot);//以这个生成的整数为种子
            return rdmNum;
        }
    }
}
