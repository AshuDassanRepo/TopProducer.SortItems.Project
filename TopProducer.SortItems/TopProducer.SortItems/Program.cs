using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopProducer.BusinessEntities;
using TopProducer.Enumerations;

namespace TopProducer.SortItems
{
    public class Program
    {
        //This Items list is used for building the initial items list
        public static List<Item> Items = new List<Item>();

        //This Items list is used for storing the sorted items
        public static List<Item> SortedItemsList = new List<Item>();
        
        public static void Main(string[] args)
        {
            BuildItemList();

            DisplayResults();
        }

        private static void DisplayResults()
        {
            while (Items.Count != SortedItemsList.Count)
            {
                SortTheListOfItems(Items);
            }
            
            /*
             * I don't need this complex display logic. We could simply just
             * display the items that are in the SortedItemsList
             */
            Console.WriteLine("Printing dependency sorted list:");
            Console.WriteLine();
            foreach (Item i in SortedItemsList)
            {
                Console.WriteLine("ItemId: " + i.ItemId + " " + "Item Name: " + i.ItemName);
                Console.WriteLine("Items need to be before item " + i.ItemId);
                if (i.Dependencies.Count > 0)
                {
                    foreach (Item iDepen in i.Dependencies)
                    {
                        Console.WriteLine("     ItemId: " + iDepen.ItemId + " " + "Item Name: " + iDepen.ItemName);
                    }
                }
                else
                {
                    Console.WriteLine("No items needed to be complete before " + i.ItemId);
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// This method does all the work. Depending on the item type
        /// either I add it to the SortedItemsList  or check to see if
        /// all the prerequistes have been completed before adding it to
        /// the SortedItemsList.
        /// </summary>
        /// <param name="items"></param>
        private static void SortTheListOfItems(List<Item> items)
        {
            bool preReqDone = false;

            foreach (Item i in items)
            {
                switch (i.ItemTypeDef)
                {
                    case ItemType.UnNamedWithoutDependency:
                    case ItemType.NamedWithoutDependency:
                        if (!SortedItemsList.Contains(i))
                        {
                            SortedItemsList.Add(i);
                        }
                        break;
                    case ItemType.UnNamedWithDependecy:
                    case ItemType.NamedWithDependencies:
                        foreach (Item depenDone in i.Dependencies)
                        {
                            if (SortedItemsList.Contains(depenDone))
                            {
                                preReqDone = true;                                
                            }
                            else
                            {
                                preReqDone = false;
                                break;
                            }
                        }

                        if (preReqDone)
                        {
                            if (!SortedItemsList.Contains(i))
                            {
                                SortedItemsList.Add(i);
                            }
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Used to build the original items that I am working with.
        /// </summary>
        /// <returns></returns>
        public static void BuildItemList()
        {   
            Item newItem1 = new Item();
            Item newItem2 = new Item();
            Item newItem3 = new Item();
            Item newItem4 = new Item();
            Item newItem5 = new Item();
            Item newItem6 = new Item();


            newItem1.ItemId = 1;
            newItem1.ItemName = "Item 1";
            newItem1.ItemTypeDef = ItemType.NamedWithDependencies;
            newItem1.Dependencies = new List<Item>();
            newItem1.Dependencies.Add(newItem4);
            Items.Add(newItem1);

            
            newItem2.ItemId = 2;
            newItem2.ItemName = "Item 2";
            newItem2.ItemTypeDef = ItemType.NamedWithDependencies;
            newItem2.Dependencies = new List<Item>();
            newItem2.Dependencies.Add(newItem1);
            //newItem2.Dependencies.Add(newItem4);
            Items.Add(newItem2);

            

            newItem3.ItemId = 3;
            newItem3.ItemName = "Item 3";
            newItem3.ItemTypeDef = ItemType.NamedWithDependencies;
            newItem3.Dependencies = new List<Item>();
            newItem3.Dependencies.Add(newItem1);
            newItem3.Dependencies.Add(newItem2);
            Items.Add(newItem3);

            

            newItem4.ItemId = 4;
            newItem4.ItemName = "Item 4";
            newItem4.ItemTypeDef = ItemType.NamedWithoutDependency;
            newItem4.Dependencies = new List<Item>();            
            //newItem4.Dependencies.Add(newItem2);            
            Items.Add(newItem4);
            
            newItem5.ItemId = 5;
            newItem5.ItemName = "Item 5";
            newItem5.ItemTypeDef = ItemType.NamedWithDependencies;
            newItem5.Dependencies = new List<Item>();
            newItem5.Dependencies.Add(newItem3);
            newItem5.Dependencies.Add(newItem6);
            Items.Add(newItem5);

            newItem6.ItemId = 6;
            newItem6.ItemName = "";
            newItem6.ItemTypeDef = ItemType.NamedWithDependencies;
            newItem6.Dependencies = new List<Item>();
            newItem6.Dependencies.Add(newItem3);
            //newItem6.Dependencies.Add(newItem4);
            Items.Add(newItem6);
        }
    }
}
