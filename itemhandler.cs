using System.Collections.Generic;  
class ItemHandler
{
    public readonly List<Item> _items = new List<Item>();
    public readonly List<Offer> _specialoffers = new List<Offer>();

    static private ItemHandler _inst = null;

    static public ItemHandler GetInstance()
    {
        _inst = _inst == null ? new ItemHandler() : null;
        return _inst;
    }

    private ItemHandler()
    {
        var apple = new Apple();
        var peach = new Peach();
        var banana = new Banana();
        
        RegisterItem(apple);
        RegisterItem(peach);
        RegisterItem(banana);
        
        var applediscount = new Offer(apple, 2, 45);
        var bananadiscount = new Offer(banana, 3, 130);

        RegisterSpecialOffer(applediscount);
        RegisterSpecialOffer(bananadiscount);

    }
    public void RegisterItem(Item newitem)
    {
        _items.Add(newitem);
        System.Console.WriteLine("Registered new Item: " + newitem._name);
    }

    public void RegisterSpecialOffer(Offer newoffer)
    {
        _specialoffers.Add(newoffer);
    }

    public Offer FindOfferForItem(Item item)
    {
        foreach(var offer in _specialoffers)
        {
            if(offer._item._name != item._name)
                continue;
            

            return offer;
        }

        return null;
    }

    public Item FindItemByName(string name)
    {
        foreach(var item in _items)
        {
            if(item._name != name)
                continue;
            
            return item;
        }

        return null;
    }

    public string BuyItem(Item item, int howmany)
    {
        var fndoffer = FindOfferForItem(item);

        int price = item._price;
        int cost = price* howmany;

        if(fndoffer != null && howmany >= fndoffer._discountwhen)
        {
            System.Console.WriteLine("Applying discount: " + fndoffer._discountwhen + " for " + fndoffer._newprice);

            cost = 0;

            for(int i=0;i < howmany / fndoffer._discountwhen; i++)
            {
                cost = cost + fndoffer._newprice;
            };

            cost = cost + ((howmany % fndoffer._discountwhen) * price);

        }


        return "You can purchase: " + howmany + " of " + item._name + " for " + cost + " (" + price  + " a piece).";
        
    }

    public void PrintItems()
    {
        foreach(var curitem in _items)
        {
            System.Console.WriteLine(curitem._name);
        }
    }
}