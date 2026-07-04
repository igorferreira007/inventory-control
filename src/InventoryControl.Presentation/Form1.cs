using InventoryControl.Application.DTOs;
using InventoryControl.Application.UseCases;

namespace InventoryControl.Presentation;

public partial class Form1 : Form
{
    private readonly ListProductsUseCase? _listProductsUseCase;

    public Form1()
    {
        InitializeComponent();
    }

    public Form1(ListProductsUseCase listProductsUseCase) : this()
    {
        _listProductsUseCase = listProductsUseCase;
    }

    private async void listProductsButton_Click(object sender, EventArgs e)
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
            PageSize: 20);

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
}
