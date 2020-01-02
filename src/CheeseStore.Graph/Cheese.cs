using System;

namespace CheeseStore.Graph
{
    public class Cheese
    {
        public Guid Id { get; set; }

        public Uri? Uri { get; set; }

        public string Name { get; set; } = string.Empty;

        public Texture Texture { get; set; } = Texture.Medium;

        public MilkSource MilkSource { get; set; } = MilkSource.Cow;

        public Mold Mold { get; set; } = Mold.Other;

        public bool Brined { get; set; } = false;

        public bool Processed { get; set; } = false;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Available { get; set; }
    }
}
