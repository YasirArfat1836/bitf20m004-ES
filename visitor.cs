using System;
using System.Collections.Generic;


// Element interface
namespace visitor
{
    interface IElement
    {
        void Accept(IVisitor visitor);
    }

    // Concrete Elements
    class TextElement : IElement
    {
        public string Text { get; }

        public TextElement(string text)
        {
            Text = text;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitTextElement(this);
        }
    }

    class ImageElement : IElement
    {
        public string ImagePath { get; }

        public ImageElement(string imagePath)
        {
            ImagePath = imagePath;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitImageElement(this);
        }
    }

    // Visitor interface
    interface IVisitor
    {
        void VisitTextElement(TextElement element);
        void VisitImageElement(ImageElement element);
    }

    // Concrete Visitor
    class HtmlExportVisitor : IVisitor
    {
        public void VisitTextElement(TextElement element)
        {
            Console.WriteLine($"Exporting text: {element.Text}");
        }

        public void VisitImageElement(ImageElement element)
        {
            Console.WriteLine($"Exporting image: {element.ImagePath}");
        }
    }

    // Object Structure
    class Document
    {
        private List<IElement> elements = new List<IElement>();

        public void AddElement(IElement element)
        {
            elements.Add(element);
        }

        public void Export(IVisitor visitor)
        {
            foreach (var element in elements)
            {
                element.Accept(visitor);
            }
        }
    }


  

// Element interface
interface IShoppingItem
    {
        void Accept(IShoppingCartVisitor visitor);
    }

    // Concrete Elements
    class Book : IShoppingItem
    {
        public string Title { get; }
        public double Price { get; }

        public Book(string title, double price)
        {
            Title = title;
            Price = price;
        }

        public void Accept(IShoppingCartVisitor visitor)
        {
            visitor.VisitBook(this);
        }
    }

    class Fruit : IShoppingItem
    {
        public string Name { get; }
        public double Weight { get; }
        public double PricePerKilogram { get; }

        public Fruit(string name, double weight, double pricePerKilogram)
        {
            Name = name;
            Weight = weight;
            PricePerKilogram = pricePerKilogram;
        }

        public void Accept(IShoppingCartVisitor visitor)
        {
            visitor.VisitFruit(this);
        }
    }

    // Visitor interface
    interface IShoppingCartVisitor
    {
        void VisitBook(Book book);
        void VisitFruit(Fruit fruit);
    }

    // Concrete Visitor
    class ShoppingCartVisitor : IShoppingCartVisitor
    {
        private double totalCost = 0;

        public void VisitBook(Book book)
        {
            totalCost += book.Price;
            Console.WriteLine($"Added {book.Title} to the shopping cart. Cost: ${book.Price}");
        }

        public void VisitFruit(Fruit fruit)
        {
            double cost = fruit.Weight * fruit.PricePerKilogram;
            totalCost += cost;
            Console.WriteLine($"Added {fruit.Name} to the shopping cart. Cost: ${cost}");
        }

        public double GetTotalCost()
        {
            return totalCost;
        }
    }

    // Object Structure
    class ShoppingCart
    {
        private List<IShoppingItem> items = new List<IShoppingItem>();

        public void AddItem(IShoppingItem item)
        {
            items.Add(item);
        }

        public void CalculateTotalCost(ShoppingCartVisitor visitor)
        {
            foreach (var item in items)
            {
                item.Accept(visitor);
            }

            Console.WriteLine($"Total cost: ${visitor.GetTotalCost()}");
        }
    }




    //class Program
    //{
    //    static void Main()
    //    {
    //        Document document = new Document();
    //        document.AddElement(new TextElement("This is a text element."));
    //        document.AddElement(new ImageElement("/images/picture.jpg"));

    //        HtmlExportVisitor htmlExportVisitor = new HtmlExportVisitor();
    //        document.Export(htmlExportVisitor);

    //        ShoppingCart shoppingCart = new ShoppingCart();
    //        shoppingCart.AddItem(new Book("Design Patterns", 30.0));
    //        shoppingCart.AddItem(new Fruit("Apple", 2.5, 2.0));
    //        shoppingCart.AddItem(new Fruit("Banana", 1.8, 1.5));

    //        ShoppingCartVisitor shoppingCartVisitor = new ShoppingCartVisitor();
    //        shoppingCart.CalculateTotalCost(shoppingCartVisitor);
    //    }
    //}
}