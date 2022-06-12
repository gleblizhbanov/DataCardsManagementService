using System;

namespace ClientApp.Events
{
    public class CardCreatedEventArgs : EventArgs
    {
        public CardCreatedEventArgs(int cardId)
        {
            this.CardId = cardId;
        }

        public int CardId { get; set; }
    }
}
