﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckManager.Extensions
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class StringValueAttribute : Attribute
    {
        #region Public Properties

        /// <summary>
        /// Gets the string value.
        /// </summary>
        public string StringValue { get; private set; }

        #endregion // Public Properties

        #region Constructors

        public StringValueAttribute(string value)
        {
            StringValue = value;
        }

        #endregion // Constructors
    }
}
