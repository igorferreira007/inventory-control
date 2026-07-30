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
    private readonly IncreaseProductStockUseCase? _increaseProductStockUseCase;
    private readonly DecreaseProductStockUseCase? _decreaseProductStockUseCase;

    private const int pageSize = 50;
    private int _currentPageNumber = 1;
    private int _totalPages = 1;

    public MainForm()
    {
        InitializeComponent();
    }

    public MainForm(
        ListProductsUseCase listProductsUseCase,
        CreateProductUseCase createProductUseCase,
        UpdateProductUseCase updateProductUseCase,
        GetProductUseCase getProductUseCase,
        DeleteProductUseCase deleteProductUseCase,
        IncreaseProductStockUseCase increaseProductStockUseCase,
        DecreaseProductStockUseCase decreaseProductStockUseCase) : this()
    {
        _listProductsUseCase = listProductsUseCase;
        _createProductUseCase = createProductUseCase;
        _updateProductUseCase = updateProductUseCase;
        _getProductUseCase = getProductUseCase;
        _deleteProductUseCase = deleteProductUseCase;
        _increaseProductStockUseCase = increaseProductStockUseCase;
        _decreaseProductStockUseCase = decreaseProductStockUseCase;
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
        await LoadProductsAsync();
    }

    private async Task LoadProductsAsync()
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
            PageNumber: _currentPageNumber,
            PageSize: pageSize,
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

        var (products, totalItems) = result.Value!;

        productsDataGridView.DataSource = products.ToList();

        ConfigureProductsDataGridViewColumns();

        var totalPages = totalItems == 0 ? 1 : (int)Math.Ceiling(totalItems / (double)pageSize);
        _totalPages = totalPages;

        currentPageLabel.Text = $"Página {_currentPageNumber} / {totalPages}";

        previousPageButton.Enabled = _currentPageNumber > 1;
        nextPageButton.Enabled = _currentPageNumber < totalPages;
        totalItemsLabel.Text = $"Total de produtos: {totalItems}";
    }

    private void ConfigureProductsDataGridViewColumns()
    {
        if (productsDataGridView.Columns.Count == 0)
            return;

        productsDataGridView.Columns[nameof(ProductResponseDto.Id)].HeaderText = "Código";
        productsDataGridView.Columns[nameof(ProductResponseDto.Name)].HeaderText = "Nome";
        productsDataGridView.Columns[nameof(ProductResponseDto.Price)].HeaderText = "Preço";
        productsDataGridView.Columns[nameof(ProductResponseDto.StockQuantity)].HeaderText = "Estoque";
        productsDataGridView.Columns[nameof(ProductResponseDto.Description)].HeaderText = "Descrição";
        productsDataGridView.Columns[nameof(ProductResponseDto.CreatedAt)].HeaderText = "Criado em";

        productsDataGridView.Columns[nameof(ProductResponseDto.Price)]
        .DefaultCellStyle.Format = "C2";

        productsDataGridView.Columns[nameof(ProductResponseDto.CreatedAt)]
            .DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

        productsDataGridView.Columns[nameof(ProductResponseDto.Id)].FillWeight = 25;
        productsDataGridView.Columns[nameof(ProductResponseDto.Name)].FillWeight = 250;
        productsDataGridView.Columns[nameof(ProductResponseDto.Price)].FillWeight = 50;
        productsDataGridView.Columns[nameof(ProductResponseDto.StockQuantity)].FillWeight = 30;
        productsDataGridView.Columns[nameof(ProductResponseDto.Description)].FillWeight = 250;
        productsDataGridView.Columns[nameof(ProductResponseDto.CreatedAt)].FillWeight = 50;
    }

    private async void searchProductButton_Click(object sender, EventArgs e)
    {
        _currentPageNumber = 1;

        await LoadProductsAsync();
    }

    private async void searchProductTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
            return;

        _currentPageNumber = 1;

        await LoadProductsAsync();
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
            await LoadProductsAsync();
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
            await LoadProductsAsync();
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

            await LoadProductsAsync();

            return;
        }

        MessageBox.Show(
                "Produto excluído com sucesso.",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        await LoadProductsAsync();
    }

    private async void increaseStockButton_Click(object sender, EventArgs e)
    {
        if (_increaseProductStockUseCase is null || _getProductUseCase is null)
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
                "Selecione um produto para aumentar estoque.",
                "Atenção",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        using var stockMovementForm = new StockMovementForm(
            productId.Value,
            _increaseProductStockUseCase,
            _getProductUseCase);

        var result = stockMovementForm.ShowDialog(this);

        if (result == DialogResult.OK)
            await LoadProductsAsync();
    }

    private async void decreaseStockButton_Click(object sender, EventArgs e)
    {
        if (_decreaseProductStockUseCase is null || _getProductUseCase is null)
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
                "Selecione um produto para diminuir estoque.",
                "Atenção",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        using var stockMovementForm = new StockMovementForm(
            productId.Value,
            _decreaseProductStockUseCase,
            _getProductUseCase);

        var result = stockMovementForm.ShowDialog(this);

        if (result == DialogResult.OK)
            await LoadProductsAsync();
    }

    private async void previousPageButton_Click(object sender, EventArgs e)
    {
        if (_currentPageNumber == 1)
            return;

        _currentPageNumber--;

        await LoadProductsAsync();
    }

    private async void nextPageButton_Click(object sender, EventArgs e)
    {
        if (_currentPageNumber == _totalPages)
            return;

        _currentPageNumber++;

        await LoadProductsAsync();
    }
}
