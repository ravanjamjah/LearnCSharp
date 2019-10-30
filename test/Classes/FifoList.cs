﻿namespace CustomCollection.Classes
{
    public abstract class FifoList<T>
    {
        private LinkedNode<T> first;

        private LinkedNode<T> GetFirst() => first;
        private LinkedNode<T> GetLast(LinkedNode<T> item)
        {
            var itemNext = item.GetNext();
            if (itemNext == null)
                return item;
            else
                return GetLast(itemNext);
        }

        private void SetFirst(LinkedNode<T> val) => first = val; //گذاشتن این تابع بصورت عمومی درست نیست چون عملکرد آن می تواند اطلاعات کلاس را خراب کند و یا باید کنترلی روی آن گذاشت

        public FifoList()
        {
            first = null;
        }
        public void Add(T data)
        {
            LinkedNode<T> item = new LinkedNode<T>(data);
            if (first == null)
                first = item;
            else
            {
                var lastItem = GetLast(first);
                lastItem.SetNext(lastItem, item);
            }
        }

        public LinkedNode<T> Remove()
        {
            if (first == null)
                return null;
            
            var old = first;
            var firstNext = first.GetNext();
            SetFirst(firstNext);
            return old;
        }

        public void ClearList() => first = null;

        public int CountOfList()
        {
            var cursor = GetFirst();
            var counter = 0;
            while (cursor != null)
            {
                cursor = cursor.GetNext();
                counter++;
            }
            return counter;
        }
    }
}
