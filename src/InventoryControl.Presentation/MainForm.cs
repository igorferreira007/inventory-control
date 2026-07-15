using InventoryControl.Application.DTOs;
using InventoryControl.Application.UseCases;

namespace InventoryControl.Presentation;

public partial class MainForm : Form
{
    private readonly ListProductsUseCase? _listProductsUseCase;
    private readonly CreateProductUseCase? _createProductUseCase;
    private readonly UpdateProductUseCase? _updateProductUseCase;
    private readonly GetProductUseCase? _getProductUseCase;
    private readonly DeleteProductUseCase? _deleteProductUseCase;

    public MainForm()
    {
        InitializeComponent();
    }

    public MainForm(
        ListProductsUseCase listProductsUseCase,
        CreateProductUseCase createProductUseCase,
        UpdateProductUseCase? updateProductUseCase,
        GetProductUseCase? getProductUseCase,
        DeleteProductUseCase? deleteProductUseCase) : this()
    {
        _listProductsUseCase = listProductsUseCase;
        _createProductUseCase = createProductUseCase;
        _updateProductUseCase = updateProductUseCase;
        _getProductUseCase = getProductUseCase;
        _deleteProductUseCase = deleteProductUseCase;
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

    private async void newProductButton_Click(object sender, EventArgs e)
    {
        if (_createProductUseCase is null)
        {
            MessageBox.Show(
                "Use case não foi carregado pela injeção de dependência.",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        using var productForm = new ProductForm(_createProductUseCase);

        var result = productForm.ShowDialog(this);

        if (result == DialogResult.OK)
            await LoadProductAsync();
    }

    private long? GetSelectedProductId()
    {
        if (productsDataGridView.CurrentRow is null)
            return null;

        var product = productsDataGridView.CurrentRow.DataBoundItem as ProductResponseDto;

        return product?.Id;
    }

    private async void editProductButton_Click(object sender, EventArgs e)
    {
        if (_getProductUseCase is null || _updateProductUseCase is null)
        {
            MessageBox.Show(
                "Use cases não foram carregados pela injeção de dependência.",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        var productId = GetSelectedProductId();

        if (productId is null)
        {
            MessageBox.Show(
                "Selecione um produto para editar.",
                "Atenção",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        using var productForm = new ProductForm(
            productId.Value,
            _updateProductUseCase,
            _getProductUseCase);

        var result = productForm.ShowDialog(this);

        if (result == DialogResult.OK)
            await LoadProductAsync();
    }

    private async void deleteProductButton_Click(object sender, EventArgs e)
    {
        if (_deleteProductUseCase is null)
        {
            MessageBox.Show(
                 "Use cases não foram carregados pela injeção de dependência.",
                 "Erro",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error);

            return;
        }

        var productId = GetSelectedProductId();

        if (productId is null)
        {
            MessageBox.Show(
                "Selecione um produto para excluir.",
                "Atenção",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        var confirmation = MessageBox.Show(
            "Deseja realmente excluir o produto?",
            "Confirmar exclusão",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (confirmation != DialogResult.Yes)
            return;

        var request = new DeleteProductRequestDto(productId.Value);

        var result = await _deleteProductUseCase.Execute(request);

        if (result.IsFailure)
        {
            MessageBox.Show(
                result.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            await LoadProductAsync();

            return;
        }

        MessageBox.Show(
                "Produto excluído com sucesso.",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        await LoadProductAsync();
    }
}
