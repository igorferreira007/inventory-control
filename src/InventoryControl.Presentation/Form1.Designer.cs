namespace InventoryControl.Presentation;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        mainTableLayoutPanel = new TableLayoutPanel();
        productsDataGridView = new DataGridView();
        panel1 = new Panel();
        button4 = new Button();
        flowLayoutPanel1 = new FlowLayoutPanel();
        button1 = new Button();
        button2 = new Button();
        button3 = new Button();
        flowLayoutPanel2 = new FlowLayoutPanel();
        button5 = new Button();
        button6 = new Button();
        button7 = new Button();
        panel2 = new Panel();
        button8 = new Button();
        mainTableLayoutPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)productsDataGridView).BeginInit();
        panel1.SuspendLayout();
        flowLayoutPanel1.SuspendLayout();
        flowLayoutPanel2.SuspendLayout();
        SuspendLayout();
        // 
        // mainTableLayoutPanel
        // 
        mainTableLayoutPanel.ColumnCount = 1;
        mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainTableLayoutPanel.Controls.Add(productsDataGridView, 0, 1);
        mainTableLayoutPanel.Controls.Add(panel1, 0, 2);
        mainTableLayoutPanel.Controls.Add(flowLayoutPanel2, 0, 0);
        mainTableLayoutPanel.Dock = DockStyle.Fill;
        mainTableLayoutPanel.Location = new Point(0, 0);
        mainTableLayoutPanel.Name = "mainTableLayoutPanel";
        mainTableLayoutPanel.Padding = new Padding(16);
        mainTableLayoutPanel.RowCount = 3;
        mainTableLayoutPanel.RowStyles.Add(new RowStyle());
        mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainTableLayoutPanel.RowStyles.Add(new RowStyle());
        mainTableLayoutPanel.Size = new Size(800, 450);
        mainTableLayoutPanel.TabIndex = 1;
        // 
        // productsDataGridView
        // 
        productsDataGridView.AllowUserToAddRows = false;
        productsDataGridView.AllowUserToDeleteRows = false;
        productsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        productsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        productsDataGridView.Dock = DockStyle.Fill;
        productsDataGridView.Location = new Point(16, 51);
        productsDataGridView.Margin = new Padding(0);
        productsDataGridView.MultiSelect = false;
        productsDataGridView.Name = "productsDataGridView";
        productsDataGridView.ReadOnly = true;
        productsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        productsDataGridView.Size = new Size(768, 352);
        productsDataGridView.TabIndex = 1;
        // 
        // panel1
        // 
        panel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        panel1.BackColor = SystemColors.ActiveCaption;
        panel1.Controls.Add(button4);
        panel1.Controls.Add(flowLayoutPanel1);
        panel1.Location = new Point(16, 411);
        panel1.Margin = new Padding(0, 8, 0, 0);
        panel1.MaximumSize = new Size(1280, 0);
        panel1.MinimumSize = new Size(500, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(768, 23);
        panel1.TabIndex = 2;
        panel1.Resize += panel1_Resize;
        // 
        // button4
        // 
        button4.Anchor = AnchorStyles.Right;
        button4.Location = new Point(693, 0);
        button4.Margin = new Padding(0);
        button4.Name = "button4";
        button4.Size = new Size(75, 23);
        button4.TabIndex = 1;
        button4.Text = "button4";
        button4.UseVisualStyleBackColor = true;
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.AutoSize = true;
        flowLayoutPanel1.Controls.Add(button1);
        flowLayoutPanel1.Controls.Add(button2);
        flowLayoutPanel1.Controls.Add(button3);
        flowLayoutPanel1.Dock = DockStyle.Left;
        flowLayoutPanel1.Location = new Point(0, 0);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new Size(241, 23);
        flowLayoutPanel1.TabIndex = 0;
        flowLayoutPanel1.WrapContents = false;
        // 
        // button1
        // 
        button1.Location = new Point(0, 0);
        button1.Margin = new Padding(0);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        // 
        // button2
        // 
        button2.Location = new Point(83, 0);
        button2.Margin = new Padding(8, 0, 0, 0);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 1;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Location = new Point(166, 0);
        button3.Margin = new Padding(8, 0, 0, 0);
        button3.Name = "button3";
        button3.Size = new Size(75, 23);
        button3.TabIndex = 2;
        button3.Text = "button3";
        button3.UseVisualStyleBackColor = true;
        // 
        // flowLayoutPanel2
        // 
        flowLayoutPanel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        flowLayoutPanel2.BackColor = SystemColors.ActiveCaption;
        flowLayoutPanel2.Controls.Add(button5);
        flowLayoutPanel2.Controls.Add(button6);
        flowLayoutPanel2.Controls.Add(button7);
        flowLayoutPanel2.Controls.Add(panel2);
        flowLayoutPanel2.Controls.Add(button8);
        flowLayoutPanel2.Location = new Point(19, 19);
        flowLayoutPanel2.Name = "flowLayoutPanel2";
        flowLayoutPanel2.Size = new Size(762, 29);
        flowLayoutPanel2.TabIndex = 3;
        // 
        // button5
        // 
        button5.Location = new Point(3, 3);
        button5.Name = "button5";
        button5.Size = new Size(75, 23);
        button5.TabIndex = 0;
        button5.Text = "button5";
        button5.UseVisualStyleBackColor = true;
        // 
        // button6
        // 
        button6.Location = new Point(84, 3);
        button6.Name = "button6";
        button6.Size = new Size(75, 23);
        button6.TabIndex = 1;
        button6.Text = "button6";
        button6.UseVisualStyleBackColor = true;
        // 
        // button7
        // 
        button7.Location = new Point(165, 3);
        button7.Name = "button7";
        button7.Size = new Size(75, 23);
        button7.TabIndex = 2;
        button7.Text = "button7";
        button7.UseVisualStyleBackColor = true;
        // 
        // panel2
        // 
        panel2.Dock = DockStyle.Fill;
        panel2.Location = new Point(246, 3);
        panel2.Name = "panel2";
        panel2.Size = new Size(117, 23);
        panel2.TabIndex = 4;
        // 
        // button8
        // 
        button8.Anchor = AnchorStyles.Right;
        button8.Location = new Point(369, 3);
        button8.Name = "button8";
        button8.Size = new Size(75, 23);
        button8.TabIndex = 3;
        button8.Text = "button8";
        button8.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(mainTableLayoutPanel);
        Name = "Form1";
        Text = "Form1";
        mainTableLayoutPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)productsDataGridView).EndInit();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        flowLayoutPanel1.ResumeLayout(false);
        flowLayoutPanel2.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel mainTableLayoutPanel;
    private Panel panel1;
    private FlowLayoutPanel flowLayoutPanel1;
    private Button button4;
    private Button button1;
    private Button button2;
    private Button button3;
    private DataGridView productsDataGridView;
    private FlowLayoutPanel flowLayoutPanel2;
    private Button button5;
    private Button button6;
    private Button button7;
    private Button button8;
    private Panel panel2;
}
