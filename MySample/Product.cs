namespace MySample;

//[NotifyPropertyChanged]
[SimpleNotifyPropertyChanged]
internal partial class Product
{
    public string? Title { get; set; }
    public decimal Price { get; set; }
}
