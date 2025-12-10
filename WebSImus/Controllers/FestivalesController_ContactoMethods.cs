// Métodos adicionales para la sección de Contacto
// Agregar estos métodos al FestivalesController.cs antes del cierre de la clase

/// <summary>
/// Obtiene la lista de tipos de organizador para el combo de contacto
/// </summary>
[HttpGet]
public JsonResult ObtenerTiposOrganizador()
{
    try
    {
        using (var contexto = new SM.SIPA.SIPAEntities())
        {
            var tipos = contexto.ART_MUS_FESTIVALES_TIPO_ORGANIZADOR
                .Where(t => t.TIPO_ORGANIZADOR != null)
                .Select(t => new SelectListItem
                {
                    Value = t.ID.ToString(),
                    Text = t.TIPO_ORGANIZADOR
                })
                .ToList();

            return Json(tipos, JsonRequestBehavior.AllowGet);
        }
    }
    catch (Exception ex)
    {
        string ruta = Server.MapPath("/Log");
        SM.Utilidades.Log.Log.WriteLog(ruta, ex.ToString());
        return Json(new List<SelectListItem>(), JsonRequestBehavior.AllowGet);
    }
}

/// <summary>
/// Obtiene la lista de naturalezas de entidad para el combo de entidades aliadas
/// </summary>
[HttpGet]
public JsonResult ObtenerNaturalezasEntidad()
{
    try
    {
        using (var contexto = new SM.SIPA.SIPAEntities())
        {
            var naturalezas = contexto.ART_MUS_FESTIVALES_NATURALEZA_ENTIDAD
                .Where(n => n.NATURALEZA != null)
                .Select(n => new SelectListItem
                {
                    Value = n.ID.ToString(),
                    Text = n.NATURALEZA
                })
                .ToList();

            return Json(naturalezas, JsonRequestBehavior.AllowGet);
        }
    }
    catch (Exception ex)
    {
        string ruta = Server.MapPath("/Log");
        SM.Utilidades.Log.Log.WriteLog(ruta, ex.ToString());
        return Json(new List<SelectListItem>(), JsonRequestBehavior.AllowGet);
    }
}
