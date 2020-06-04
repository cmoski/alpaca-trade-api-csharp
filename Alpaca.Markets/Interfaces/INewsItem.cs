using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Alpaca.Markets
{
    /// <summary>
    /// Encapsulates news information from Alpaca REST API.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface INewsItem
    {
        /// <summary>
        /// 
        /// </summary>
        string? Title { get; }

        /// <summary>
        /// 
        /// </summary>
        Uri? Url { get; }

        /// <summary>
        /// 
        /// </summary>
        string? Source { get; }

        /// <summary>
        /// 
        /// </summary>
        string? Summary { get; }
        /// <summary>
        /// 
        /// </summary>
        Uri? Image { get; }
        /// <summary>
        /// 
        /// </summary>
        DateTime? TimeStamp { get; }
        /// <summary>
        /// 
        /// </summary>
        List<string>? Keywords { get; }
    }
}
