﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alpaca.Markets
{
    public sealed partial class PolygonDataClient
    {
        /// <summary>
        /// Gets list of historical trades for a single asset from Polygon's REST API endpoint.
        /// </summary>
        /// <param name="symbol">Asset name for data retrieval.</param>
        /// <param name="date">Single date for data retrieval.</param>
        /// <param name="timestamp">Paging - Using the timestamp of the last result will give you the next page of results.</param>
        /// <param name="timestampLimit">Maximum timestamp allowed in the results.</param>
        /// <param name="limit">Limits the size of the response.</param>
        /// <param name="reverse">Reverses the order of the results.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Read-only list of historical trade information.</returns>
        [Obsolete("Use overloaded method that required HistoricalRequest parameter instead of this one.", true)]
        public Task<IHistoricalItems<IHistoricalTrade>> ListHistoricalTradesAsync(
            String symbol,
            DateTime date,
            Int64? timestamp = null,
            Int64? timestampLimit = null,
            Int32? limit = null,
            Boolean? reverse = null,
            CancellationToken cancellationToken = default) =>
            ListHistoricalTradesAsync(
                new HistoricalRequest(symbol, date)
                {
                    Limit = limit,
                    Reverse = reverse,
                    Timestamp = timestamp,
                    TimestampLimit = timestampLimit
                }, cancellationToken);

        /// <summary>
        /// Gets list of historical trades for a single asset from Polygon's REST API endpoint.
        /// </summary>
        /// <param name="symbol">Asset name for data retrieval.</param>
        /// <param name="date">Single date for data retrieval.</param>
        /// <param name="timestamp">Paging - Using the timestamp of the last result will give you the next page of results.</param>
        /// <param name="timestampLimit">Maximum timestamp allowed in the results.</param>
        /// <param name="limit">Limits the size of the response.</param>
        /// <param name="reverse">Reverses the order of the results.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Read-only list of historical trade information.</returns>
        [Obsolete("Use overloaded method that required HistoricalRequest parameter instead of this one.", true)]
        public Task<IHistoricalItems<IHistoricalQuote>> ListHistoricalQuotesAsync(
            String symbol,
            DateTime date,
            Int64? timestamp = null,
            Int64? timestampLimit = null,
            Int32? limit = null,
            Boolean? reverse = null,
            CancellationToken cancellationToken = default) =>
            ListHistoricalQuotesAsync(
                new HistoricalRequest(symbol, date)
                {
                    Limit = limit,
                    Reverse = reverse,
                    Timestamp = timestamp,
                    TimestampLimit = timestampLimit
                }, cancellationToken);

        /// <summary>
        /// Gets list of historical minute bars for single asset from Polygon's v2 REST API endpoint.
        /// </summary>
        /// <param name="symbol">Asset name for data retrieval.</param>
        /// <param name="multiplier">Number of bars to combine in each result.</param>
        /// <param name="dateFromInclusive">Start time for filtering (inclusive).</param>
        /// <param name="dateToInclusive">End time for filtering (inclusive).</param>
        /// <param name="unadjusted">Set to true if the results should not be adjusted for splits.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Read-only list of day bars for specified asset.</returns>
        [Obsolete("Use overloaded method that required AggregatesRequest parameter instead of this one.", true)]
        public Task<IHistoricalItems<IAgg>> ListDayAggregatesAsync(
            String symbol,
            Int32 multiplier,
            DateTime dateFromInclusive,
            DateTime dateToInclusive,
            Boolean unadjusted = false,
            CancellationToken cancellationToken = default) =>
            ListAggregatesAsync(
                new AggregatesRequest(symbol,
                        new AggregationPeriod(multiplier, AggregationPeriodUnit.Day))
                    {
                        Unadjusted = unadjusted
                    }
                    .SetInclusiveTimeInterval(dateFromInclusive, dateToInclusive),
                cancellationToken);

        /// <summary>
        /// Gets list of historical hour bars for single asset from Polygon's v2 REST API endpoint.
        /// </summary>
        /// <param name="symbol">Asset name for data retrieval.</param>
        /// <param name="multiplier">Number of bars to combine in each result.</param>
        /// <param name="dateFromInclusive">Start time for filtering (inclusive).</param>
        /// <param name="dateToInclusive">End time for filtering (inclusive).</param>
        /// <param name="unadjusted">Set to true if the results should not be adjusted for splits.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Read-only list of minute bars for specified asset.</returns>
        [Obsolete("Use overloaded method that required AggregatesRequest parameter instead of this one.", true)]
        public Task<IHistoricalItems<IAgg>> ListHourAggregatesAsync(
            String symbol,
            Int32 multiplier,
            DateTime dateFromInclusive,
            DateTime dateToInclusive,
            Boolean unadjusted = false,
            CancellationToken cancellationToken = default) =>
            ListAggregatesAsync(
                new AggregatesRequest(symbol,
                        new AggregationPeriod(multiplier, AggregationPeriodUnit.Hour))
                    {
                        Unadjusted = unadjusted
                    }
                    .SetInclusiveTimeInterval(dateFromInclusive, dateToInclusive),
                cancellationToken);

        /// <summary>
        /// Gets list of historical minute bars for single asset from Polygon's v2 REST API endpoint.
        /// </summary>
        /// <param name="symbol">Asset name for data retrieval.</param>
        /// <param name="multiplier">Number of bars to combine in each result.</param>
        /// <param name="dateFromInclusive">Start time for filtering (inclusive).</param>
        /// <param name="dateToInclusive">End time for filtering (inclusive).</param>
        /// <param name="unadjusted">Set to true if the results should not be adjusted for splits.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Read-only list of minute bars for specified asset.</returns>
        [Obsolete("Use overloaded method that required AggregatesRequest parameter instead of this one.", true)]
        public Task<IHistoricalItems<IAgg>> ListMinuteAggregatesAsync(
            String symbol,
            Int32 multiplier,
            DateTime dateFromInclusive,
            DateTime dateToInclusive,
            Boolean unadjusted = false,
            CancellationToken cancellationToken = default) =>
            ListAggregatesAsync(
                new AggregatesRequest(symbol,
                        new AggregationPeriod(multiplier, AggregationPeriodUnit.Minute))
                    {
                        Unadjusted = unadjusted
                    }
                    .SetInclusiveTimeInterval(dateFromInclusive, dateToInclusive),
                cancellationToken);
    }
}
