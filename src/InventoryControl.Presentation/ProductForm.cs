using InventoryControl.Application.DTOs;
using InventoryControl.Application.UseCases;
using System.Globalization;

namespace InventoryControl.Presentation;

public partial class ProductForm : Form
{
    private readonly CreateProductUseCase? _createProductUseCase;

    public ProductForm()
    {
        InitializeComponent();
    }

    public ProductForm(CreateProductUseCase createProductUseCase) : this()
    {
        _createProductUseCase = createProductUseCase;
    }

    private async void saveButton_Click(object sender, EventArgs e)
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

        DialogResult = DialogResult.OK;
        Close();
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
