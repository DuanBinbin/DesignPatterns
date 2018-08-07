/*
* ==============================
* FileName:		MementoStructure
* Author:		DuanBin
* CreateTime:	8/6/2018 4:31:25 PM
* Description:		
* ==============================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MementoStructure
{
    public class MementoStructure : MonoBehaviour {

        void Start() {
            Originator originator = new Originator();
            Caretaker theCaretaker = new Caretaker();

            originator.SetInfo("on");
            Memento theMemento1 = originator.CreateMemento();
            theCaretaker.Add("1", theMemento1);

            originator.ShowInfo();
                       
            originator.SetInfo("off");
            Memento theMemento2 = originator.CreateMemento();
            theCaretaker.Add("2", theMemento2);
            originator.ShowInfo(); 
                 
            originator.SetMemento(theMemento1);           
            originator.ShowInfo();

            originator.SetMemento(theMemento2);
            originator.ShowInfo();            
        }
    }

    /// <summary>
    /// 记录拥有者
    /// </summary>
    public class Originator
    {
        /// <summary>
        /// 状态，需要被保存
        /// </summary>
        private string _state;

        public void SetInfo(string State)
        {
            _state = State;
        }

        public void ShowInfo()
        {
            Debug.Log(GetType() + ", Originator State = " + _state);
        }

        /// <summary>
        /// 产生要存储的记录
        /// </summary>
        /// <returns>Memento</returns>
        public Memento CreateMemento()
        {
            Memento memento = new Memento();
            memento.State = _state;
            return memento;
        }

        /// <summary>
        /// 设置要恢复的记录
        /// </summary>
        /// <param name="theMemento">Memento</param>
        public void SetMemento(Memento theMemento)
        {
            _state = theMemento.State;
        }
    }

    /// <summary>
    /// 记录保存者
    /// </summary>
    public class Memento
    {
        private string _state;

        public string State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }
    }
    
    /// <summary>
    /// 记录管理者
    /// </summary>
    public class Caretaker
    {
        private Dictionary<string, Memento> _mementoDic = new Dictionary<string, Memento>();

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="version"></param>
        /// <param name="theMemento"></param>
        public void Add(string version, Memento theMemento)
        {
            if (_mementoDic.ContainsKey(version) == false)
            {
                _mementoDic.Add(version, theMemento);
            }
            else
            {
                _mementoDic[version] = theMemento;
            }
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public Memento GetMemento(string version)
        {
            if (_mementoDic.ContainsKey(version) == false)
            {
                return null;
            }
            return _mementoDic[version];
        }
    }

}