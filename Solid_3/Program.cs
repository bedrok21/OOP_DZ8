using System;
using System.Runtime.InteropServices;

class Rectangle
{
    public virtual int? Width { get; set; }
    public virtual int? Height { get; set; }
    public int? GetRectangleArea()
    {
        return Width * Height;
    }
}

//квадрат наслідується від прямокутника!!!
class Square : Rectangle
{
    public override int? Width
    {
        get { return base.Width; }
        set
        {
            //Перевірка на NULL
            if (base.Height == null)
            {
                base.Height = value;
            }
            base.Width = value;
        }
    }
    public override int? Height
    {
        get { return base.Height; }
        set
        {
            //Перевірка на NULL
            if (base.Width == null)
            {
                base.Width = value;
            }
            base.Height = value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Square();
            rect.Width = 5;
            rect.Height = 10;
            rect.Height = 3;
            rect.Width = 2;
            // Відповідь 6
            Console.WriteLine(rect.GetRectangleArea());
            //Що БУЛО не так??? - порушено принцип LSP : об'єкт підкласу не був замінюваним об'ктом базового класу; ВИПРАВЛНЕО
            Console.ReadKey();
        }
    }
}