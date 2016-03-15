using System.Threading.Tasks;
using Xamarin.Forms;
using AppLar.Core.ViewModel;

namespace AppLar.Core.Page
{
    class MedicamentoPage
        : ContentPage
    { 

        ListView _medicamentosListView;

        public MedicamentoPage()
        {
            this.Content = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Loading"
            };

            Init();
        }

        private async Task Init()
        {
            _medicamentosListView = new ListView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "id");
            cell.SetBinding(TextCell.TextProperty, "nome");
            //cell.SetBinding(TextCell.DetailProperty, new Binding(path: "Start", stringFormat: "{0:MM/dd/yyyy}"));

            _medicamentosListView.ItemTemplate = cell;

            var viewModel = new MedicamentoViewModel();
            await viewModel.GetMedicamentos();
            _medicamentosListView.ItemsSource = viewModel.Medicamentos;

            this.Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(
                    left: 0,
                    right: 0,
                    bottom: 0,
                    top: Device.OnPlatform(iOS: 20, Android: 0, WinPhone: 0)),
                Children = {
                _medicamentosListView
            }
            };
        }
    }
}
