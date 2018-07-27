/*==============================
* author:		Duanbin
* time:			2018.07.27
* description:	将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示
* function:		
* ==============================
*/
using System.Collections.Generic;
using UnityEngine;

namespace BuilderStructure
{
    public class BuilderStructure : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            // create director and builders
            Director director = new Director();
            Builder builder1 = new ConcreteBuildA();
            Builder builder2 = new ConcreteBuildB();

            director.Construct(builder1);
            director.GetResult().ShowProduct();

            director.Construct(builder2);
            director.GetResult().ShowProduct();
        }
    }

    /// <summary>
    /// 建造指示者
    /// </summary>
    public class Director
    {
        private Product m_Product;

        public Director()
        {

        }

        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="theBuilder">功能实现者接口</param>
        public void Construct(Builder theBuilder)
        {
            m_Product = new Product();
            theBuilder.BuildPart1(m_Product);
            theBuilder.BuildPart2(m_Product);
        }

        /// <summary>
        /// 获取成品
        /// </summary>
        /// <returns>产品</returns>
        public Product GetResult()
        {
            return m_Product;
        }
    }

    /// <summary>
    /// 功能实现者接口
    /// </summary>
    public abstract class Builder
    {
        public abstract void BuildPart1(Product product);
        public abstract void BuildPart2(Product product);
    }

    /// <summary>
    /// 具体功能实现A
    /// </summary>
    public class ConcreteBuildA : Builder
    {
        public override void BuildPart1(Product product)
        {
            product.AddPart("ConcreteBuildA_BuildPart1");
        }

        public override void BuildPart2(Product product)
        {
            product.AddPart("ConcreteBuildA_BuildPart2");
        }
    }

    /// <summary>
    /// 具体功能实现者B
    /// </summary>
    public class ConcreteBuildB : Builder
    {
        public override void BuildPart1(Product product)
        {
            product.AddPart("ConcreteBuildB_BuildPart1");
        }

        public override void BuildPart2(Product product)
        {
            product.AddPart("ConcreteBuildB_BuildPart2");
        }
    }

    /// <summary>
    /// 产品
    /// </summary>
    public class Product
    {
        private List<string> m_Part = new List<string>();

        public Product()
        {

        }

        public void AddPart(string part)
        {
            m_Part.Add(part);
        }

        public void ShowProduct()
        {
            foreach (string part in m_Part)
            {
                Debug.Log(GetType() + "ShowProduct : " + part);
            }
        }
    }
}