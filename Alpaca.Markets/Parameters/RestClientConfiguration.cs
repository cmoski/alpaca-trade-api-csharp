﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Alpaca.Markets
{
    /// <summary>
    /// Configuration parameters object for <see cref="RestClient"/> class.
    /// </summary>
    [SuppressMessage(
        "Globalization","CA1303:Do not pass literals as localized parameters",
        Justification = "We do not plan to support localized exception messages in this SDK.")]
    public sealed class RestClientConfiguration
    {
        internal const Int32 DEFAULT_API_VERSION_NUMBER = 2;

        internal const Int32 DEFAULT_DATA_API_VERSION_NUMBER = 1;

        private static readonly HashSet<Int32> _supportedApiVersions = new HashSet<Int32> { 1, 2 };

        private static readonly HashSet<Int32> _supportedDataApiVersions = new HashSet<Int32> { 1 };

        /// <summary>
        /// Creates new instance of <see cref="RestClientConfiguration"/> class.
        /// </summary>
        public RestClientConfiguration()
        {
            KeyId = String.Empty;
            SecretKey = String.Empty;
            OAuthKey = String.Empty;

            TradingApiUrl = LiveEnvironment.TradingApiUrl;
            DataApiUrl = LiveEnvironment.DataApiUrl;
            PolygonApiUrl = LiveEnvironment.PolygonRestApi;

            TradingApiVersion = DEFAULT_API_VERSION_NUMBER;
            DataApiVersion = DEFAULT_DATA_API_VERSION_NUMBER;

            ThrottleParameters = ThrottleParameters.Default;
        }

        /// <summary>
        /// Gets or sets Alpaca application key identifier.
        /// </summary>
        public String KeyId { get; set; }

        /// <summary>
        /// Gets or sets Alpaca secret key identifier.
        /// </summary>
        public String SecretKey { get; set; }

        /// <summary>
        /// Gets or sets Alpaca OAuth authentication key.
        /// </summary>
        public String OAuthKey { get; set; }

        /// <summary>
        /// Gets or sets Alpaca trading REST API base URL.
        /// </summary>
        public Uri TradingApiUrl { get; set; }

        /// <summary>
        /// Gets or sets Alpaca data REST API base URL.
        /// </summary>
        public Uri DataApiUrl { get; set; }

        /// <summary>
        /// Gets or sets Polygon.io REST API base URL.
        /// </summary>
        public Uri PolygonApiUrl { get; set; }

        /// <summary>
        /// Gets or sets Alpaca Trading API version.
        /// </summary>
        public Int32 TradingApiVersion { get; set; }

        /// <summary>
        /// Gets or sets Alpaca data REST API version.
        /// </summary>
        public Int32 DataApiVersion { get; set; }

        /// <summary>
        /// Gets or sets REST API throttling parameters.
        /// </summary>
        public ThrottleParameters ThrottleParameters { get; set; }

        internal RestClientConfiguration EnsureIsValid()
        {
            if (String.IsNullOrEmpty(KeyId))
            {
                throw new InvalidOperationException(
                    $"The value of '{nameof(KeyId)}' property shouldn't be null or empty.");
            }

            if (!(String.IsNullOrEmpty(SecretKey) ^
                  String.IsNullOrEmpty(OAuthKey)))
            {
                throw new InvalidOperationException(
                    $"The value of '{nameof(SecretKey)}' or `{nameof(OAuthKey)}` property (but not both) should be non-empty.");
            }

            if (TradingApiUrl == null)
            {
                throw new InvalidOperationException(
                    $"The value of '{nameof(TradingApiUrl)}' property shouldn't be null.");
            }

            if (DataApiUrl == null)
            {
                throw new InvalidOperationException(
                    $"The value of '{nameof(DataApiUrl)}' property shouldn't be null.");
            }

            if (PolygonApiUrl == null)
            {
                throw new InvalidOperationException(
                    $"The value of '{nameof(PolygonApiUrl)}' property shouldn't be null.");
            }

            if (!_supportedApiVersions.Contains(TradingApiVersion))
            {
                throw new InvalidOperationException(
                    $"The value of '{nameof(TradingApiVersion)}' property is invalid.");
            }

            if (!_supportedDataApiVersions.Contains(DataApiVersion))
            {
                throw new InvalidOperationException(
                    $"The value of '{nameof(DataApiVersion)}' property is invalid.");
            }

            if (ThrottleParameters == null)
            {
                throw new InvalidOperationException(
                    $"The value of '{nameof(ThrottleParameters)}' property shouldn't be null.");
            }

            return this;
        }
    }
}
