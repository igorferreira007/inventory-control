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
        checkBox1 = new CheckBox();
        currencyTextBox1 = new InventoryControl.Presentation.Controls.CurrencyTextBox();
        SuspendLayout();
        // 
        // checkBox1
        // 
        checkBox1.AutoSize = true;
        checkBox1.Location = new Point(224, 305);
        checkBox1.Name = "checkBox1";
        checkBox1.Size = new Size(82, 19);
        checkBox1.TabIndex = 1;
        checkBox1.Text = "checkBox1";
        checkBox1.UseVisualStyleBackColor = true;
        // 
        // currencyTextBox1
        // 
        currencyTextBox1.Location = new Point(192, 118);
        currencyTextBox1.MaximumValue = new decimal(new int[] { 276447231, 23283, 0, 131072 });
        currencyTextBox1.Name = "currencyTextBox1";
        currencyTextBox1.Size = new Size(100, 23);
        currencyTextBox1.TabIndex = 2;
        currencyTextBox1.TextAlign = HorizontalAlignment.Right;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(currencyTextBox1);
        Controls.Add(checkBox1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private CheckBox checkBox1;
    private Controls.CurrencyTextBox currencyTextBox1;
}
