using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonDuplicatesSearcher.Controls;

namespace JsonDuplicatesSearcher
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private async void btnSearchDuplicates_Click(object sender, EventArgs e)
        {
            string[] comparisonFields = GetComparisonFields();         
            try
            {
                JsonElements jsonElements = await GetJsonElementsAsync();
                JsonElement[] duplicates = jsonElements.SearchForDuplicates(comparisonFields);

                if (duplicates.Length == 0)
                {
                    MessageBox.Show("Duplicates are not found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ShowJsonDuplicates(duplicates);
            }
            catch (Exception ex)
            {            
                MessageBox.Show(ex.Message, $"Error ({ex.Source})", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string[] GetComparisonFields()
        {
            return rtbFiels.Text
                .Trim()
                .Split(';');
        }

        private async Task<JsonElements> GetJsonElementsAsync()
        {
            JsonElements jsonElements = jtb.GetJsonElements();

            await jsonElements.BuildAsync();

            return jsonElements;
        }

        private void ShowJsonDuplicates(JsonElement[] duplicates)
        {
            var foundDuplicates = new FoundDuplicates(duplicates);

            foundDuplicates.ShowDialog();
        }
    }
}