using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bioscope.App.Helpers
{
  public class Noty
  {
    [JsonProperty(PropertyName = "theme")]
    public string Theme { get; set; } = " alert bg-success text-white alert-styled-left p-0";

    [JsonProperty(PropertyName = "text")]
    public string Text { get; set; }

    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    [JsonProperty(PropertyName = "progressBar")]
    public bool ProgressBar { get; set; } = true;

    [JsonProperty(PropertyName = "closeWith")]
    public string[] CloseWith { get; set; } = new string[] { "button" };

    [JsonProperty(PropertyName = "timeout")]
    public int Timeout { get; set; } = 1500;

    //private static readonly Noty _noty = new Noty
    //{
    //    Theme = " alert alert-success alert-styled-left p-0 bg-white",
    //    ProgressBar = true,
    //    CloseWith = new string[] { "button" },
    //    Timeout = 1500
    //};

    //static Noty() { }

    //private Noty() { }

    //public static Noty Configure(Noty config)
    //{
    //    Type t = typeof(Noty);

    //    var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

    //    foreach (var prop in properties)
    //    {
    //        var value = prop.GetValue(config, null);
    //        if (value != null) prop.SetValue(_noty, value, null);
    //    }

    //    return _noty;
    //}

    public static string Added => JsonConvert.SerializeObject(new Noty
    {
      Text = "Information successfully Updated!",
      Type = "success",
    });

    public static string Updated => JsonConvert.SerializeObject(new Noty
    {
      Text = "Information successfully Updated!",
      Type = "success"
    });

    public static string Deleted => JsonConvert.SerializeObject(new Noty
    {
      Text = "Information successfully Deleted!",
      Type = "success"
    });

    public static string NoRecordFound => JsonConvert.SerializeObject(new Noty
    {
      Text = "No Record Found!",
      Type = "error",
      Theme = " alert bg-danger text-white alert-styled-left p-0"
    });

    public static string BadRequest => JsonConvert.SerializeObject(new Noty
    {
      Text = "Bad request!",
      Type = "error",
      Theme = " alert bg-danger text-white alert-styled-left p-0"
    });

    public static string ValidationError => JsonConvert.SerializeObject(new Noty
    {
      Text = "Validation Error!",
      Type = "error",
      Theme = " alert bg-danger text-white alert-styled-left p-0"
    });

    public static string ServerError => JsonConvert.SerializeObject(new Noty
    {
      Text = "Server Error!",
      Type = "error",
      Theme = " alert bg-danger text-white alert-styled-left p-0"
    });

    public static string HttpNotFound => JsonConvert.SerializeObject(new Noty
    {
      Text = "Information not found!",
      Type = "error",
      Theme = " alert bg-danger text-white alert-styled-left p-0"
    });

    public static string DbError(string exceptionMessage) =>
    JsonConvert.SerializeObject(new Noty
    {
      Text = !string.IsNullOrWhiteSpace(exceptionMessage) ?  $"`{exceptionMessage}`" : $"Database Error! Error occured in database, Try again!",
      Type = "error",
      Theme = " alert bg-danger text-white alert-styled-left p-0"
    });

    public static string Error(string errorMessage) => JsonConvert.SerializeObject(new Noty
    {
      Text = $"`{errorMessage}`",
      Type = "error",
      Theme = " alert bg-danger text-white alert-styled-left p-0"
    });

    public static string Error(string errorTitle, string errorMessage) => JsonConvert.SerializeObject(new Noty
    {
      Text = $"`{errorTitle} {errorMessage}`",
      Type = "error",
      Theme = " alert bg-danger text-white alert-styled-left p-0"
    });
    public static string Success(string successMessage) => JsonConvert.SerializeObject(new Noty
    {
      Text = $"{successMessage}",
      Type = "success"
    });
    public static string Success(string successTitle, string successMessage) => JsonConvert.SerializeObject(new Noty
    {
      Text = $"{successTitle} {successMessage}",
      Type = "success"
    });
  }
}