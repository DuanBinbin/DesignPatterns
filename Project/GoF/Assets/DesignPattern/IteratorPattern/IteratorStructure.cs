/*
* ==============================
* FileName:		IteratorStructure
* Author:		DuanBin
* CreateTime:	8/14/2018 10:27:40 AM
* Description:		
* ==============================
*/
using System.Collections;
using UnityEngine;

namespace IteratorStructure
{
	public class IteratorStructure : MonoBehaviour {
	
		void Start () {
            ConcreteAggregate aggregate = new ConcreteAggregate();
            aggregate[0] = "A";
            aggregate[1] = "B";
            aggregate[2] = "C";
            aggregate[3] = "D";

            Iterator ite = aggregate.CreatorIterator();

            Debug.Log("Iterating over collection");

            object item = ite.First();
            while (item != null)
            {
                Debug.Log(item);
                item = ite.Next();
            }
        }
	}

    public abstract class Aggregate
    {
        public abstract Iterator CreatorIterator();
    }

    public class ConcreteAggregate : Aggregate
    {
        private ArrayList _items = new ArrayList();

        public override Iterator CreatorIterator()
        {
            return new ConcreteIterator(this);
        }

        /// <summary>
        /// Gets item count
        /// </summary>
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public object this[int index]
        {
            get
            {
                return _items[index];
            }

            set
            {
                _items.Insert(index, value);
            }
        }
    }

    /// <summary>
    /// The 'Iterator' abstract class
    /// </summary>
    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool isDone();
        public abstract object CurrentItem();
    }

    public class ConcreteIterator : Iterator
    {
        private ConcreteAggregate _aggregate;
        private int _current = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        /// <summary>
        /// Gets current iteration 
        /// </summary>
        /// <returns></returns>
        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        /// <summary>
        /// Gets first iteration item
        /// </summary>
        /// <returns></returns>
        public override object First()
        {
            return _aggregate[0];
        }

        /// <summary>
        /// Gets whether iteration are complete
        /// </summary>
        /// <returns></returns>
        public override bool isDone()
        {
            return _current >= _aggregate.Count;
        }

        /// <summary>
        /// Gets next iteration item
        /// </summary>
        /// <returns></returns>
        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }
            return ret;
        }
    }
}


