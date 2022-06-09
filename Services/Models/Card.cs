namespace Services.Models
{
    /// <summary>
    /// Represents a card item.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Gets or sets the card identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the card name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the card image.
        /// </summary>
        public byte[] Image { get; set; }
    }
}
