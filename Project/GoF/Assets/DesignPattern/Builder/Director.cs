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

namespace BuildPattern
{
    /// <summary>
    /// 建造指示者
    /// 说明：负责对象构建时的“流程分析安排”
    /// </summary>
    public class Director
    {
        private Product _product;

        public Director()
        {

        }

        /// <summary>
        /// 构建
        /// 说明：明确定义对象的组装流程，即调用Builder接口方法的顺序
        /// </summary>
        /// <param name="theBuilder"></param>
        public void Construct(Builder theBuilder)
        {
            _product = new Product();

            theBuilder.BuildPart1(_product);
            theBuilder.BuildPart2(_product);
        }

        /// <summary>
        /// 获取成品
        /// </summary>
        /// <returns></returns>
        public Product GetResult()
        {
            return _product;
        }
    }
}

