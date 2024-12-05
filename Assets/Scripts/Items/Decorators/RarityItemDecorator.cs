using System;

public class CommonItemDecorator : ItemDecorator
{
    public CommonItemDecorator(IItem item) : base(item) { }

    public override int GetValue() => Convert.ToInt32(_item.GetValue() * 1f);
}

public class UncommonItemDecorator : ItemDecorator
{
    public UncommonItemDecorator(IItem item) : base(item) { }

    public override int GetValue() => Convert.ToInt32(_item.GetValue() * 1.5f);
}

public class RareItemDecorator : ItemDecorator
{
    public RareItemDecorator(IItem item) : base(item) { }

    public override int GetValue() => Convert.ToInt32(_item.GetValue() * 2f);
}

public class EpicItemDecorator : ItemDecorator
{
    public EpicItemDecorator(IItem item) : base(item) { }

    public override int GetValue() => Convert.ToInt32(_item.GetValue() * 2.5f);
}
