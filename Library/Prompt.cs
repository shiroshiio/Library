using System;
using System.Windows.Forms;

namespace Inventario.Vistas
{
    public class Prompt : Form
    {
        private Label label;
        private TextBox textBox;
        private Button buttonOk;
        private Button buttonCancel;

        public string InputText { get; private set; }

        public Prompt(string text, string caption, string defaultValue = "")
        {
            label = new Label { Text = text, Left = 10, Top = 10, Width = 300 };
            textBox = new TextBox { Left = 10, Top = 40, Width = 300, Text = defaultValue };
            buttonOk = new Button { Text = "OK", Left = 10, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            buttonCancel = new Button { Text = "Cancelar", Left = 120, Width = 100, Top = 70, DialogResult = DialogResult.Cancel };

            buttonOk.Click += (sender, e) => { InputText = textBox.Text; };

            Controls.Add(label);
            Controls.Add(textBox);
            Controls.Add(buttonOk);
            Controls.Add(buttonCancel);

            this.AcceptButton = buttonOk;
            this.CancelButton = buttonCancel;

            this.Text = caption;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        // Método estático para mostrar el prompt
        public static string ShowDialog(string text, string caption, string defaultValue = "")
        {
            using (Prompt prompt = new Prompt(text, caption, defaultValue))
            {
                return prompt.ShowDialog() == DialogResult.OK ? prompt.InputText : string.Empty;
            }
        }
    }
}
