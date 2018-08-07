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
    /// ��¼ӵ����
    /// </summary>
    public class Originator
    {
        /// <summary>
        /// ״̬����Ҫ������
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
        /// ����Ҫ�洢�ļ�¼
        /// </summary>
        /// <returns>Memento</returns>
        public Memento CreateMemento()
        {
            Memento memento = new Memento();
            memento.State = _state;
            return memento;
        }

        /// <summary>
        /// ����Ҫ�ָ��ļ�¼
        /// </summary>
        /// <param name="theMemento">Memento</param>
        public void SetMemento(Memento theMemento)
        {
            _state = theMemento.State;
        }
    }

    /// <summary>
    /// ��¼������
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
    /// ��¼������
    /// </summary>
    public class Caretaker
    {
        private Dictionary<string, Memento> _mementoDic = new Dictionary<string, Memento>();

        /// <summary>
        /// ����
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
        /// ��ȡ
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