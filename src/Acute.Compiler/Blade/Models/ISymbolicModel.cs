﻿namespace Blade.Compiler.Models
{
    /// <summary>
    /// Data contract for a model that has semantic meaning.
    /// </summary>
    public interface ISymbolicModel : IModel
    {
        /// <summary>
        /// Gets or sets the model definition.
        /// </summary>
        IDefinition Definition { get; set; }
    }
}

