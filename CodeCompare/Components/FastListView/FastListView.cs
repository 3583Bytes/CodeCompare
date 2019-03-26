using CodeCompare.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace FastListView
{
    public partial class FastListView : UserControl
    {
        #region Delegates

        public delegate void ListViewDoubleClickHandler(object sender, EventArgs e);

        public delegate void ListViewDragDropHandler(object sender, DragEventArgs e, string fileName);

        public delegate void ScrollBarVerticalHandler(object sender, EventArgs e);

        public delegate void SelectedIndexChangedHandler(object sender, EventArgs e);

        #endregion

        private readonly List<CompareItem> allItems;

        private ColumnHeaderAutoResizeStyle columnHeaderAutoResizeStyle;

        private int displayedItemsStart;
        private int displayedItemsTotal;
        private bool itemsChanged;
        private int lastActualCount;
        private bool selectAll;
        private int selectedItemIndex;
        private bool viewDifferences;

        private int ListRowHeight
        {
            get { return (listView.ClientSize.Height - (listView.Font.Height + 4))/(listView.Font.Height + 4); }
        }

        public int DisplayedItemsTotal
        {
            get { return ListRowHeight; }
        }

        public ListView.ColumnHeaderCollection Columns
        {
            get { return listView.Columns; }
            set
            {
                listView.Columns.Clear();

                foreach (ColumnHeader columnHeader in value)
                {
                    listView.Columns.Add(columnHeader);
                }
            }
        }

        public bool SelectAll
        {
            get { return selectAll; }
        }

        public ListView.SelectedListViewItemCollection SelectedItems
        {
            get { return listView.SelectedItems; }
        }

        public List<CompareItem> AllItems
        {
            get { return allItems; }
        }

        public bool ItemsChanged
        {
            get { return itemsChanged; }
            set { itemsChanged = value; }
        }

        public int SelectedItemIndex
        {
            get
            {
                if (listView.SelectedItems != null)
                {
                    if (listView.SelectedItems.Count > 0)
                    {
                        return displayedItemsStart + listView.SelectedItems[0].Index;
                    }                    
                }
               
                return 0;
                
            }
        }

        public int CurrentPageStartIndex
        {
            get { return displayedItemsStart; }
        }

        public int CurrentPageEndIndex
        {
            get { return displayedItemsStart + displayedItemsTotal; }
        }

        public int DisplayedItemsStart
        {
            get { return displayedItemsStart; }
        }

        #region Private Methods

        private void CheckVisibleScrollBars()
        {
            int NumberOfItems;


            NumberOfItems = allItems.Count;


            if (ListRowHeight >= NumberOfItems)
            {
                pnlScroll.Visible = false;
                ScrollBarVertical.Visible = false;
            }
            else
            {
                pnlScroll.Visible = true;
                ScrollBarVertical.Visible = true;
            }

            ScrollBarVertical.Maximum = NumberOfItems - ListRowHeight + 10;

            ScrollBarVertical.Minimum = 0;
        }

        private void DrawListBox()
        {
            try
            {
                int actualCount;

                actualCount = displayedItemsStart + displayedItemsTotal;

                if (actualCount != lastActualCount || lastActualCount == 0)
                {
                    listView.BeginUpdate();
                    listView.Items.Clear();

                    if (allItems.Count < displayedItemsTotal)
                    {
                        actualCount = allItems.Count;
                    }
                    else if (actualCount > allItems.Count)
                    {
                        actualCount = allItems.Count;
                    }

                    for (int x = displayedItemsStart; x < actualCount; x++)
                    {
                        if (x == selectedItemIndex)
                        {
                            allItems[x].Selected = true;
                        }
                        else
                        {
                            allItems[x].Selected = false;
                        }

                        if (viewDifferences)
                        {
                            if
                                (
                                allItems[x].CompareResultTag != CompareItem.CompareResult.Equal
                                &&
                                allItems[x].CompareResultTag != CompareItem.CompareResult.Ignore
                                )
                            {
                                CompareItem tmp = (CompareItem) allItems[x].Clone(); 
                                tmp.ItemSourceTag = allItems[x].ItemSourceTag;
                                tmp.CompareResultTag = allItems[x].CompareResultTag;

                                tmp.SubItems[1].Text = tmp.SubItems[1].Text.Replace("\t", "    ");
                                if (selectAll)
                                {
                                    tmp.Selected = true;
                                }
                                tmp.ToolTipText = tmp.ItemSourceTag + " " + tmp.CompareResultTag;
                                listView.Items.Add(tmp);
                            }
                            else
                            {
                                if (actualCount < allItems.Count)
                                {
                                    actualCount++;
                                }
                            }
                        }
                        else
                        {
                            CompareItem tmp = (CompareItem) allItems[x].Clone();
                            tmp.SubItems[1].Text = tmp.SubItems[1].Text.Replace("\t", "    ");
                            if (selectAll)
                            {
                                tmp.Selected = true;
                            }
                            tmp.ItemSourceTag = allItems[x].ItemSourceTag;
                            tmp.CompareResultTag = allItems[x].CompareResultTag;
                            tmp.ToolTipText = tmp.ItemSourceTag + " " + tmp.CompareResultTag;

                            listView.Items.Add(tmp);
                        }
                    }

                    lastActualCount = actualCount;

                    listView.EndUpdate();
                    CheckVisibleScrollBars();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception Drawing ListBox Items", MessageBoxButtons.OK);
            }
        }

        public void ReCalculateIndex()
        {
            for (int i = 0; i < allItems.Count; i++)
            {
                int index = i + 1;

                allItems[i].SubItems[0].Text = index.ToString(Utilities.GetNumberMask(index));
            }
        }

        #endregion

        #region Public Methods

        public void RefreshItems()
        {
            displayedItemsTotal = ListRowHeight;

            lastActualCount = 0;
            DrawListBox();

            for (int x = 0; x < listView.Columns.Count; x++)
            {
                listView.AutoResizeColumn(x, columnHeaderAutoResizeStyle);
            }
        }
        public void SaveItems(string filePath)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                return;
            }

            StringBuilder listViewContent = new StringBuilder();

            int x = 0;

            foreach (CompareItem item in allItems)
            {
                if (item.ItemSourceTag != CompareItem.ItemSource.NotInOriginal)
                {
                    listViewContent.Append(item.SubItems[1].Text);

                    //We don't append empty line for last line
                    if (x != allItems.Count - 1)
                    {
                        listViewContent.Append(Environment.NewLine);
                    }
                }
                x++;
            }

            TextWriter tw = new StreamWriter(filePath, false, System.Text.Encoding.Default);

            tw.WriteLine(listViewContent.ToString());

            tw.Close();

            itemsChanged = false;
        }

        public void ClearItems()
        {
            listView.Items.Clear();
            allItems.Clear();
            itemsChanged = true;
        }
        public void AutoResizeColumns(ColumnHeaderAutoResizeStyle ColumnHeaderAutoResizeStyle)
        {
            columnHeaderAutoResizeStyle = ColumnHeaderAutoResizeStyle;
        }

        public void Insert(int itemIndex, CompareItem item)
        {
            if (item == null)
            {
                return;
            }

            item.BackColor = Color.LightYellow;

            item.ItemSourceTag = CompareItem.ItemSource.Modified;

            allItems.Insert(itemIndex, item);

            ReCalculateIndex();
        }

        public void Add(CompareItem item)
        {
            if (item == null)
            {
                return;
            }
            item.BackColor = Color.LightYellow;
            item.ItemSourceTag = CompareItem.ItemSource.Modified;

            int i = allItems.Count + 1;

            item.SubItems[0].Text = i.ToString(Utilities.GetNumberMask(allItems.Count + 1));

            allItems.Add(item);
        }

        public void AddRange(List<CompareItem> items)
        {
            if (items != null)
            {
                allItems.AddRange(items);
                ReCalculateIndex();
            }
        }

        public void EditItem(int ItemIndex, CompareItem item)
        {
            if (item == null)
            {
                return;
            }

            for (int x = 0; x < allItems[ItemIndex].SubItems.Count; x++)
            {
                allItems[ItemIndex].SubItems[x].Text = item.SubItems[x].Text;
            }

            ReCalculateIndex();

            ModifiedItem(ItemIndex);


            itemsChanged = true;
        }

        public void EditItem(int ItemIndex, string NewText)
        {
            if (String.IsNullOrEmpty(NewText))
            {
                return;
            }

            allItems[ItemIndex].SubItems[1].Text = NewText;

            ReCalculateIndex();

            ModifiedItem(ItemIndex);

            lastActualCount = 0;
            DrawListBox();

            for (int x = 0; x < listView.Columns.Count; x++)
            {
                listView.AutoResizeColumn(x, columnHeaderAutoResizeStyle);
            }
            itemsChanged = true;
        }

        public void DeleteItem(int ItemIndex)
        {
            allItems.Remove(allItems[ItemIndex]);
            itemsChanged = true;
        }

        public void DeleteItemIfNotInOriginal(int ItemIndex)
        {
            if (allItems[ItemIndex].ItemSourceTag == CompareItem.ItemSource.NotInOriginal)
            {
                allItems.Remove(allItems[ItemIndex]);
                itemsChanged = true;
            }
        }

        public void IgnoreItem(int ItemIndex)
        {
            for (int x = 0; x < allItems[ItemIndex].SubItems.Count; x++)
            {
                allItems[ItemIndex].SubItems[x].BackColor = Color.White;
            }
            allItems[ItemIndex].BackColor = Color.White;
            allItems[ItemIndex].CompareResultTag = CompareItem.CompareResult.Ignore;
        }

        public void ModifiedItem(int ItemIndex)
        {
            allItems[ItemIndex].BackColor = Color.FromArgb(255, 255, 128);
            allItems[ItemIndex].ItemSourceTag = CompareItem.ItemSource.Modified;
        }

        public void ModifiedItem(CompareItem item)
        {
            item.BackColor = Color.FromArgb(255, 255, 128);
            item.ItemSourceTag = CompareItem.ItemSource.Modified;
        }

        public void SetItemDifferent(int ItemIndex)
        {
            for (int x = 0; x < allItems[ItemIndex].SubItems.Count; x++)
            {
                allItems[ItemIndex].SubItems[x].BackColor = Color.LightCoral;
            }
            allItems[ItemIndex].BackColor = Color.LightCoral;
            ;
            allItems[ItemIndex].CompareResultTag = CompareItem.CompareResult.Replace;
        }

        public void SetItemDifferentDirectory(int ItemIndex)
        {
            for (int x = 0; x < allItems[ItemIndex].SubItems.Count; x++)
            {
                allItems[ItemIndex].SubItems[x].BackColor = Color.LightCoral;
            }
            allItems[ItemIndex].BackColor = Color.FromArgb(208, 236, 204);
            ;
            allItems[ItemIndex].CompareResultTag = CompareItem.CompareResult.Replace;
        }


        public void SelectItem(int ItemIndex)
        {
            selectedItemIndex = ItemIndex;

            if (ScrollBarVertical.Visible == false)
            {
                DrawListBox();
            }
            else
            {
                if (displayedItemsStart != ItemIndex)
                {
                    if (ScrollBarVertical.Visible)
                    {
                        if (ScrollBarVertical.Maximum >= ItemIndex)
                        {
                            ScrollBarVertical.Value = ItemIndex;
                        }
                    }
                    displayedItemsStart = ItemIndex;
                    DrawListBox();
                }
            }
        }

        public void DisplayDifferences()
        {
            viewDifferences = true;
            lastActualCount = 0;
            DrawListBox();
        }

        public void DisplayAll()
        {
            viewDifferences = false;
            lastActualCount = 0;
            DrawListBox();

            for (int x = 0; x < listView.Columns.Count; x++)
            {
                listView.AutoResizeColumn(x, columnHeaderAutoResizeStyle);

            }
        }

        public void Clear()
        {
            listView.Clear();
        }

        #endregion

        #region Events

        private void ScrollBarVertical_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                displayedItemsStart = e.NewValue;
                DrawListBox();

                if (ListViewScroll != null)
                {
                    ListViewScroll(sender, e);
                }
            }
        }

        private void listView_SizeChanged(object sender, EventArgs e)
        {
            displayedItemsTotal = ListRowHeight;

            CheckVisibleScrollBars();
            DrawListBox();
        }

        private void FastListView_Paint(object sender, PaintEventArgs e)
        {
            DrawListBox();

            for (int x = 0; x < listView.Columns.Count; x++)
            {
                listView.AutoResizeColumn(x, columnHeaderAutoResizeStyle);

                

            }
        }

        private void FastListView_Load(object sender, EventArgs e)
        {
            displayedItemsTotal = ListRowHeight;
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count != listView.Items.Count)
            {
                selectAll = false;
            }
            else
            {
                selectAll = true;
            }

            foreach (CompareItem item in listView.Items)
            {
                int x = int.Parse(item.SubItems[0].Text) - 1;

                if (allItems.Count > x)
                {
                    if (item.BackColor != allItems[x].BackColor)
                    {
                        item.BackColor = allItems[x].BackColor;
                    }

                    item.ForeColor = Color.Black;

                    if (item.ImageIndex == 2)
                    {
                        item.ImageIndex = 0;
                    }
                }
            }

            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(this, e);
            }

            foreach (ListViewItem item in listView.SelectedItems)
            {
                item.BackColor = Color.FromArgb(49, 106, 197);
                item.ForeColor = Color.White;

                if (item.ImageIndex == 0)
                {
                    item.ImageIndex = 2;
                }
            }
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (ListViewDoubleClick != null)
            {
                ListViewDoubleClick(sender, e);
            }
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.A))
            {
                SelectAllItems();
            }
        }

        public void SelectAllItems()
        {
            selectAll = true;

            foreach (ListViewItem item in listView.Items)
            {
                item.Selected = true;
            }
        }

        #endregion

        public event SelectedIndexChangedHandler SelectedIndexChanged;
        public event ScrollBarVerticalHandler ListViewScroll;
        public event ListViewDoubleClickHandler ListViewDoubleClick;
        public event ListViewDragDropHandler ListViewDragDrop;

        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) != null)
            {
                string[] d = (string[]) e.Data.GetData(DataFormats.FileDrop);

                if (ListViewDragDrop != null)
                {
                    ListViewDragDrop(this, e, d[0]);
                }
            }
        }

        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        #region Constructors

        public FastListView()
        {
            InitializeComponent();

            allItems = new List<CompareItem>();

            displayedItemsStart = 0;
            displayedItemsTotal = 10;

            columnHeaderAutoResizeStyle = ColumnHeaderAutoResizeStyle.HeaderSize;
            


            listView.SelectedIndexChanged += listView_SelectedIndexChanged;
            ScrollBarVertical.Scroll += ScrollBarVertical_Scroll;

            lastActualCount = 0;
            selectedItemIndex = -1;
            itemsChanged = false;
            viewDifferences = false;
            selectAll = false;
        }

        #endregion Constructors
    }
}
