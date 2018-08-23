/*
* ==============================
* FileName:		ProxyPatternExample1
* Author:		DuanBin
* CreateTime:	8/23/2018 11:49:22 AM
* Description:		
* ==============================
*/
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProxyPatternExample1
{
	public class ProxyPatternExample1 : MonoBehaviour {
	
		void Start () {
            Printable p = new PrinterProxy("Alice");
            Debug.Log("现在的名字是 " + p.GetPrinterName() + "。");
            p.SetPrinterName("Bob");
            Debug.Log("现在的名字是 " + p.GetPrinterName() + "。");
            p.Print("Hello World");
        }
	}
   
    // 用于使PrinterProxy类和Printer类具有一致性
    public interface Printable {

        /// <summary>
        /// 设置名字
        /// </summary>
        /// <param name="name"></param>
        void SetPrinterName(string name);

        /// <summary>
        /// 获取名字
        /// </summary>
        /// <returns></returns>
        string GetPrinterName();

        /// <summary>
        /// 显示文字（打印输出）
        /// </summary>
        /// <param name="content"></param>
        void Print(string content);
    }

   /// <summary>
   /// 表示“本人”的类
   /// </summary>
    public class Printer : Printable
    {
        private string _name;

        public Printer()
        {
            HeavyJob("正在生成 Printer 的实例");
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        public Printer(string name)
        {
            _name = name;
            HeavyJob("正在生成Printer 的实例 （" + _name + ") ");
        }

        /// <summary>
        /// 获取打印机的名字
        /// </summary>
        /// <returns></returns>
        public string GetPrinterName()
        {
            return _name;
        }

        /// <summary>
        /// 显示带打印机名字的名字
        /// </summary>
        /// <param name="content"></param>
        public void Print(string content)
        {
            Debug.Log("=== " + _name + " ===");
            Debug.Log(content);
        }

        /// <summary>
        /// 设置打印机的名字
        /// </summary>
        /// <param name="name"></param>
        public void SetPrinterName(string name)
        {
            _name = name;   
        }

        // 重活
        private void HeavyJob(string msg)
        {
            Debug.Log("HeavyJob msg : " + msg);
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException e)
                {
                    Debug.LogError(e.Message);
                }
            }
            Debug.Log("finish");
        }
    }

    public class PrinterProxy : Printable
    {
        private string _name;   // 保存了打印机的名字
        private Printer _real;   // 保存的是“本人”

        public PrinterProxy()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        public PrinterProxy(string name)
        {
            _name = name;
        }

        /// <summary>
        /// 获取名字
        /// </summary>
        /// <returns></returns>
        public string GetPrinterName()
        {
            return _name;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="content"></param>
        public void Print(string content)
        {
            Realize();
            _real.Print(content);
        }

        /// <summary>
        /// 设置名字
        /// </summary>
        /// <param name="name"></param>
        public void SetPrinterName(string name)
        {
            if (null != _real)
            {
                _real.SetPrinterName(name);     // 同时设置“本人”的名字
            }
            _name = name;
        }

        // 生成“本人”
        private  void Realize()
        {
            if (null == _real)
            {
                _real = new Printer(_name);
            }
        }
    }

}