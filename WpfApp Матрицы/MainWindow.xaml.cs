using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_Матрицы
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTranspose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<List<int>> matrix = GetMatrixFromTextBox(txtMatrix);
                List<List<int>> transposedMatrix = MatrixUtils.TransposeMatrix(matrix);

                txtTransposedMatrix.Text = GetMatrixString(transposedMatrix);
                txtResult.Text = "Транспонирование выполнено!";
            }
            catch (Exception ex)
            {
                txtResult.Text = $"Ошибка: {ex.Message}";
            }
        }

        private List<List<int>> GetMatrixFromTextBox(TextBox textBox)
        {
            string[] rows = textBox.Text.Split('\n');
            List<List<int>> matrix = new List<List<int>>();

            foreach (string row in rows)
            {
                List<int> numbers = row.Split(' ').Select(int.Parse).ToList();
                matrix.Add(numbers);
            }

            return matrix;
        }

        private string GetMatrixString(List<List<int>> matrix)
        {
            string matrixString = "";
            foreach (List<int> row in matrix)
            {
                matrixString += string.Join(" ", row) + "\n";
            }
            return matrixString.TrimEnd('\n');
        }
    }

    public static class MatrixUtils
    {
        public static List<List<int>> TransposeMatrix(List<List<int>> matrix)
        {
            int rows = matrix.Count;
            int cols = matrix[0].Count;
            List<List<int>> transposedMatrix = new List<List<int>>();

            for (int j = 0; j < cols; j++)
            {
                List<int> newRow = new List<int>();
                for (int i = 0; i < rows; i++)
                {
                    newRow.Add(matrix[i][j]);
                }
                transposedMatrix.Add(newRow);
            }

            return transposedMatrix;
        }
    }
}