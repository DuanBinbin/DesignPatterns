/*
* ==============================
* FileName:		CompositeStructure
* Author:		DuanBin
* CreateTime:	8/9/2018 7:33:21 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompositeStructure
{
	public class CompositeStructure : MonoBehaviour {
	
		void Start () {
            // Create a tree structure
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            Composite comp1 = new Composite("Composite Y");
            comp1.Add(new Leaf("Leaf YA"));
            comp1.Add(new Leaf("Leaf YB"));

            comp.Add(comp1);

            // Add and remove a leaf
            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.Display(2);
		}
	}

    public abstract class Component
    {
        protected string m_name;

        public Component(string name)
        {
            m_name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }

    public class Composite : Component
    {
        private List<Component> _children = new List<Component>();

        public Composite(string name) : base(name)
        {
        }

        public override void Add(Component c)
        {
            _children.Add(c);
        }

        // Recursively display child notes
        public override void Display(int depth)
        {
            Debug.Log(new String('-', depth) + m_name);

            foreach (Component component in _children)
            {
                component.Display(depth + 2);
            }
        }

        public override void Remove(Component c)
        {
            _children.Remove(c);
        }
    }

    public class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {
        }

        public override void Add(Component c)
        {
            Debug.Log("Cann't add to a leaf");
        }

        public override void Display(int depth)
        {
            Debug.Log(new String('-', depth) + m_name);
        }

        public override void Remove(Component c)
        {
            Debug.Log("Cann't remove from a leaf");            
        }
    }
}


