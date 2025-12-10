using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Helpers
{
    public class Alert
    {
        public const string TempDataKey = "TempDataAlerts";

        public string AlertStyle { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }
    }

    public static class AlertStyles

    {
        public const string Success = "toast-success";
        public const string Information = "toast-info";
        public const string Warning = "toast-warning";
        public const string Danger = "toast-error";
    }
}