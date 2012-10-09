using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopProducer.Enumerations;

namespace TopProducer.BusinessEntities
{
    /// <summary>
    /// The Item object which will have the following properties
    /// as part of it.
    /// </summary>
    public class Item
    {
        private long itemId_;
        private string itemName_;
        private ItemType itemTypeDef_;
        private List<Item> dependencies_;

        public long ItemId
        {
            set { itemId_ = value; }
            get { return itemId_; }
        }

        public string ItemName
        {
            set { itemName_ = value; }
            get { return itemName_; }
        }

        public ItemType ItemTypeDef
        {
            set { itemTypeDef_ = value; }
            get { return itemTypeDef_; }
        }

        public List<Item> Dependencies
        {
            set { dependencies_ = value; }
            get { return dependencies_; }
        }

    }
}
