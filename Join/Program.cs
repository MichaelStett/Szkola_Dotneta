using System;
using System.Collections.Generic;
using System.Linq;


using static System.Console;
using static System.Text.RegularExpressions.Regex;

namespace Join
{
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
            var itemNames = new string[] { "Biscuit", "Chocolate", "Butter", "Bread", "Honey" };

            var ItemId = 1;
            var items = itemNames.Select(ItemName => (ItemId: ItemId++, ItemName)).ToList();

            var quantities = new int[] { 800, 650, 900, 700, 900, 650, 458 };
            var itemIds = new int[] { 3, 2, 3, 4, 3, 4, 1 };

            var InvoiceNo = 100;
            var products = Enumerable.Zip(quantities, itemIds, (quantity, itemId) => (PurchaseQuantity: quantity, ItemId: itemId))
                                     .Select(zipped => (InvoiceNo: InvoiceNo++, zipped.ItemId, zipped.PurchaseQuantity))
                                     .OrderBy(p => p.ItemId)
                                     .ToList();

            (var firstItem, var firstProduct) = (items[0], products[0]);

            var namesWithPadding = new List<(string Name, int Padding)>
            {
                (nameof(firstProduct.ItemId),            0),
                (nameof(firstItem.ItemName),            14),
                (nameof(firstProduct.PurchaseQuantity), 20)

            }.Select(item => (Name: item.Name.SeparateByUppercase(), item.Padding)).ToList();

            namesWithPadding.ForEach(item => Write($"{item.Name.PadLeft(item.Padding)}"));
            
            WriteLine($"\n=================================================");
            
            products.ForEach(product => WriteLine($"{product.ItemId} {items.Find(item => item.ItemId == product.ItemId).ItemName, 19} {product.PurchaseQuantity, 19}"));
        }
    }
}
