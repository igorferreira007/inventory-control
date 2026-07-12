using System.ComponentModel;
using System.Globalization;

namespace InventoryControl.Presentation.Controls;

public class CurrencyTextBox : TextBox
{
    private static readonly CultureInfo PtBr =
        CultureInfo.GetCultureInfo("pt-BR");

    private long _valueInCents;
    private bool _receivedFocusByMouse;

    public CurrencyTextBox()
    {
        TextAlign = HorizontalAlignment.Right;
        ShortcutsEnabled = true;

        UpdateDisplayedText();
    }

    public decimal MaximumValue { get; set; } =
        999_999_999_999.99m;

    [Browsable(false)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Hidden)]
    public decimal Value
    {
        get => _valueInCents / 100m;

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "O valor não pode ser negativo.");
            }

            if (value > MaximumValue)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    $"O valor máximo permitido é {MaximumValue:N2}.");
            }

            decimal roundedValue = decimal.Round(
                value,
                2,
                MidpointRounding.AwayFromZero);

            _valueInCents = decimal.ToInt64(
                roundedValue * 100m);

            UpdateDisplayedText();
        }
    }

    protected override void OnEnter(EventArgs e)
    {
        base.OnEnter(e);

        _receivedFocusByMouse =
            Control.MouseButtons == MouseButtons.Left;

        if (!_receivedFocusByMouse)
        {
            MoveCaretToEnd();
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

        if (!_receivedFocusByMouse)
        {
            return;
        }

        _receivedFocusByMouse = false;

        if (SelectionLength == 0)
        {
            MoveCaretToEnd();
        }
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if (e.KeyChar >= '0' && e.KeyChar <= '9')
        {
            e.Handled = true;

            int digit = e.KeyChar - '0';

            AddDigit(digit);
            UpdateDisplayedText();

            base.OnKeyPress(e);
            return;
        }

        if (e.KeyChar == (char)Keys.Back)
        {
            e.Handled = true;

            _valueInCents /= 10;

            UpdateDisplayedText();

            base.OnKeyPress(e);
            return;
        }

        // Bloqueia letras, vírgula, ponto e outros caracteres.
        e.Handled = true;

        base.OnKeyPress(e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.C)
        {
            CopySelectedText();

            e.Handled = true;
            e.SuppressKeyPress = true;
            return;
        }

        if (e.Control && e.KeyCode == Keys.X)
        {
            CutSelectedText();

            e.Handled = true;
            e.SuppressKeyPress = true;

            base.OnKeyDown(e);
            return;
        }

        if (e.Control && e.KeyCode == Keys.V)
        {
            PastePrice();

            e.Handled = true;
            e.SuppressKeyPress = true;

            base.OnKeyDown(e);
            return;
        }

        if (e.KeyCode == Keys.Delete)
        {
            ClearValue();

            e.Handled = true;
            e.SuppressKeyPress = true;

            base.OnKeyDown(e);
            return;
        }

        base.OnKeyDown(e);
    }

    public void ClearValue()
    {
        _valueInCents = 0;

        UpdateDisplayedText();
    }

    private void AddDigit(int digit)
    {
        long maximumValueInCents =
            decimal.ToInt64(MaximumValue * 100m);

        // Evita ultrapassar o máximo e também evita overflow.
        if (maximumValueInCents < digit)
        {
            return;
        }

        if (_valueInCents >
            (maximumValueInCents - digit) / 10)
        {
            return;
        }

        _valueInCents =
            (_valueInCents * 10) + digit;
    }

    private void CopySelectedText()
    {
        if (SelectionLength == 0)
        {
            return;
        }

        Clipboard.SetText(SelectedText);
    }

    private void PastePrice()
    {
        if (!Clipboard.ContainsText())
        {
            return;
        }

        string pastedText =
            Clipboard.GetText().Trim();

        if (!TrySetValueFromText(pastedText))
        {
            MessageBox.Show(
                "O conteúdo copiado não representa um preço válido.",
                "Preço inválido",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private void CutSelectedText()
    {
        if (SelectionLength == 0)
        {
            return;
        }

        Clipboard.SetText(SelectedText);

        int selectionStart = SelectionStart;
        int selectionLength = SelectionLength;

        string remainingText = Text.Remove(
            selectionStart,
            selectionLength);

        if (string.IsNullOrWhiteSpace(remainingText))
        {
            ClearValue();
            return;
        }

        if (!TrySetValueFromText(remainingText))
        {
            ClearValue();
        }
    }

    private bool TrySetValueFromText(string text)
    {
        if (!decimal.TryParse(
                text,
                NumberStyles.Currency,
                PtBr,
                out decimal value))
        {
            return false;
        }

        if (value < 0 || value > MaximumValue)
        {
            return false;
        }

        Value = value;

        return true;
    }

    private void UpdateDisplayedText()
    {
        Text = Value.ToString("N2", PtBr);

        MoveCaretToEnd();
    }

    private void MoveCaretToEnd()
    {
        SelectionStart = TextLength;
        SelectionLength = 0;
    }
}
