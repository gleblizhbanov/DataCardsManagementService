using System;

namespace Services.Exceptions
{
    public class CardNotFoundException : Exception
    {
        private const string BaseMessage = "The card with given identifier was not found.";

        public int CardId { get; }

        public CardNotFoundException(int cardId) : this(cardId, BaseMessage)
        {
            this.CardId = cardId;
        }

        public CardNotFoundException(int cardId, string message) : base(message)
        {
            this.CardId = cardId;
        }
    }
}
