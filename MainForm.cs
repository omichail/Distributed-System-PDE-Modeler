using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceMatMod
{
    public partial class MainForm : Form
    {


        private List<string> initialConditions = new List<string>();
        private List<string> boundaryConditions = new List<string>();
        private List<string> uList = new List<string>();


        public MainForm()
        {
            InitializeComponent();


            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            progressBar1.Visible = false;


            comboBoxu.KeyDown += ComboBox_KeyPressed;


            textBoxL.Text = "∂_t^2-c^2*∂_x^2";
            textBoxG.Text = "H(t-r/c)/(2*c)";
            uList.Add("2*t*x^3-2*x^2-c*(2*t^3*x-2*t^2+6)");
            comboBoxu.Items.AddRange(uList.ToArray());
            comboBoxu.SelectedIndex = 0;

            numericUpDown_a.Value = 0;
            numericUpDown_b.Value = 8;
            numericUpDown_c.Value = 2;
            numericUpDown_T.Value = 5;
            numericUpDown_init.Value = 2;
            numericUpDown_bound.Value = 1;
        }



        private void ComboBox_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComboBox comboBox = (ComboBox)sender;
                string newValue = comboBox.Text.Trim();

                if (string.IsNullOrEmpty(newValue)) return;

                List<string> targetList;
                if (comboBox == comboBoxu)
                {
                    targetList = uList;
                }
                else
                {
                    return;
                }

                if (!targetList.Contains(newValue))
                {
                    targetList.Add(newValue);
                    comboBox.Items.Add(newValue);
                }

                comboBox.SelectedItem = newValue;
                e.Handled = true;
            }
        }



        private void numericUpDown_init_ValueChanged(object sender, EventArgs e)
        {
            int newCount = (int)numericUpDown_init.Value;


            while (initialConditions.Count < newCount)
            {
                initialConditions.Add(string.Empty);
            }
            while (initialConditions.Count > newCount)
            {
                initialConditions.RemoveAt(initialConditions.Count - 1);
            }

            int currentPairs = flowLayoutPanel_init.Controls.Count / 2;

            if (newCount > currentPairs)
            {
                for (int i = currentPairs; i < newCount; i++)
                {
                    Label label = new Label
                    {
                        Text = $"Initial_cond {i + 1}:",
                        Width = 120,

                    };
                    label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

                    TextBox textBox = new TextBox
                    {
                        Tag = i,
                        Width = 120,
                        Text = initialConditions.Count > i ? initialConditions[i] : ""
                    };
                    textBox.TextChanged += ConditionTextBox_TextChanged;
                    textBox.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

                    flowLayoutPanel_init.Controls.Add(label);
                    flowLayoutPanel_init.Controls.Add(textBox);
                }
            }
            else if (newCount < currentPairs)
            {
                int pairsToRemove = currentPairs - newCount;
                for (int i = 0; i < pairsToRemove; i++)
                {
                    int lastIndex = flowLayoutPanel_init.Controls.Count - 1;
                    flowLayoutPanel_init.Controls.RemoveAt(lastIndex);
                    flowLayoutPanel_init.Controls.RemoveAt(lastIndex - 1);
                }
            }
        }

        private void ConditionTextBox_TextChanged(object sender, EventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            int index = (int)textBox.Tag;
            if (index >= 0 && index < initialConditions.Count)
            {
                initialConditions[index] = textBox.Text.Trim();
            }
        }


        private void numericUpDown_bound_ValueChanged(object sender, EventArgs e)
        {
            int newCount = (int)numericUpDown_bound.Value;

            while (boundaryConditions.Count < newCount)
            {
                boundaryConditions.Add(string.Empty);
            }
            while (boundaryConditions.Count > newCount)
            {
                boundaryConditions.RemoveAt(boundaryConditions.Count - 1);
            }

            int currentPairs = flowLayoutPanel_bound.Controls.Count / 2;

            if (newCount > currentPairs)
            {
                for (int i = currentPairs; i < newCount; i++)
                {
                    Label label = new Label
                    {
                        Text = $"Bound_cond {i + 1}:",
                        Width = 120,
                    };
                    label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

                    TextBox textBox = new TextBox
                    {
                        Tag = i,
                        Width = 120,
                        Text = boundaryConditions.Count > i ? boundaryConditions[i] : ""
                    };
                    textBox.TextChanged += ConditionTextBox1_TextChanged;
                    textBox.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

                    flowLayoutPanel_bound.Controls.Add(label);
                    flowLayoutPanel_bound.Controls.Add(textBox);
                }
            }
            else if (newCount < currentPairs)
            {
                int pairsToRemove = currentPairs - newCount;
                for (int i = 0; i < pairsToRemove; i++)
                {
                    int lastIndex = flowLayoutPanel_bound.Controls.Count - 1;
                    flowLayoutPanel_bound.Controls.RemoveAt(lastIndex);
                    flowLayoutPanel_bound.Controls.RemoveAt(lastIndex - 1);
                }
            }
        }

        private void ConditionTextBox1_TextChanged(object sender, EventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            int index = (int)textBox.Tag;
            if (index >= 0 && index < boundaryConditions.Count)
            {
                boundaryConditions[index] = textBox.Text.Trim();
            }
        }

        private void SaveParametersToFile()
        {
            string uValue = comboBoxu.Text.Trim();
            if (string.IsNullOrEmpty(uValue))
            {
                MessageBox.Show("Поле u не може бути порожнім!", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal aValue = numericUpDown_a.Value;
            decimal bValue = numericUpDown_b.Value;
            decimal cValue = numericUpDown_c.Value;
            decimal tValue = numericUpDown_T.Value;

            try
            {
                string fileName = $"input.txt";
                string appFolder = Application.StartupPath;
                string fullPath = Path.Combine(appFolder, fileName);

                using (StreamWriter writer = new StreamWriter(fullPath))
                {
                    writer.WriteLine($"a: {aValue.ToString(CultureInfo.InvariantCulture)}");
                    writer.WriteLine($"b: {bValue.ToString(CultureInfo.InvariantCulture)}");
                    writer.WriteLine($"c: {cValue.ToString(CultureInfo.InvariantCulture)}");
                    writer.WriteLine($"T: {tValue.ToString(CultureInfo.InvariantCulture)}");
                    writer.WriteLine($"u: {uValue}");

                    writer.WriteLine($"Initial Conditions: {string.Join(", ", initialConditions)}");


                    writer.WriteLine($"Boundary Conditions: {string.Join(", ", boundaryConditions)}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження файлу: {ex.Message}", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RunPythonScript()
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "python.exe",
                    Arguments = "script.py",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(psi))
                {
                    process.OutputDataReceived += (s, e) => {
                        if (e.Data == null) return;
                        if (e.Data.StartsWith("INPUT_REQUIRED"))
                        {
                            var parts = e.Data.Split(' ');
                            int N = int.Parse(parts[1]);

                            this.Invoke((Action)(() => {
                                string input = ShowVectorInputDialog(N);
                                process.StandardInput.WriteLine(input);
                            }));
                        }
                        else
                        {
                            Console.WriteLine(e.Data);
                        }
                    };

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    process.WaitForExit();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Не вдалося запустити script.py: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ShowVectorInputDialog(int N)
        {
            using (var form = new Form())
            {
                form.Width = 400;
                form.Height = 160;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.Text = $"Введіть вектор з {N} елементів";
                form.StartPosition = FormStartPosition.CenterParent;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ShowInTaskbar = true;


                var lbl = new Label()
                {
                    Left = 10,
                    Top = 10,
                    Width = 360,
                    Text = $"Будь ласка, введіть {N} чисел, розділених пробілом:"
                };
                form.Controls.Add(lbl);

                var txt = new TextBox()
                {
                    Left = 10,
                    Top = 35,
                    Width = 360
                };
                form.Controls.Add(txt);

                var btnOK = new Button()
                {
                    Text = "OK",
                    Left = 200,
                    Width = 80,
                    Top = 70,
                    DialogResult = DialogResult.OK
                };
                var btnCancel = new Button()
                {
                    Text = "Cancel",
                    Left = 290,
                    Width = 80,
                    Top = 70,
                    DialogResult = DialogResult.Cancel
                };
                form.Controls.Add(btnOK);
                form.Controls.Add(btnCancel);

                form.AcceptButton = btnOK;
                form.CancelButton = btnCancel;

                while (true)
                {
                    if (form.ShowDialog() != DialogResult.OK)
                        return null;

                    var parts = txt.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != N)
                    {
                        MessageBox.Show(
                            form,
                            $"Ви маєте ввести саме {N} чисел, наразі введено {parts.Length}. Спробуйте ще раз.",
                            "Невірний ввід",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        continue;
                    }

                    bool allOk = parts.All(p => double.TryParse(p, out _));
                    if (!allOk)
                    {
                        MessageBox.Show(
                            form,
                            "У введеному рядку є нечислові значення. Перевірте і спробуйте знову.",
                            "Невірний ввід",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        continue;
                    }

                    return txt.Text.Trim();
                }
            }
        }

        private void LoadOutputToTextBox()
        {
            try
            {
                string appFolder = Application.StartupPath;
                string filePath = Path.Combine(appFolder, "output.txt");

                if (!File.Exists(filePath))
                {
                    return;
                }
                string[] lines = File.ReadAllLines(filePath);

                var yLines = new List<string>();
                string epsValue = string.Empty;
                bool isEpsSection = false;

                foreach (var line in lines)
                {
                    if (line.TrimStart().StartsWith("# eps"))
                    {
                        isEpsSection = true;
                        continue;
                    }

                    if (isEpsSection)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            epsValue = line.Trim();
                            break;
                        }
                    }
                    else
                    {
                        yLines.Add(line);
                    }
                }

                // Заповнюємо відповідні TextBox-и
                textBoxY.Text = string.Join(Environment.NewLine, yLines);

                // Якщо eps знайдено — показуємо, інакше чистимо
                textBoxEps.Text = string.IsNullOrEmpty(epsValue)
                    ? "eps не знайдено в файлі"
                    : epsValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка читання output.txt: {ex.Message}",
                                "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RunPlotScript()
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = "plot.py",

                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!AreInitialConditionsValid())
            {
                MessageBox.Show("Заповніть всі початкові умови!", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!AreBoundaryConditionsValid())
            {
                MessageBox.Show("Заповніть всі граничні умови!", "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveParametersToFile();
            progressBar1.Visible = true;
            try
            {
                await Task.Run(() => RunPythonScript());
                Invoke(new Action(() =>
                {
                    progressBar1.Visible = false;
                }));
            }
            finally
            {
                progressBar1.Visible = false;
            }


            LoadOutputToTextBox();
            RunPlotScript();
        }

        private bool AreInitialConditionsValid()
        {
            bool isValid = true;

            foreach (Control control in flowLayoutPanel_init.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.BackColor = Color.LightPink;
                        isValid = false;
                    }
                    else
                    {
                        textBox.BackColor = SystemColors.Window;
                    }
                }
            }

            return isValid;
        }
        private bool AreBoundaryConditionsValid()
        {
            bool isValid = true;

            foreach (Control control in flowLayoutPanel_bound.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.BackColor = Color.LightPink;
                        isValid = false;
                    }
                    else
                    {
                        textBox.BackColor = SystemColors.Window;
                    }
                }
            }

            return isValid;
        }


    }
}