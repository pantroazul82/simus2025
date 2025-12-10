using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Helpers
{
    public static class GridViewHelper
    {
        private static GridViewSettings exportGridViewSettings;

        public static GridViewSettings ExportGridViewSettings
        {
            get
            {
                if (exportGridViewSettings == null)
                    exportGridViewSettings = CreateExportGridViewSettings();
                return exportGridViewSettings;
            }
        }

        private static GridViewSettings CreateExportGridViewSettings()
        {
            GridViewSettings settings = new GridViewSettings();
            return settings;
        }
    }
}