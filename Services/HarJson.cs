using System;
using System.Text.Json.Serialization;

namespace JsonDiffer.Services;


public class HarJson
    {
        [JsonPropertyName("log")]
        public Log Log { get; set; }
    }

    public partial class Log
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("creator")]
        public Creator Creator { get; set; }

        [JsonPropertyName("pages")]
        public Page[] Pages { get; set; }

        [JsonPropertyName("entries")]
        public Entry[] Entries { get; set; }
    }

    public partial class Creator
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }

    public partial class Entry
    {
        [JsonPropertyName("_initiator")]
        public Initiator Initiator { get; set; }

        [JsonPropertyName("_priority")]
        public string Priority { get; set; }

        [JsonPropertyName("_resourceType")]
        public string ResourceType { get; set; }

        [JsonPropertyName("cache")]
        public Cache Cache { get; set; }

        [JsonPropertyName("connection")]
        public long Connection { get; set; }

        [JsonPropertyName("pageref")]
        public string Pageref { get; set; }

        [JsonPropertyName("request")]
        public Request Request { get; set; }

        [JsonPropertyName("response")]
        public Response Response { get; set; }

        [JsonPropertyName("serverIPAddress")]
        public string ServerIpAddress { get; set; }

        [JsonPropertyName("startedDateTime")]
        public DateTimeOffset StartedDateTime { get; set; }

        [JsonPropertyName("time")]
        public double Time { get; set; }

        [JsonPropertyName("timings")]
        public Timings Timings { get; set; }
    }

    public partial class Cache
    {
    }

    public partial class Initiator
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public partial class Request
    {
        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("httpVersion")]
        public string HttpVersion { get; set; }

        [JsonPropertyName("headers")]
        public Header[] Headers { get; set; }

        [JsonPropertyName("queryString")]
        public Header[] QueryString { get; set; }

        [JsonPropertyName("cookies")]
        public Cooky[] Cookies { get; set; }

        [JsonPropertyName("headersSize")]
        public long HeadersSize { get; set; }

        [JsonPropertyName("bodySize")]
        public long BodySize { get; set; }
    }

    public partial class Cooky
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        [JsonPropertyName("expires")]
        public DateTimeOffset Expires { get; set; }

        [JsonPropertyName("httpOnly")]
        public bool HttpOnly { get; set; }

        [JsonPropertyName("secure")]
        public bool Secure { get; set; }
    }

    public partial class Header
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public partial class Response
    {
        [JsonPropertyName("status")]
        public long Status { get; set; }

        [JsonPropertyName("statusText")]
        public string StatusText { get; set; }

        [JsonPropertyName("httpVersion")]
        public string HttpVersion { get; set; }

        [JsonPropertyName("headers")]
        public Header[] Headers { get; set; }

        [JsonPropertyName("cookies")]
        public object[] Cookies { get; set; }

        [JsonPropertyName("content")]
        public Content Content { get; set; }

        [JsonPropertyName("redirectURL")]
        public string RedirectUrl { get; set; }

        [JsonPropertyName("headersSize")]
        public long HeadersSize { get; set; }

        [JsonPropertyName("bodySize")]
        public long BodySize { get; set; }

        [JsonPropertyName("_transferSize")]
        public long TransferSize { get; set; }

        [JsonPropertyName("_error")]
        public object Error { get; set; }
    }

    public partial class Content
    {
        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("mimeType")]
        public string MimeType { get; set; }

        [JsonPropertyName("compression")]
        public long Compression { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public partial class Timings
    {
        [JsonPropertyName("blocked")]
        public double Blocked { get; set; }

        [JsonPropertyName("dns")]
        public long Dns { get; set; }

        [JsonPropertyName("ssl")]
        public long Ssl { get; set; }

        [JsonPropertyName("connect")]
        public long Connect { get; set; }

        [JsonPropertyName("send")]
        public double Send { get; set; }

        [JsonPropertyName("wait")]
        public double Wait { get; set; }

        [JsonPropertyName("receive")]
        public double Receive { get; set; }

        [JsonPropertyName("_blocked_queueing")]
        public double BlockedQueueing { get; set; }
    }

    public partial class Page
    {
        [JsonPropertyName("startedDateTime")]
        public DateTimeOffset StartedDateTime { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public Uri Title { get; set; }

        [JsonPropertyName("pageTimings")]
        public PageTimings PageTimings { get; set; }
    }

    public partial class PageTimings
    {
        [JsonPropertyName("onContentLoad")]
        public double OnContentLoad { get; set; }

        [JsonPropertyName("onLoad")]
        public double OnLoad { get; set; }
    }