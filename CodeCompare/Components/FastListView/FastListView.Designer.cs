namespace FastListView
{
    partial class FastListView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FastListView));
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderLines = new System.Windows.Forms.ColumnHeader("(none)");
            this.columnHeaderText = new System.Windows.Forms.ColumnHeader();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.ScrollBarVertical = new System.Windows.Forms.VScrollBar();
            this.pnlList = new System.Windows.Forms.Panel();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlList.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.AllowDrop = true;
            this.listView.AutoArrange = false;
            this.listView.BackColor = System.Drawing.Color.White;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLines,
            this.columnHeaderText});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Scrollable = false;
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(433, 254);
            this.listView.SmallImageList = this.imageListIcons;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.SizeChanged += new System.EventHandler(this.listView_SizeChanged);
            this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            // 
            // columnHeaderLines
            // 
            this.columnHeaderLines.Text = "Lines";
            // 
            // columnHeaderText
            // 
            this.columnHeaderText.Text = "Text";
            this.columnHeaderText.Width = 100;
            
        
            // 
            // ScrollBarVertical
            // 
            this.ScrollBarVertical.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollBarVertical.Location = new System.Drawing.Point(0, 0);
            this.ScrollBarVertical.Name = "ScrollBarVertical";
            this.ScrollBarVertical.Size = new System.Drawing.Size(18, 254);
            this.ScrollBarVertical.TabIndex = 1;
            this.ScrollBarVertical.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBarVertical_Scroll);
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.listView);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(0, 0);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(433, 254);
            this.pnlList.TabIndex = 2;
            // 
            // pnlScroll
            // 
            this.pnlScroll.Controls.Add(this.ScrollBarVertical);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlScroll.Location = new System.Drawing.Point(433, 0);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(18, 254);
            this.pnlScroll.TabIndex = 3;
            // 
            // FastListView
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlScroll);
            this.Name = "FastListView";
            this.Size = new System.Drawing.Size(451, 254);
            this.Load += new System.EventHandler(this.FastListView_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FastListView_Paint);
            this.pnlList.ResumeLayout(false);
            this.pnlScroll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

      

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeaderText;
        private System.Windows.Forms.VScrollBar ScrollBarVertical;
        private System.Windows.Forms.ColumnHeader columnHeaderLines;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.ImageList imageListIcons;
    }
}
