using System.Windows.Forms;

namespace FastListView
{
    public class CompareItem : ListViewItem
    {
        #region CompareResult enum

        public enum CompareResult
        {
            Delete,
            Add,
            Replace,
            Equal,
            Ignore,
            Unknown
        }

        #endregion

        #region ItemSource enum

        public enum ItemSource
        {
            Original,
            Modified,
            NotInOriginal,
            Unknown
        }

        #endregion

        private CompareResult compareResultTag;
        private ItemSource itemSourceTag;

        public CompareItem()
            : base()
        {
            compareResultTag = CompareResult.Unknown;
            itemSourceTag = ItemSource.Unknown;
        }

        public CompareItem(string sourceString) : base(sourceString)
        {
            compareResultTag = CompareResult.Unknown;
            itemSourceTag = ItemSource.Unknown;
        }

        public CompareItem
            (ListViewItem item, CompareResult CompareResultTag, ItemSource ItemSourceTag) : base()
        {
            Item = item;
            compareResultTag = CompareResultTag;
            itemSourceTag = ItemSourceTag;
        }

        public ItemSource ItemSourceTag
        {
            get { return itemSourceTag; }
            set { itemSourceTag = value; }
        }

        public CompareResult CompareResultTag
        {
            get { return compareResultTag; }
            set { compareResultTag = value; }
        }

        public ListViewItem Item
        {
            get { return Item; }
            set { Item = value; }
        }
    }
}