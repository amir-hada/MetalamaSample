using System;
using System.ComponentModel;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

internal class SimpleNotifyPropertyChangedAttribute : TypeAspect
{
    [Introduce]
    public event PropertyChangedEventHandler? PropertyChanged;

    [Introduce]
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(meta.This, new PropertyChangedEventArgs(propertyName));
    }

    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        builder.Advice.ImplementInterface(builder.Target, typeof(INotifyPropertyChanged));
        
        foreach (var property in builder.Target.Properties)
        {
            builder.Advice.OverrideAccessors(
                property,
                setTemplate: nameof(SetterTemplate)
            );
        }
    }

    [Template]
    private void SetterTemplate(dynamic value)
    {
        if (!Equals(meta.Target.Property.Value, value))
        {
            meta.Proceed();
            meta.This.OnPropertyChanged(meta.Target.Property.Name);
        }
        
    }

}



//Where(p => p.Writeability == Writeability.All && !p.IsStatic)