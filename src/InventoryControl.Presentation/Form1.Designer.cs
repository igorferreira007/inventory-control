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
        listProductsButton = new Button();
        productsDataGridView = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)productsDataGridView).BeginInit();
        SuspendLayout();
        // 
        // listProductsButton
        // 
        listProductsButton.Location = new Point(609, 55);
        listProductsButton.Name = "listProductsButton";
        listProductsButton.Size = new Size(106, 23);
        listProductsButton.TabIndex = 0;
        listProductsButton.Text = "Listar produtos";
        listProductsButton.UseVisualStyleBackColor = true;
        listProductsButton.Click += listProductsButton_Click;
        // 
        // productsDataGridView
        // 
        productsDataGridView.AllowUserToAddRows = false;
        productsDataGridView.AllowUserToDeleteRows = false;
        productsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        productsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        productsDataGridView.Location = new Point(88, 84);
        productsDataGridView.Name = "productsDataGridView";
        productsDataGridView.ReadOnly = true;
        productsDataGridView.Size = new Size(627, 297);
        productsDataGridView.TabIndex = 1;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(productsDataGridView);
        Controls.Add(listProductsButton);
        Name = "Form1";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)productsDataGridView).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button listProductsButton;
    private DataGridView productsDataGridView;
}
