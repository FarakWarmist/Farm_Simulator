public class ItemDecorator : IItem
{
    protected IItem _item;
    
    public ItemDecorator(IItem item)
    {
        _item = item;
    }

    public virtual string GetName() => _item.GetName();

    public virtual int GetValue() => _item.GetValue();
}
