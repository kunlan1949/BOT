using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Utils
{
    class MissionUtil
    {
        public static string getType(int missionType, int missionTypeAux)
        {
            var type = "";
            switch (missionType)
            {
                case 0:
                    {
                        if (missionTypeAux == 0)
                        {
                            type = "识图";
                        }
                        else
                        {
                            type = "模糊识图";
                        }
                        break;
                    }

                default: break;
            }
            return type;
        }
    }
}
