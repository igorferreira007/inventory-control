using InventoryControl.Application.DTOs;
using InventoryControl.Application.UseCases;
using System.Globalization;

namespace InventoryControl.Presentation;

public partial class ProductForm : Form
{
    private readonly CreateProductUseCase? _createProductUseCase;
    private readonly UpdateProductUseCase? _updateProductUseCase;
    private readonly GetProductUseCase? _getProductUseCase;

    private readonly long? _productId;

    public ProductForm()
    {
        InitializeComponent();
    }

    public ProductForm(CreateProductUseCase createProductUseCase) : this()
    {
        _createProductUseCase = createProductUseCase;

        Text = "Novo Produto";
        titleLabel.Text = "Cadastro de Produto";
    }

    public ProductForm(
        long productId,
        UpdateProductUseCase updateProductUseCase,
        GetProductUseCase getProductUseCase) : this()
    {
        _productId = productId;
        _updateProductUseCase = updateProductUseCase;
        _getProductUseCase = getProductUseCase;

        Text = "Editar Produto";
        titleLabel.Text = "Editar de Produto";
    }

    private async void saveButton_Click(object sender, EventArgs e)
    {
        if (_productId is null)
        {
            await CreateProductAsync();
            return;
        }

        await UpdateProductAsync();
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private async void ProductForm_Load(object sender, EventArgs e)
    {
        if (_productId is not null)
            await LoadProductAsync(_productId.Value);
    }

    private async Task CreateProductAsync()
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

        if (!decimal.TryParse(priceTextBox.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out var price))
        {
            MessageBox.Show(
                "Preço inválido.",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        var name = nameTextBox.Text;
        var description = descriptionTextBox.Text;

        var request = new CreateProductRequestDto(name, price, description);

        var result = await _createProductUseCase.Execute(request);

        if (result.IsFailure)
        {
            MessageBox.Show(
                result.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        MessageBox.Show(
            "Produto salvo com sucesso.",
            "Sucesso",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        DialogResult = DialogResult.OK;
        Close();
    }

    private async Task UpdateProductAsync()
    {
        if (_updateProductUseCase is null || _getProductUseCase is null)
        {
            MessageBox.Show(
                "Use case não foi carregado pela injeção de dependência.",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        if (!decimal.TryParse(priceTextBox.Text, out var price))
        {
            MessageBox.Show(
                "Preço inválido.",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        var productId = _productId!.Value;
        var name = nameTextBox.Text;
        var description = descriptionTextBox.Text;

        var request = new UpdateProductRequestDto(
            productId,
            name,
            price,
            description);

        var result = await _updateProductUseCase.Execute(request);

        if (result.IsFailure)
        {
            MessageBox.Show(
                result.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        MessageBox.Show(
            "Produto salvo com sucesso.",
            "Sucesso",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        DialogResult = DialogResult.OK;
        Close();
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

            DialogResult = DialogResult.Cancel;
            Close();

            return;
        }

        var product = result.Value!;

        nameTextBox.Text = product.Name;
        priceTextBox.Text = product.Price.ToString("N2");
        descriptionTextBox.Text = product.Description;
    }
}
