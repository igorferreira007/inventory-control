using InventoryControl.Application.DTOs;
using InventoryControl.Application.UseCases;

namespace InventoryControl.Presentation;

public partial class StockMovementForm : Form
{
    private readonly IncreaseProductStockUseCase? _increaseProductStockUseCase;
    private readonly DecreaseProductStockUseCase? _decreaseProductStockUseCase;
    private readonly GetProductUseCase? _getProductUseCase;

    private readonly long? _productId;

    public StockMovementForm()
    {
        InitializeComponent();
    }

    public StockMovementForm(
        long productId,
        IncreaseProductStockUseCase increaseProductStockUseCase,
        GetProductUseCase getProductUseCase) : this()
    {
        _productId = productId;
        _increaseProductStockUseCase = increaseProductStockUseCase;
        _getProductUseCase = getProductUseCase;

        productLabel.Text = $"Produto - Id: {productId}";
        titleLabel.Text = "Entrada de Estoque";
        titleLabel.ForeColor = Color.ForestGreen;
    }

    public StockMovementForm(
        long productId,
        DecreaseProductStockUseCase decreaseProductStockUseCase,
        GetProductUseCase getProductUseCase) : this()
    {
        _productId = productId;
        _decreaseProductStockUseCase = decreaseProductStockUseCase;
        _getProductUseCase = getProductUseCase;

        productLabel.Text = $"Produto - Id: {productId}";
        titleLabel.Text = "Saída de Estoque";
        titleLabel.ForeColor = Color.Red;
    }

    private async Task LoadProductAsync(long productId)
    {
        if (_getProductUseCase is null)
        {
            MessageBox.Show(
                "Use case não foi carregado pela injeção de dependência.",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        var request = new GetProductRequestDto(productId);

        var result = await _getProductUseCase.Execute(request);

        if (result.IsFailure)
        {
            MessageBox.Show(
                result.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            if (result.Message == "Produto não encontrado.")
            {
                DialogResult = DialogResult.OK;
                Close();

                return;
            }

            DialogResult = DialogResult.Cancel;
            Close();

            return;
        }

        var product = result.Value!;

        productNameLabel.Text = product.Name;
    }

    private async void StockMovementForm_Load(object sender, EventArgs e)
    {
        if (_productId is not null)
            await LoadProductAsync(_productId.Value);
    }

    private async void saveButton_Click(object sender, EventArgs e)
    {
        if (_decreaseProductStockUseCase is not null)
        {
            await DecreaseProductStockAsync();

            return;
        }

        await IncreaseProductStockAsync();
    }

    private async Task DecreaseProductStockAsync()
    {
        if (_decreaseProductStockUseCase is null)
        {
            MessageBox.Show(
                "Use case não foi carregado pela injeção de dependência.",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        var quantity = (int)quantityNumericUpDown.Value;
        var productId = _productId!.Value;

        var request = new DecreaseProductStockRequestDto(productId, quantity);

        var result = await _decreaseProductStockUseCase.Execute(request);

        if (result.IsFailure)
        {
            MessageBox.Show(
                this,
                result.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        MessageBox.Show(
            "Quantidade removida com sucesso.",
            "Sucesso",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        DialogResult = DialogResult.OK;
        Close();
    }

    private async Task IncreaseProductStockAsync()
    {
        if (_increaseProductStockUseCase is null)
        {
            MessageBox.Show(
                "Use case não foi carregado pela injeção de dependência.",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        var quantity = (int)quantityNumericUpDown.Value;
        var productId = _productId!.Value;

        var request = new IncreaseProductStockRequestDto(productId, quantity);

        var result = await _increaseProductStockUseCase.Execute(request);

        if (result.IsFailure)
        {
            MessageBox.Show(
                this,
                result.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        MessageBox.Show(
            "Quantidade adicionada com sucesso.",
            "Sucesso",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        DialogResult = DialogResult.OK;
        Close();
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
