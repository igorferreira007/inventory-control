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

    private async void listProductsButton_Click_1(object sender, EventArgs e)
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

    private void panel1_Resize(object sender, EventArgs e)
    {
        // Se o formulário ficou maior que o tamanho máximo do painel
        if (this.ClientSize.Width > panel1.MaximumSize.Width)
        {
            // Remove as âncoras laterais para ele poder "flutuar" no centro
            panel1.Anchor = AnchorStyles.Top;
            panel1.Width = 1280 - 32;
            // Centraliza manualmente o painel na tela
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
        }
        else
        {
            // Se a tela for menor que 1280px, ele volta a esticar grudado nas bordas
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }
    }
}
