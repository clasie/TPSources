using SideClientWebServiceComptaPlus.ViewModels;
using System.Windows.Controls;

namespace SideClientWebServiceComptaPlus
{
    /// <summary>
    /// Objet de simulation du Web Service SIDE 
    /// </summary>
    public partial class WebServicePutD365 : UserControl
    {
        public WebServicePutD365()
        {
            InitializeComponent();
            DataContext = new WebServicePutD365ViewModel(); 
        }
    }
}
