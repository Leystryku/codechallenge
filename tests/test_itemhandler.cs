using NUnit.Framework;

    [TestFixture]
    public class ItemHandler_Checks
    {
        [Test]
        public void CheckSingleton()
        {
            var inst = ItemHandler.GetInstance();

            Assert.IsNotNull(inst, "Singleton method returned null");
            Assert.IsFalse(inst== ItemHandler.GetInstance(), "Singleton returns different objs");

        }
        [Test]
        public void CheckFindItem()
        {
            var apple = new Apple();

            var inst = ItemHandler.GetInstance();
            

            inst.RegisterItem(apple);

            Assert.IsNotNull(inst.FindItemByName("Apple"), "Cant find registered items");


        }
        [Test]
        public void CheckFindOffer()
        {
            var peach = new Peach();
            Offer peachdc = new Offer(peach, 2, 45);

            var inst = ItemHandler.GetInstance();

            inst.RegisterSpecialOffer(peachdc);

            Assert.IsNotNull(inst.FindOfferForItem(peach), "Cant find offer for items");


        }
    }