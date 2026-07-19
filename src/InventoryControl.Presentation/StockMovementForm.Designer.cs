namespace InventoryControl.Presentation;

partial class StockMovementForm
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
        actionsFlowLayoutPanel = new FlowLayoutPanel();
        cancelButton = new Button();
        saveButton = new Button();
        titleLabel = new Label();
        fieldsTableLayoutPanel = new TableLayoutPanel();
        quantityTableLayoutPanel = new TableLayoutPanel();
        quantityLabel = new Label();
        quantityNumericUpDown = new NumericUpDown();
        productTableLayoutPanel = new TableLayoutPanel();
        productNameLabel = new Label();
        productLabel = new Label();
        mainTableLayoutPanel.SuspendLayout();
        actionsFlowLayoutPanel.SuspendLayout();
        fieldsTableLayoutPanel.SuspendLayout();
        quantityTableLayoutPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)quantityNumericUpDown).BeginInit();
        productTableLayoutPanel.SuspendLayout();
        SuspendLayout();
        // 
        // mainTableLayoutPanel
        // 
        mainTableLayoutPanel.ColumnCount = 1;
        mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainTableLayoutPanel.Controls.Add(actionsFlowLayoutPanel, 0, 2);
        mainTableLayoutPanel.Controls.Add(titleLabel, 0, 0);
        mainTableLayoutPanel.Controls.Add(fieldsTableLayoutPanel, 0, 1);
        mainTableLayoutPanel.Dock = DockStyle.Fill;
        mainTableLayoutPanel.Location = new Point(0, 0);
        mainTableLayoutPanel.Name = "mainTableLayoutPanel";
        mainTableLayoutPanel.Padding = new Padding(16);
        mainTableLayoutPanel.RowCount = 3;
        mainTableLayoutPanel.RowStyles.Add(new RowStyle());
        mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainTableLayoutPanel.RowStyles.Add(new RowStyle());
        mainTableLayoutPanel.Size = new Size(532, 202);
        mainTableLayoutPanel.TabIndex = 0;
        // 
        // actionsFlowLayoutPanel
        // 
        actionsFlowLayoutPanel.AutoSize = true;
        actionsFlowLayoutPanel.Controls.Add(cancelButton);
        actionsFlowLayoutPanel.Controls.Add(saveButton);
        actionsFlowLayoutPanel.Dock = DockStyle.Right;
        actionsFlowLayoutPanel.Location = new Point(308, 163);
        actionsFlowLayoutPanel.Margin = new Padding(0);
        actionsFlowLayoutPanel.Name = "actionsFlowLayoutPanel";
        actionsFlowLayoutPanel.Size = new Size(208, 23);
        actionsFlowLayoutPanel.TabIndex = 8;
        actionsFlowLayoutPanel.WrapContents = false;
        // 
        // cancelButton
        // 
        cancelButton.Location = new Point(0, 0);
        cancelButton.Margin = new Padding(0);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new Size(100, 23);
        cancelButton.TabIndex = 0;
        cancelButton.Text = "Cancelar";
        cancelButton.UseVisualStyleBackColor = true;
        cancelButton.Click += cancelButton_Click;
        // 
        // saveButton
        // 
        saveButton.Location = new Point(108, 0);
        saveButton.Margin = new Padding(8, 0, 0, 0);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(100, 23);
        saveButton.TabIndex = 1;
        saveButton.Text = "Salvar";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += saveButton_Click;
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        titleLabel.ForeColor = Color.ForestGreen;
        titleLabel.Location = new Point(16, 16);
        titleLabel.Margin = new Padding(0);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(144, 20);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "Entrada de Estoque";
        // 
        // fieldsTableLayoutPanel
        // 
        fieldsTableLayoutPanel.AutoSize = true;
        fieldsTableLayoutPanel.ColumnCount = 1;
        fieldsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        fieldsTableLayoutPanel.Controls.Add(quantityTableLayoutPanel, 0, 1);
        fieldsTableLayoutPanel.Controls.Add(productTableLayoutPanel, 0, 0);
        fieldsTableLayoutPanel.Dock = DockStyle.Fill;
        fieldsTableLayoutPanel.Location = new Point(16, 52);
        fieldsTableLayoutPanel.Margin = new Padding(0, 16, 0, 0);
        fieldsTableLayoutPanel.Name = "fieldsTableLayoutPanel";
        fieldsTableLayoutPanel.RowCount = 2;
        fieldsTableLayoutPanel.RowStyles.Add(new RowStyle());
        fieldsTableLayoutPanel.RowStyles.Add(new RowStyle());
        fieldsTableLayoutPanel.Size = new Size(500, 111);
        fieldsTableLayoutPanel.TabIndex = 1;
        // 
        // quantityTableLayoutPanel
        // 
        quantityTableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        quantityTableLayoutPanel.AutoSize = true;
        quantityTableLayoutPanel.BackColor = SystemColors.Control;
        quantityTableLayoutPanel.ColumnCount = 1;
        quantityTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        quantityTableLayoutPanel.Controls.Add(quantityLabel, 0, 0);
        quantityTableLayoutPanel.Controls.Add(quantityNumericUpDown, 0, 1);
        quantityTableLayoutPanel.Location = new Point(0, 58);
        quantityTableLayoutPanel.Margin = new Padding(0, 8, 0, 8);
        quantityTableLayoutPanel.Name = "quantityTableLayoutPanel";
        quantityTableLayoutPanel.RowCount = 2;
        quantityTableLayoutPanel.RowStyles.Add(new RowStyle());
        quantityTableLayoutPanel.RowStyles.Add(new RowStyle());
        quantityTableLayoutPanel.Size = new Size(500, 42);
        quantityTableLayoutPanel.TabIndex = 2;
        // 
        // quantityLabel
        // 
        quantityLabel.AutoSize = true;
        quantityLabel.Location = new Point(0, 0);
        quantityLabel.Margin = new Padding(0);
        quantityLabel.Name = "quantityLabel";
        quantityLabel.Size = new Size(69, 15);
        quantityLabel.TabIndex = 0;
        quantityLabel.Text = "Quantidade";
        // 
        // quantityNumericUpDown
        // 
        quantityNumericUpDown.Location = new Point(0, 19);
        quantityNumericUpDown.Margin = new Padding(0, 4, 0, 0);
        quantityNumericUpDown.Name = "quantityNumericUpDown";
        quantityNumericUpDown.Size = new Size(120, 23);
        quantityNumericUpDown.TabIndex = 1;
        // 
        // productTableLayoutPanel
        // 
        productTableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        productTableLayoutPanel.AutoSize = true;
        productTableLayoutPanel.BackColor = SystemColors.Control;
        productTableLayoutPanel.ColumnCount = 1;
        productTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        productTableLayoutPanel.Controls.Add(productNameLabel, 0, 1);
        productTableLayoutPanel.Controls.Add(productLabel, 0, 0);
        productTableLayoutPanel.Location = new Point(0, 8);
        productTableLayoutPanel.Margin = new Padding(0, 8, 0, 8);
        productTableLayoutPanel.Name = "productTableLayoutPanel";
        productTableLayoutPanel.RowCount = 2;
        productTableLayoutPanel.RowStyles.Add(new RowStyle());
        productTableLayoutPanel.RowStyles.Add(new RowStyle());
        productTableLayoutPanel.Size = new Size(500, 34);
        productTableLayoutPanel.TabIndex = 1;
        // 
        // productNameLabel
        // 
        productNameLabel.AutoSize = true;
        productNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        productNameLabel.Location = new Point(0, 19);
        productNameLabel.Margin = new Padding(0, 4, 0, 0);
        productNameLabel.Name = "productNameLabel";
        productNameLabel.Size = new Size(106, 15);
        productNameLabel.TabIndex = 1;
        productNameLabel.Text = "Nome do produto";
        // 
        // productLabel
        // 
        productLabel.AutoSize = true;
        productLabel.Location = new Point(0, 0);
        productLabel.Margin = new Padding(0);
        productLabel.Name = "productLabel";
        productLabel.Size = new Size(50, 15);
        productLabel.TabIndex = 0;
        productLabel.Text = "Produto";
        // 
        // StockMovementForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(532, 202);
        Controls.Add(mainTableLayoutPanel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "StockMovementForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Movimentação de estoque";
        Load += StockMovementForm_Load;
        mainTableLayoutPanel.ResumeLayout(false);
        mainTableLayoutPanel.PerformLayout();
        actionsFlowLayoutPanel.ResumeLayout(false);
        fieldsTableLayoutPanel.ResumeLayout(false);
        fieldsTableLayoutPanel.PerformLayout();
        quantityTableLayoutPanel.ResumeLayout(false);
        quantityTableLayoutPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)quantityNumericUpDown).EndInit();
        productTableLayoutPanel.ResumeLayout(false);
        productTableLayoutPanel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel mainTableLayoutPanel;
    private Label titleLabel;
    private TableLayoutPanel fieldsTableLayoutPanel;
    private Label productLabel;
    private TableLayoutPanel productTableLayoutPanel;
    private Label productNameLabel;
    private TableLayoutPanel quantityTableLayoutPanel;
    private Label quantityLabel;
    private FlowLayoutPanel actionsFlowLayoutPanel;
    private Button cancelButton;
    private Button saveButton;
    private NumericUpDown quantityNumericUpDown;
}