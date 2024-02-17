namespace Test.Model.ViewModels
{
    public class CatagoryView
    {
        public Catagory Catagory { get; set; } = new Catagory();
        public IEnumerable<Catagory> Catagorys { get; set; } = new List<Catagory>();
    }
}
