/*
* ==============================
* FileName:		CompositePatternExample1
* Author:		DuanBin
* CreateTime:	8/17/2018 5:16:08 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompositePatternExample1
{
	public class CompositePatternExample1 : MonoBehaviour {
	
		void Start () {
            ConcreteCompany root = new ConcreteCompany("Beijing parent company");
            root.Add(new HRDepartment("The parent HR apartment"));
            root.Add(new HRDepartment("The parent Finance apartment"));

            ConcreteCompany leafShanghai = new ConcreteCompany("Shanghai sub company");
            leafShanghai.Add(new HRDepartment("The parent HR apartment"));
            leafShanghai.Add(new HRDepartment("The parent Finance apartment"));
            root.Add(leafShanghai);

            ConcreteCompany leafNanjing = new ConcreteCompany("Nanjing sub company");
            leafNanjing.Add(new HRDepartment("The Nanjing HR apartment"));
            leafNanjing.Add(new HRDepartment("The Nanjing Finance apartment"));
            leafShanghai.Add(leafNanjing);

            root.Display(2);
            root.LineOfDuty();          
        }
	}

    /// <summary>
    /// 公司类，抽象类或接口
    /// </summary>
    public abstract class Company
    {
        protected string m_name;

        public Company(string name)
        {
            m_name = name;
        }

        public abstract void Add(Company theCompany);
        public abstract void Remove(Company theCompany);
        public abstract void Display(int depth);
        public abstract void LineOfDuty();
    }

    /// <summary>
    /// 具体公司类，实现接口树枝节点
    /// </summary>
    public class ConcreteCompany : Company
    {
        private List<Company> _subCompany = new List<Company>();

        public ConcreteCompany(string name) : base(name)
        {
            
        }

        public override void Add(Company theCompany)
        {
            _subCompany.Add(theCompany);
        }

        public override void Display(int depth)
        {
            foreach (Company component in _subCompany)
            {
                component.Display(depth + 2);
            }
        }

        public override void LineOfDuty()
        {
            foreach (Company component in _subCompany)
            {
                component.LineOfDuty();
            }
        }

        public override void Remove(Company theCompany)
        {
            _subCompany.Remove(theCompany);
        }
    }

    /// <summary>
    /// 人力资源部，树叶节点
    /// </summary>
    public class HRDepartment : Company
    {
        public HRDepartment(string name) : base(name)
        {
        }

        public override void Add(Company theCompany)
        {
            Debug.Log("HRDepartment.Add()");
        }

        public override void Display(int depth)
        {            
            Debug.Log(new string('-', depth) + m_name);
        }

        public override void LineOfDuty()
        {
            Debug.LogFormat("{0} 员工招聘培训管理", m_name);           
        }

        public override void Remove(Company theCompany)
        {
            Debug.Log("HRDepartment.Remove()");
        }
    }

    /// <summary>
    /// 人力资源部，树叶节点
    /// </summary>
    public class FinanceDepartment : Company
    {
        public FinanceDepartment(string name) : base(name)
        {
        }

        public override void Add(Company theCompany)
        {
            Debug.Log("FinanceDepartment.Add()");
        }

        public override void Display(int depth)
        {
            Debug.Log(new string('-', depth) + m_name);
        }

        public override void LineOfDuty()
        {
            Debug.LogFormat("{0} 公司财务收支管理", m_name);
        }

        public override void Remove(Company theCompany)
        {
            Debug.Log("FinanceDepartment.Remove()");
        }
    }
}