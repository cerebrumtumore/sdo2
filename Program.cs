
class sweetshop
{
    public Guid Id { get; set; }
    private string name;
    private string description;
    private double weight;
    private int price;

    public sweetshop(string name, string description, double weight, int price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Weight = weight;
        Price = price;

    }




    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public double Weight { get => weight; set => weight = value; }
    public int Price { get => price; set => price = value; }
}

