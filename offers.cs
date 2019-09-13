class Offer
{
    public Offer(Item item, int discountwhen, int newprice)
    {
        _item = item;
        _discountwhen = discountwhen;
        _newprice = newprice;
    }
    public Item _item {get; private set; }
    public int _discountwhen {get; private set; }
    
    public int _newprice {get; private set; }
}