abstract class Item
{

    public readonly string _name;
    public readonly int _price;
    protected Item(string name, int price)
    {
        _name = name;
        _price = price;
    }
}