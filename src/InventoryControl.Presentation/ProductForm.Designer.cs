namespace InventoryControl.Presentation;

partial class ProductForm
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
        titleLabel = new Label();
        fieldsTableLayoutPanel = new TableLayoutPanel();
        descriptionFlowLayoutPanel = new FlowLayoutPanel();
        descriptionLabel = new Label();
        descriptionTextBox = new TextBox();
        priceFlowLayoutPanel = new FlowLayoutPanel();
        priceLabel = new Label();
        priceTextBox = new InventoryControl.Presentation.Controls.CurrencyTextBox();
        nameFlowLayoutPanel = new FlowLayoutPanel();
        nameLabel = new Label();
        nameTextBox = new TextBox();
        actionsFlowLayoutPanel = new FlowLayoutPanel();
        cancelButton = new Button();
        saveButton = new Button();
        mainTableLayoutPanel.SuspendLayout();
        fieldsTableLayoutPanel.SuspendLayout();
        descriptionFlowLayoutPanel.SuspendLayout();
        priceFlowLayoutPanel.SuspendLayout();
        nameFlowLayoutPanel.SuspendLayout();
        actionsFlowLayoutPanel.SuspendLayout();
        SuspendLayout();
        // 
        // mainTableLayoutPanel
        // 
        mainTableLayoutPanel.ColumnCount = 1;
        mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
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
        mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        mainTableLayoutPanel.Size = new Size(800, 337);
        mainTableLayoutPanel.TabIndex = 0;
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Location = new Point(16, 16);
        titleLabel.Margin = new Padding(0);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(116, 15);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "Cadastro de Produto";
        // 
        // fieldsTableLayoutPanel
        // 
        fieldsTableLayoutPanel.ColumnCount = 1;
        fieldsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        fieldsTableLayoutPanel.Controls.Add(descriptionFlowLayoutPanel, 0, 2);
        fieldsTableLayoutPanel.Controls.Add(priceFlowLayoutPanel, 0, 1);
        fieldsTableLayoutPanel.Controls.Add(nameFlowLayoutPanel, 0, 0);
        fieldsTableLayoutPanel.Controls.Add(actionsFlowLayoutPanel, 0, 3);
        fieldsTableLayoutPanel.Dock = DockStyle.Fill;
        fieldsTableLayoutPanel.Location = new Point(16, 47);
        fieldsTableLayoutPanel.Margin = new Padding(0, 16, 0, 0);
        fieldsTableLayoutPanel.Name = "fieldsTableLayoutPanel";
        fieldsTableLayoutPanel.RowCount = 3;
        fieldsTableLayoutPanel.RowStyles.Add(new RowStyle());
        fieldsTableLayoutPanel.RowStyles.Add(new RowStyle());
        fieldsTableLayoutPanel.RowStyles.Add(new RowStyle());
        fieldsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        fieldsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        fieldsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        fieldsTableLayoutPanel.Size = new Size(768, 274);
        fieldsTableLayoutPanel.TabIndex = 1;
        // 
        // descriptionFlowLayoutPanel
        // 
        descriptionFlowLayoutPanel.AutoSize = true;
        descriptionFlowLayoutPanel.Controls.Add(descriptionLabel);
        descriptionFlowLayoutPanel.Controls.Add(descriptionTextBox);
        descriptionFlowLayoutPanel.Dock = DockStyle.Fill;
        descriptionFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
        descriptionFlowLayoutPanel.Location = new Point(0, 124);
        descriptionFlowLayoutPanel.Margin = new Padding(0, 8, 0, 8);
        descriptionFlowLayoutPanel.Name = "descriptionFlowLayoutPanel";
        descriptionFlowLayoutPanel.Size = new Size(768, 119);
        descriptionFlowLayoutPanel.TabIndex = 6;
        descriptionFlowLayoutPanel.WrapContents = false;
        // 
        // descriptionLabel
        // 
        descriptionLabel.AutoSize = true;
        descriptionLabel.Location = new Point(0, 0);
        descriptionLabel.Margin = new Padding(0);
        descriptionLabel.Name = "descriptionLabel";
        descriptionLabel.Size = new Size(58, 15);
        descriptionLabel.TabIndex = 1;
        descriptionLabel.Text = "Descrição";
        // 
        // descriptionTextBox
        // 
        descriptionTextBox.Location = new Point(0, 19);
        descriptionTextBox.Margin = new Padding(0, 4, 0, 0);
        descriptionTextBox.Multiline = true;
        descriptionTextBox.Name = "descriptionTextBox";
        descriptionTextBox.ScrollBars = ScrollBars.Vertical;
        descriptionTextBox.Size = new Size(768, 100);
        descriptionTextBox.TabIndex = 2;
        // 
        // priceFlowLayoutPanel
        // 
        priceFlowLayoutPanel.AutoSize = true;
        priceFlowLayoutPanel.Controls.Add(priceLabel);
        priceFlowLayoutPanel.Controls.Add(priceTextBox);
        priceFlowLayoutPanel.Dock = DockStyle.Fill;
        priceFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
        priceFlowLayoutPanel.Location = new Point(0, 66);
        priceFlowLayoutPanel.Margin = new Padding(0, 8, 0, 8);
        priceFlowLayoutPanel.Name = "priceFlowLayoutPanel";
        priceFlowLayoutPanel.Size = new Size(768, 42);
        priceFlowLayoutPanel.TabIndex = 5;
        priceFlowLayoutPanel.WrapContents = false;
        // 
        // priceLabel
        // 
        priceLabel.AutoSize = true;
        priceLabel.Location = new Point(0, 0);
        priceLabel.Margin = new Padding(0);
        priceLabel.Name = "priceLabel";
        priceLabel.Size = new Size(37, 15);
        priceLabel.TabIndex = 1;
        priceLabel.Text = "Preço";
        // 
        // priceTextBox
        // 
        priceTextBox.Location = new Point(0, 19);
        priceTextBox.Margin = new Padding(0, 4, 0, 0);
        priceTextBox.MaximumValue = new decimal(new int[] { 276447231, 23283, 0, 131072 });
        priceTextBox.Name = "priceTextBox";
        priceTextBox.Size = new Size(104, 23);
        priceTextBox.TabIndex = 2;
        priceTextBox.Text = "0,00";
        priceTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // nameFlowLayoutPanel
        // 
        nameFlowLayoutPanel.AutoSize = true;
        nameFlowLayoutPanel.Controls.Add(nameLabel);
        nameFlowLayoutPanel.Controls.Add(nameTextBox);
        nameFlowLayoutPanel.Dock = DockStyle.Fill;
        nameFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
        nameFlowLayoutPanel.Location = new Point(0, 8);
        nameFlowLayoutPanel.Margin = new Padding(0, 8, 0, 8);
        nameFlowLayoutPanel.Name = "nameFlowLayoutPanel";
        nameFlowLayoutPanel.Size = new Size(768, 42);
        nameFlowLayoutPanel.TabIndex = 4;
        nameFlowLayoutPanel.WrapContents = false;
        // 
        // nameLabel
        // 
        nameLabel.AutoSize = true;
        nameLabel.Location = new Point(0, 0);
        nameLabel.Margin = new Padding(0);
        nameLabel.Name = "nameLabel";
        nameLabel.Size = new Size(40, 15);
        nameLabel.TabIndex = 1;
        nameLabel.Text = "Nome";
        // 
        // nameTextBox
        // 
        nameTextBox.Location = new Point(0, 19);
        nameTextBox.Margin = new Padding(0, 4, 0, 0);
        nameTextBox.Name = "nameTextBox";
        nameTextBox.Size = new Size(768, 23);
        nameTextBox.TabIndex = 2;
        // 
        // actionsFlowLayoutPanel
        // 
        actionsFlowLayoutPanel.AutoSize = true;
        actionsFlowLayoutPanel.Controls.Add(cancelButton);
        actionsFlowLayoutPanel.Controls.Add(saveButton);
        actionsFlowLayoutPanel.Dock = DockStyle.Right;
        actionsFlowLayoutPanel.Location = new Point(560, 251);
        actionsFlowLayoutPanel.Margin = new Padding(0);
        actionsFlowLayoutPanel.Name = "actionsFlowLayoutPanel";
        actionsFlowLayoutPanel.Size = new Size(208, 23);
        actionsFlowLayoutPanel.TabIndex = 7;
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
        // ProductForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 337);
        Controls.Add(mainTableLayoutPanel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ProductForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Produto";
        Load += ProductForm_Load;
        mainTableLayoutPanel.ResumeLayout(false);
        mainTableLayoutPanel.PerformLayout();
        fieldsTableLayoutPanel.ResumeLayout(false);
        fieldsTableLayoutPanel.PerformLayout();
        descriptionFlowLayoutPanel.ResumeLayout(false);
        descriptionFlowLayoutPanel.PerformLayout();
        priceFlowLayoutPanel.ResumeLayout(false);
        priceFlowLayoutPanel.PerformLayout();
        nameFlowLayoutPanel.ResumeLayout(false);
        nameFlowLayoutPanel.PerformLayout();
        actionsFlowLayoutPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    private TableLayoutPanel mainTableLayoutPanel;
    private Label titleLabel;
    private TableLayoutPanel fieldsTableLayoutPanel;
    private FlowLayoutPanel nameFlowLayoutPanel;
    private Label nameLabel;
    private TextBox nameTextBox;
    private FlowLayoutPanel descriptionFlowLayoutPanel;
    private Label descriptionLabel;
    private TextBox descriptionTextBox;
    private FlowLayoutPanel priceFlowLayoutPanel;
    private Label priceLabel;
    private FlowLayoutPanel actionsFlowLayoutPanel;
    private Button cancelButton;
    private Button saveButton;
    private Controls.CurrencyTextBox priceTextBox;
}