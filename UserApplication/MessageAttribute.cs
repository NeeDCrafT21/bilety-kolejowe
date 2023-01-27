namespace UserApplication;

[AttributeUsage( AttributeTargets.All )]

public class MessageAttribute : Attribute
{
    public string messageType { get; set; }
    
}