using JsonDuplicatesSearcher.Controls;
using System.Windows.Forms;

namespace JsonDuplicatesSearcher
{
    public partial class FoundDuplicates : Form
    {
        public FoundDuplicates(JsonElement[] jsonElements)
        {
            InitializeComponent();

            jtb.SetJson(jsonElements);
        }
    }
}
