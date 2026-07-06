using InventoryControl.Application.DTOs;
using InventoryControl.Application.UseCases;

namespace InventoryControl.Presentation;

public partial class MainForm : Form
{
    private readonly ListProductsUseCase? _listProductsUseCase;

    public MainForm()
    {
        InitializeComponent();
    }

    public MainForm(ListProductsUseCase listProductsUseCase) : this()
    {
        _listProductsUseCase = listProductsUseCase;
    }

    private void bottomPanel_Resize(object sender, EventArgs e)
    {
        if (this.ClientSize.Width > bottomPanel.MaximumSize.Width)
        {
            bottomPanel.Anchor = AnchorStyles.Top;
            bottomPanel.Width = 1280 - 32;
            bottomPanel.Left = (this.ClientSize.Width - bottomPanel.Width) / 2;
        }
        else
        {
            bottomPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }
    }

    private void topPanel_Resize(object sender, EventArgs e)
    {
        if (this.ClientSize.Width > topPanel.MaximumSize.Width)
        {
            topPanel.Anchor = AnchorStyles.Top;
            topPanel.Width = 1280 - 32;
            topPanel.Left = (this.ClientSize.Width - topPanel.Width) / 2;
        }
        else
        {
            topPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        await LoadProductAsync();
    }

    private async Task LoadProductAsync()
    {
        if (_listProductsUseCase is null)
        {
            MessageBox.Show(
                "Use case não foi carregado pela injeção de dependência.",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        var request = new ListProductsRequestDto(
            PageNumber: 1,
            PageSize: 20,
            SearchTerm: searchProductTextBox.Text);

        var result = await _listProductsUseCase.Execute(request);

        if (result.IsFailure)
        {
            MessageBox.Show(
                result.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        productsDataGridView.DataSource = result.Value!.Products.ToList();
    }

    private async void searchProductButton_Click(object sender, EventArgs e)
    {
        await LoadProductAsync();
    }

    private async void searchProductTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
            return;

        await LoadProductAsync();
    }

    private void searchProductTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true;
        }
    }
}
