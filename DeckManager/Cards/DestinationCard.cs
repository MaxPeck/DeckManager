﻿using DeckManager.Cards.Enums;

namespace DeckManager.Cards
{
    public class DestinationCard :BaseCard 
    {
        /// <summary>
        /// Returns that this is a Destination card
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        public override CardType CardType
        {
            get { return CardType.Destination; }
        }

        /// <summary>
        /// Outputs a BBCode representation of the card.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override string ToBBCode()
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            return Heading + "\n" + AdditionalText + "\nDistance: " + Distance.ToString();
        }

        /// <summary>
        /// Title of the destination.
        /// </summary>
        /// <value>
        /// The heading.
        /// </value>
        public string Heading { get; set; }

        /// <summary>
        /// Gets or sets the additional text, resource penalties, etc
        /// </summary>
        /// <value>
        /// The additional text.
        /// </value>
        public string AdditionalText { get; set; }

        /// <summary>
        /// The distance traveled when going to this destination.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public int Distance { get; set; }
    }
}
