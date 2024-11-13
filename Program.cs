using Microsoft.AspNetCore.StaticFiles.Infrastructure;
sweetshopRepository repo = new sweetshopRepository();
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/sweetshop/{id}", (Guid id) => repo.Read(id));
app.MapGet("/sweetshop/readAll", () => repo.ReadAll());
app.MapPost("/sweetshop/create", (sweetshop sweet) => repo.Create(sweet));
app.MapPost("/sweetshop/delete/{id}", (Guid id) => repo.Delete(id));

app.Run();


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

class sweetshopRepository
{
    public List<sweetshop> sweetshops { get; set; }

    public sweetshopRepository()
    {
        sweetshops = new List<sweetshop>();
    }

    public void Create(sweetshop sweet)
    {
        sweetshops.Add(sweet);
    }


    public sweetshop Read(Guid id)
    {
        for (int i = 0; i < sweetshops.Count; i++)
        {
            if (sweetshops[i].Id == id)
            {
                return sweetshops[i];
            }
        }
        throw new Exception("мер");

    }

    public List<sweetshop> ReadAll()
    {
        return sweetshops;
    }

    public void Delete(Guid id)
    {
        sweetshops.Remove(Read(id));
    }
}
