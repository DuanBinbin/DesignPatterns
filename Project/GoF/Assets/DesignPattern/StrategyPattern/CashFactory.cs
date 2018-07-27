/*==============================
* author:		Duanbin
* time:			2018.07.20
* description:	
* function:		
* ==============================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrateypePattern
{
    /// <summary>
    /// 现金收费工厂
    /// </summary>
    public class CashFactory
    {

        public static CashSuper createCashAccept(string type)
        {
            CashSuper cs = null;
            switch (type)
            {
                case "正常收费":
                    return cs = new CashNormal();
                case "满300返100":
                    return cs = new CashReturn("300", "100");
                case "打8折":
                    return cs = new CashRebate("0.8");
                default:
                    return null;
            }
        }
    }
}


