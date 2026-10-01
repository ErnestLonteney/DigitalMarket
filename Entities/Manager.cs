namespace DigitalMarket.Entities;

public class Manager : Employee
{
    public Manager(string firstName, string lastName)
    {
        LastName = lastName;
        FirstName = firstName;
    }

    protected Manager()
    {

    }

    public ManagerRank Rnak { get; set; }

    public List<Order> Orders { get; set; } = [];

    public ICollection<Department> Departments { get; set; } = [];

}
