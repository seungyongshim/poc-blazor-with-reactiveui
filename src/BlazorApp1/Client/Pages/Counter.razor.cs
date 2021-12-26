using System.ComponentModel;
using BlazorApp1.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Client.Pages
{
    public partial class Counter : IDisposable
    {
        [Inject]
        public CounterViewModel ViewModel { get; set; }

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
