using Metalama.Patterns.Observability;

namespace MySample;

//[NotifyPropertyChanged]
//[SimpleNotifyPropertyChanged]
[Observable]
internal partial class Product
{
    public string? Title { get; set; }
    public decimal Price { get; set; }
}
