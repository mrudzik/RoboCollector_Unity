using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A sorted list
/// </summary>
public class SortedList<T> where T:IComparable
{
    List<T> items = new List<T>();

    // used in Add method
    List<T> tempList = new List<T>();
	
    #region Constructors

    /// <summary>
    /// No argument constructor
    /// </summary>
    public SortedList()
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the number of items in the list
    /// </summary>
    /// <value>number of items in the list</value>
    public int Count
    {
        get { return items.Count; }
    }
	
    /// <summary>
    /// Gets the item in the array at the given index
    /// This property allows access using [ and ]
    /// </summary>
    /// <param name="index">index of item</param>
    /// <returns>item at the given index</returns>
    public T this[int index]
    {
        get { return items[index]; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Adds the given item to the list
    /// </summary>
    /// <param name="item">item</param>
    public void Add(T item)
    {
		// Just to be sure its clear
		tempList.Clear();
		if (items.Count == 0)
		{// In case if there is no items
			tempList.Add(item);
		}
		else
		{
			bool inserted = false;
			// Find needed position
			for (var i = 0; i < items.Count; i++)
			{
				if (inserted)
				{// if our item already inserted
				// just add old items till end
					tempList.Add(items[i]);
					continue;
				}
				else
				{
					if (item.CompareTo(items[i]) == -1)
					{// if our item is lesser than current obj in list
					 // just add our item to list
						tempList.Add(item);
						inserted = true;
					}
					// Just add obj from old list
					tempList.Add(items[i]);
				}
			}
			if (!inserted)
			{
				tempList.Add(item);
				//inserted = true;
			}
		}
		
		
		// Replaces all "items" objects with "tempList" objects
		items.Clear();
		items.AddRange(tempList);
		
	}

    /// <summary>
    /// Removes the item at the given index from the list
    /// </summary>
    /// <param name="index">index</param>
    public void RemoveAt(int index)
    {
		// add your implementation below
		items.RemoveAt(index);
    }

    /// <summary>
    /// Determines the index of the given item using binary search
    /// </summary>
    /// <param name="item">the item to find</param>
    /// <returns>the index of the item or -1 if it's not found</returns>
    public int IndexOf(T item)
    {
        int lowerBound = 0;
        int upperBound = items.Count - 1;
        int location = -1;

        // loop until found value or exhausted array
        while ((location == -1) &&
            (lowerBound <= upperBound))
        {
            // find the middle
            int middleLocation = lowerBound + (upperBound - lowerBound) / 2;
            T middleValue = items[middleLocation];

            // check for match
            if (middleValue.CompareTo(item) == 0)
            {
                location = middleLocation;
            }
            else
            {
                // split data set to search appropriate side
                if (middleValue.CompareTo(item) > 0)
                {
                    upperBound = middleLocation - 1;
                }
                else
                {
                    lowerBound = middleLocation + 1;
                }
            }
        }
        return location;
    }

    /// <summary>
    /// Sorts the list
    /// </summary>
    public void Sort()
    {
        items.Sort();
		Debug_List();
	}



	#region Debugging

	private void Debug_List()
	{
		// Debug Sorting
		if (items.Count > 0)
		{
			for (var i = 0; i < items.Count; i++)
			{
				Debug.Log("Item pos " + i + " item " + items[i]);
			}
			// Debug.Log("Last in Sorted List is " + items[items.Count - 1]);
		}
	}

	#endregion

	#endregion
}
