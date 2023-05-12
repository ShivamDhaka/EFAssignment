using EFAssignment.Context;
using EFAssignment.Models;
using Microsoft.Identity.Client;

class Program
{
    public static void Main(string[] args)
    {

        InventoryDbContext db = new InventoryDbContext();

        Console.WriteLine("Enter the choice you want to perform CRUD operations on:\n1.Inventory\n2.Supplier");
        int ch = Convert.ToInt32(Console.ReadLine());
        switch (ch)
        {
            case 1:
                {
                    Console.WriteLine("1.Add Inventory" +
                        "\n2.Delete Inventory" +
                        "\n3.Edit Inventory" +
                        "\n4.Get Inventories" +
                        "\n\nEnter Your Choice:");

                    int choice = Convert.ToInt32(Console.ReadLine());
                    if(choice == 1)
                    {
                        // Insert record in Inventory

                        Supplier supply = db.Suppliers.FirstOrDefault(x => x.SupplierId == 6);
                        Inventory inventory = new Inventory()
                        {
                            Name="Laptop",
                            Details="Can handle Visual Studio 2022, Isn't this enough?",
                            QtyInStock=5,
                            LastUpdated=Convert.ToDateTime("12/05/2023"),
                            Supplier = supply
                        };
                        db.Inventories.Add(inventory);
                        db.SaveChanges();
                    }
                    else if(choice == 2)
                    {
                        // Delete record in Inventory

                        Inventory i = db.Inventories.Where(x => x.Id==1).FirstOrDefault();
                        if (i!=null)
                        {
                            db.Inventories.Remove(i);
                            db.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("There is no record");
                        }
                    }
                    else if(choice == 3)
                    {
                        // Edit record in Inventory

                        Inventory iobj = db.Inventories.Where(x => x.Id==1).FirstOrDefault();
                        if (iobj!=null)
                        {
                            foreach (Inventory temp in db.Inventories)
                            {
                                if (temp.Id == iobj.Id)
                                {
                                    temp.QtyInStock = 10;
                                }
                            }
                            db.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("There is no record");
                        }
                    }
                    else if(choice == 4)
                    {
                        // Display record

                        List<Inventory> list = new List<Inventory>();
                        list = db.Inventories.ToList();
                        foreach (Inventory temp in list)
                        {
                            Console.WriteLine($"{temp.Id} -- {temp.Name} -- {temp.Details} -- {temp.QtyInStock} -- {temp.LastUpdated}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Input");
                    }
                    break;
                }
            case 2:
                {
                    Console.WriteLine("1.Add Supplier" +
                        "\n2.Delete Supplier" +
                        "\n3.Edit Supplier" +
                        "\n4.Get Supplier" +
                        "\n\nEnter Your Choice:");

                    int choice1 = Convert.ToInt32(Console.ReadLine());
                    if(choice1 == 1)
                    {
                        // Insert record in Supplier

                        Supplier supplier = new Supplier()
                        {
                            SupplierName = "Surendra",
                            Address = "Rajnagar Extension",
                            ContactNo = "+91 9876543210",
                            EmailAddress = "Surendra@supplier.com",
                            City = "Ghaziabad"
                        };
                        db.Suppliers.Add(supplier);
                        db.SaveChanges();
                    }

                    else if(choice1 == 2)
                    {
                        // Delete record in Supplier

                        Supplier s = db.Suppliers.Where(x => x.SupplierId == 1).FirstOrDefault();
                        if(s != null)
                        {
                            db.Suppliers.Remove(s);
                            db.SaveChanges() ;
                        }
                        else
                        {
                            Console.WriteLine("There is no record");
                        }
                    }

                    else if(choice1 == 3)
                    {
                        // Edit record in Supplier

                        Supplier sobj = db.Suppliers.Where(x => x.SupplierId == 1).FirstOrDefault();
                        if(sobj != null)
                        {
                            foreach(Supplier temp in db.Suppliers)
                            {
                                if(temp.SupplierId == sobj.SupplierId)
                                {
                                    temp.Address = "Noida";
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no record");
                        }
                    }

                    else if(choice1 == 4)
                    {
                        // Display record

                        List<Supplier> list1 = new List<Supplier>();
                        list1 = db.Suppliers.ToList();
                        foreach (Supplier temp in list1)
                        {
                            Console.WriteLine($"{temp.SupplierId} -- {temp.SupplierName} -- {temp.Address} -- {temp.ContactNo} -- {temp.EmailAddress} -- {temp.City}");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Enter a Valid Input");
                    }
                    break;
                }
            default:
                {
                    Console.WriteLine("Enter Valid Input");
                    break;
                }
        }   
    }
}