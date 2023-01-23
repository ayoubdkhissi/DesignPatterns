namespace Bridge;

public abstract class Menu
{
    public readonly ICoupon _coupon;

    public abstract int CalculatePrice();

    protected Menu(ICoupon coupon)
    {
        _coupon = coupon;
    }
}

public class VegitarianMenu : Menu
{
    public VegitarianMenu(ICoupon coupon) 
        : base(coupon)
    {
    }

    public override int CalculatePrice()
    {
        return 20 - _coupon.CoupounValue;
    }
}

public class MeatMenu : Menu
{
    public MeatMenu(ICoupon coupon)
        : base(coupon)
    {
    }
    public override int CalculatePrice()
    {
        return 30 - _coupon.CoupounValue;
    }
}

public interface ICoupon
{
    int CoupounValue { get; }
}

public class NoCoupon :ICoupon
{
    public int CoupounValue { get => 0; }
}

public class OneEuroCoupon : ICoupon
{
    public int CoupounValue { get => 1; }
}

public class TwoEuroCoupon : ICoupon
{
    public int CoupounValue { get => 2; }
}
