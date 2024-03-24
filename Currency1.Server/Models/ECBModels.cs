using System.ComponentModel.DataAnnotations;

namespace Currency1.Server.Models
{
    public class Header
    {
        public string id { get; set; }
        public bool test { get; set; }
        public DateTime prepared { get; set; }
        public Sender sender { get; set; }
    }

    public class Sender
    {
        public string id { get; set; }
    }

    public class Observation
    {
        public Dictionary<string, Series>? _0 { get; set; }
    }

    public class DataSeries
    {
        public Dictionary<string, List<decimal?>>? observations { get; set; }
    }

    public class Series
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public List<Value>? values { get; set; }
    }

    public class DataSet
    {
        public string? action { get; set; }
        public DateTime? validFrom { get; set; }
        public Dictionary<string, DataSeries>? series { get; set; }
    }

    public class Value
    {
        public string? id { get; set; }
        public string? name { get; set; }
    }

    public class Dimensions
    {
        public List<Series>? series { get; set; }
        public List<Observation>? observation { get; set; }
    }

    public class Structure
    {
        public List<Link>? links { get; set; }
        public string? name { get; set; }
        public Dimensions? dimensions { get; set; }
    }

    public class Link
    {
        public string? title { get; set; }
        public string? rel { get; set; }
        public string? href { get; set; }
    }

    public class Root
    {
        public Header? header { get; set; }
        public List<DataSet>? dataSets { get; set; }
        public Structure? structure { get; set; }
    }
}
