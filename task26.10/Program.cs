using System;
class Program
{
    static void Main(string[] args)
    {

        Product product1=new Product("notebook", 1500, 5);
        product1.Detail();
        Console.WriteLine(product1.Discount(50));
        Book book = new Book("xosbextlik", 20, 10, "psixologiya");
        book.Detail();








        Console.Write("nece kitab elave etmek isteyirsiniz");
        int n = int.Parse(Console.ReadLine());
        Book[] books = new Book[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("kitabin adini daxil edin ");
            string name = Console.ReadLine();

            Console.WriteLine("qiymeti daxil edin ");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("sayini daxil edin ");
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine("janri daxil edin ");
            string genre = Console.ReadLine();

            books[i] = new Book(name, price, count, genre);
        }
        bool result = true;
        while (result)
        {
            Console.WriteLine("1. kitablari qiymete gore filtrle");
            Console.WriteLine("2. butun kitablari goster");
            Console.WriteLine("0. proqrami bagla");
            Console.Write("Seciminizi daxil edin");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Console.Write("minimum qiymet daxil edin");
                double min = double.Parse(Console.ReadLine());
                Console.Write("maksimum qiymet daxil edin");
                double max = double.Parse(Console.ReadLine());


                foreach (Book b in books)
                    if (b.Price >= min && b.Price <= max)
                        Console.WriteLine(b.Detail());
            }
            else if (secim == "2")
            {
                foreach (Book b in books)
                    Console.WriteLine(b.Detail());
            }
            else if (secim == "0")
            {
                result = false;
                break;
            }
            else
            {
                result = false;
                Console.WriteLine("yanlıs secim");
            }
        }
    }
}


class Product
{
    public string Name;
    public double Price;
    public int Count;

    public Product(string name, double price, int count)
    {
        if (string.IsNullOrEmpty(name) || price <= 0)
            Console.WriteLine("name ve price bos ola bilmez");
        Name = name;
        Price = price;
        Count = count;
    }

    public string Detail()
    {
        return $"ad: {Name}, qiymet: {Price}, say: {Count}";
    }

    public double Discount(int percent)
    {
        return Price - (Price * percent / 100);
    }
}

class Book : Product
{
    public string Genre;

    public Book(string name, double price, int count, string genre)
        : base(name, price, count)
    {
        if (string.IsNullOrEmpty(genre))
            Console.WriteLine("genre bos ola bilmez");
        Genre = genre;
    }

    public new string Detail()
    {
        return base.Detail() + $", janr: {Genre}";
    }
}

