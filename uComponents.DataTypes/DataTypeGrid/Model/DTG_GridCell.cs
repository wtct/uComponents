﻿// --------------------------------------------------------------------------------------------------------------------
// <summary>
// 30.01.2013 - Created [Ove Andersen]
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace uComponents.DataTypes.DataTypeGrid.Model
{
    using System;

    using umbraco.MacroEngines;

    /// <summary>
    /// Represents a DataTypeGrid Cell
    /// </summary>
    public class GridCell
    {
        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        /// <value>The alias.</value>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the name of the node.
        /// </summary>
        /// <value>The name of the node.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the node.
        /// </summary>
        /// <value>The type of the node.</value>
        public int DataType { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <value>The object.</value>
        public object Object { get; }

        /// <summary>
        /// Converts the collection to a <see cref="DynamicXml"/> object.
        /// </summary>
        /// <returns>The dynamic xml.</returns>
        public DynamicXml AsDynamicXml()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <returns>The value as the actual object.</returns>
        public T GetObject<T>()
        {
            throw new NotImplementedException();
        }
    }
}