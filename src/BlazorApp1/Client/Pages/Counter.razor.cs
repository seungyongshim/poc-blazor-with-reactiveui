using System.ComponentModel;
using BlazorApp1.Client.ViewModels;

namespace BlazorApp1.Client.Pages
{
    public partial class Counter : IDisposable
    {
        public Counter()
        {
            ViewModel = new CounterViewModel();
        }

        public CounterViewModel ViewModel { get; }

        public void Dispose()
        {
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
        }

        protected override void OnInitialized()
        {         
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            base.OnInitialized();
        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e) =>
            StateHasChanged();
    }
}
