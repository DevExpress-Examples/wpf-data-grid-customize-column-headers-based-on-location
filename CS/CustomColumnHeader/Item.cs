using DevExpress.Mvvm;
using System;
using System.Collections.Generic;

namespace CustomColumnHeader {
    public class Item : BindableBase {
        public string Name {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public decimal Group {
            get => GetValue<decimal>();
            set => SetValue(value);
        }

        public Item(string name, decimal group) {
            Name = name;
            Group = group;
        }

        public static IEnumerable<Item> GetData(int quantity) {
            var gen = new Random(42);

            for (int i = 0; i < quantity; i++) {
                var name = $"Name# {i}";
                var group = gen.Next(1, 4);

                yield return new Item(name, group);
            }
        }
    }
}
