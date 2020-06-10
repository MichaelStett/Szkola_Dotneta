using System;
using System.Collections.Generic;
using System.Linq;

using static System.Console;
using static System.Text.RegularExpressions.Regex;

namespace Join
{
    public static class EnumerableExtension
    {
        public static T GetRandom<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.OrderBy(x => Guid.NewGuid()).First();
        }
    }

    public static class StringExtension 
    {
        public static string SeparateByUppercase(this string str)
        {
            return string.Join(" ", Split(str, @"(?<!^)(?=[A-Z])"));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var itemIds = new int[] { 3, 2, 3, 4, 3, 4, 1 };
            var itemNames = new string[] { "Biscuit", "Chocolate", "Butter", "Bread", "Honey" };
            var quantities = new int[] { 800, 650, 900, 700, 900, 650, 458 };

            var ItemId = 1;
            var items = itemNames.Select(ItemName => (ItemId: ItemId++, ItemName)).ToList();

            var InvoiceNo = 100;
            var purchases = Enumerable.Zip(quantities, itemIds, (quantity, itemId) => (PurchaseQuantity: quantity, ItemId: itemId))
                                      .Select(p => (InvoiceNo: InvoiceNo++, p.ItemId, p.PurchaseQuantity))
                                      .OrderBy(p => p.ItemId)
                                      .ToList();

            (var randomItem, var randomPurchase) = (items.GetRandom(), purchases.GetRandom());

            var namesWithPadding = new List<(string Name, int Padding)>
            {
                (nameof(randomPurchase.ItemId),            0),
                (nameof(randomItem.ItemName),             14),
                (nameof(randomPurchase.PurchaseQuantity), 20)
            }.Select(item => (Name: item.Name.SeparateByUppercase(), item.Padding)).ToList();

            namesWithPadding.ForEach(item => Write($"{item.Name.PadLeft(item.Padding)}"));
            
            WriteLine($"\n=================================================");

            purchases.ForEach(product => WriteLine($"{product.ItemId,0} {items.Find(item => item.ItemId == product.ItemId).ItemName,19} {product.PurchaseQuantity,19}"));
        }
    }
}
