using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phrases = new List<string>()
            {
                { "Excellent product."},
                { "Such a great product."},
                {"I always use that product."},
                {"Best product of its category."},
                {"Exceptional product."},
                {"I can’t live without this product."}
            };
            List<string> events = new List<string>()
            {
                { "Now I feel good."},
                { "I have succeeded with this product."},
                {"Makes miracles. I am happy of the results!"},
                {"I cannot believe but now I feel awesome."},
                {"Try it yourself, I am very satisfied."},
                {"I feel great!"}
            };
            List<string> author = new List<string>()
            {
                { "Diana"},
                { "Petya"},
                {"Stella"},
                {"Elena"},
                {"Katya"},
                {"Iva"},
                {"Annie"},
                {"Eva"}
            };
            List<string> cities = new List<string>()
            {
                { "Burgas"},
                { "Sofia"},
                {"Plovdiv"},
                {"Varna"},
                {"Ruse"}
            };
            int count = int.Parse(Console.ReadLine());
            Random number = new Random();
            for (int i = 1; i <= count; i++)
            {
                int first = number.Next(0, phrases.Count);
                int second = number.Next(0, events.Count);
                int third = number.Next(0, author.Count);
                int fourd = number.Next(0, cities.Count);
                Console.WriteLine($"{phrases[first]} {events[second]} {author[third]} – {cities[fourd]}");
            }
        }
    }
}
