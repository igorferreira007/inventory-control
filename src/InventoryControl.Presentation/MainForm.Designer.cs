namespace InventoryControl.Presentation;

partial class MainForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        mainTableLayoutPanel = new TableLayoutPanel();
        productsDataGridView = new DataGridView();
        bottomPanel = new Panel();
        deleteProductButton = new Button();
        bottomFlowLayoutPanel = new FlowLayoutPanel();
        editProductButton = new Button();
        increaseStockButton = new Button();
        decreaseStockButton = new Button();
        topPanel = new Panel();
        newProductButton = new Button();
        topFlowLayoutPanel = new FlowLayoutPanel();
        searchProductTextBox = new TextBox();
        searchProductButton = new Button();
        mainTableLayoutPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)productsDataGridView).BeginInit();
        bottomPanel.SuspendLayout();
        bottomFlowLayoutPanel.SuspendLayout();
        topPanel.SuspendLayout();
        topFlowLayoutPanel.SuspendLayout();
        SuspendLayout();
        // 
        // mainTableLayoutPanel
        // 
        mainTableLayoutPanel.ColumnCount = 1;
        mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainTableLayoutPanel.Controls.Add(productsDataGridView, 0, 1);
        mainTableLayoutPanel.Controls.Add(bottomPanel, 0, 3);
        mainTableLayoutPanel.Controls.Add(topPanel, 0, 0);
        mainTableLayoutPanel.Dock = DockStyle.Fill;
        mainTableLayoutPanel.Location = new Point(0, 0);
        mainTableLayoutPanel.Name = "mainTableLayoutPanel";
        mainTableLayoutPanel.Padding = new Padding(16);
        mainTableLayoutPanel.RowCount = 4;
        mainTableLayoutPanel.RowStyles.Add(new RowStyle());
        mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainTableLayoutPanel.RowStyles.Add(new RowStyle());
        mainTableLayoutPanel.RowStyles.Add(new RowStyle());
        mainTableLayoutPanel.Size = new Size(800, 450);
        mainTableLayoutPanel.TabIndex = 0;
        // 
        // productsDataGridView
        // 
        productsDataGridView.AllowUserToAddRows = false;
        productsDataGridView.AllowUserToDeleteRows = false;
        productsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        productsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        productsDataGridView.Dock = DockStyle.Fill;
        productsDataGridView.Location = new Point(16, 47);
        productsDataGridView.Margin = new Padding(0);
        productsDataGridView.MultiSelect = false;
        productsDataGridView.Name = "productsDataGridView";
        productsDataGridView.ReadOnly = true;
        productsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        productsDataGridView.Size = new Size(768, 356);
        productsDataGridView.TabIndex = 1;
        // 
        // bottomPanel
        // 
        bottomPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        bottomPanel.BackColor = SystemColors.Control;
        bottomPanel.Controls.Add(deleteProductButton);
        bottomPanel.Controls.Add(bottomFlowLayoutPanel);
        bottomPanel.Location = new Point(16, 411);
        bottomPanel.Margin = new Padding(0, 8, 0, 0);
        bottomPanel.MaximumSize = new Size(1280, 0);
        bottomPanel.Name = "bottomPanel";
        bottomPanel.Size = new Size(768, 23);
        bottomPanel.TabIndex = 3;
        bottomPanel.Resize += bottomPanel_Resize;
        // 
        // deleteProductButton
        // 
        deleteProductButton.Dock = DockStyle.Right;
        deleteProductButton.Location = new Point(668, 0);
        deleteProductButton.Name = "deleteProductButton";
        deleteProductButton.Size = new Size(100, 23);
        deleteProductButton.TabIndex = 6;
        deleteProductButton.Text = "Excluir";
        deleteProductButton.UseVisualStyleBackColor = true;
        // 
        // bottomFlowLayoutPanel
        // 
        bottomFlowLayoutPanel.AutoSize = true;
        bottomFlowLayoutPanel.BackColor = SystemColors.Control;
        bottomFlowLayoutPanel.Controls.Add(editProductButton);
        bottomFlowLayoutPanel.Controls.Add(increaseStockButton);
        bottomFlowLayoutPanel.Controls.Add(decreaseStockButton);
        bottomFlowLayoutPanel.Dock = DockStyle.Left;
        bottomFlowLayoutPanel.Location = new Point(0, 0);
        bottomFlowLayoutPanel.Name = "bottomFlowLayoutPanel";
        bottomFlowLayoutPanel.Size = new Size(376, 23);
        bottomFlowLayoutPanel.TabIndex = 5;
        bottomFlowLayoutPanel.WrapContents = false;
        // 
        // editProductButton
        // 
        editProductButton.Location = new Point(0, 0);
        editProductButton.Margin = new Padding(0);
        editProductButton.Name = "editProductButton";
        editProductButton.Size = new Size(100, 23);
        editProductButton.TabIndex = 1;
        editProductButton.Text = "Editar";
        editProductButton.UseVisualStyleBackColor = true;
        // 
        // increaseStockButton
        // 
        increaseStockButton.Location = new Point(108, 0);
        increaseStockButton.Margin = new Padding(8, 0, 0, 0);
        increaseStockButton.Name = "increaseStockButton";
        increaseStockButton.Size = new Size(130, 23);
        increaseStockButton.TabIndex = 3;
        increaseStockButton.Text = "Entrada Estoque";
        increaseStockButton.UseVisualStyleBackColor = true;
        // 
        // decreaseStockButton
        // 
        decreaseStockButton.Location = new Point(246, 0);
        decreaseStockButton.Margin = new Padding(8, 0, 0, 0);
        decreaseStockButton.Name = "decreaseStockButton";
        decreaseStockButton.Size = new Size(130, 23);
        decreaseStockButton.TabIndex = 4;
        decreaseStockButton.Text = "Saída Estoque";
        decreaseStockButton.UseVisualStyleBackColor = true;
        // 
        // topPanel
        // 
        topPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        topPanel.Controls.Add(newProductButton);
        topPanel.Controls.Add(topFlowLayoutPanel);
        topPanel.Location = new Point(16, 16);
        topPanel.Margin = new Padding(0, 0, 0, 8);
        topPanel.MaximumSize = new Size(1280, 0);
        topPanel.Name = "topPanel";
        topPanel.Size = new Size(768, 23);
        topPanel.TabIndex = 4;
        topPanel.Resize += topPanel_Resize;
        // 
        // newProductButton
        // 
        newProductButton.Dock = DockStyle.Right;
        newProductButton.Location = new Point(638, 0);
        newProductButton.Name = "newProductButton";
        newProductButton.Size = new Size(130, 23);
        newProductButton.TabIndex = 7;
        newProductButton.Text = "Novo Produto";
        newProductButton.UseVisualStyleBackColor = true;
        // 
        // topFlowLayoutPanel
        // 
        topFlowLayoutPanel.AutoSize = true;
        topFlowLayoutPanel.Controls.Add(searchProductTextBox);
        topFlowLayoutPanel.Controls.Add(searchProductButton);
        topFlowLayoutPanel.Dock = DockStyle.Left;
        topFlowLayoutPanel.Location = new Point(0, 0);
        topFlowLayoutPanel.Name = "topFlowLayoutPanel";
        topFlowLayoutPanel.Size = new Size(608, 23);
        topFlowLayoutPanel.TabIndex = 0;
        topFlowLayoutPanel.WrapContents = false;
        // 
        // searchProductTextBox
        // 
        searchProductTextBox.Location = new Point(0, 0);
        searchProductTextBox.Margin = new Padding(0);
        searchProductTextBox.Name = "searchProductTextBox";
        searchProductTextBox.PlaceholderText = "Pesquisar produto";
        searchProductTextBox.Size = new Size(500, 23);
        searchProductTextBox.TabIndex = 0;
        searchProductTextBox.KeyDown += searchProductTextBox_KeyDown;
        searchProductTextBox.KeyPress += searchProductTextBox_KeyPress;
        // 
        // searchProductButton
        // 
        searchProductButton.Location = new Point(508, 0);
        searchProductButton.Margin = new Padding(8, 0, 0, 0);
        searchProductButton.Name = "searchProductButton";
        searchProductButton.Size = new Size(100, 23);
        searchProductButton.TabIndex = 2;
        searchProductButton.Text = "Buscar";
        searchProductButton.UseVisualStyleBackColor = true;
        searchProductButton.Click += searchProductButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(mainTableLayoutPanel);
        MinimumSize = new Size(816, 0);
        Name = "MainForm";
        Text = "MainForm";
        Load += MainForm_Load;
        mainTableLayoutPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)productsDataGridView).EndInit();
        bottomPanel.ResumeLayout(false);
        bottomPanel.PerformLayout();
        bottomFlowLayoutPanel.ResumeLayout(false);
        topPanel.ResumeLayout(false);
        topPanel.PerformLayout();
        topFlowLayoutPanel.ResumeLayout(false);
        topFlowLayoutPanel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel mainTableLayoutPanel;
    private DataGridView productsDataGridView;
    private FlowLayoutPanel bottomFlowLayoutPanel;
    private Button editProductButton;
    private Button increaseStockButton;
    private Button decreaseStockButton;
    private Button deleteProductButton;
    private Panel bottomPanel;
    private Button searchProductButton;
    private Panel topPanel;
    private FlowLayoutPanel topFlowLayoutPanel;
    private TextBox searchProductTextBox;
    private Button newProductButton;
}