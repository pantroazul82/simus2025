SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Grey Milena Jimenez 
-- Create date: 20/11/2015
-- Description:	Trae los agentes creados por el usuario
-- =============================================
create PROCEDURE [dbo].[ART_MUSICA_AGENTE_datos_EstadoId]
	@EstadoId int
AS
BEGIN
	SELECT A.ID as AgenteId,
	   A.CodigoDepartamento,
	   A.CodMunicipio,
	   A.CodPais,
	   A.Telefono,
	   A.CodTipoDocumento,
	   A.CorreoElectronico,
	   A.Direccion,
	   A.FechaActualizacion,
	   A.Identificacion,
	   A.Imagen,
	   A.Sexo,
	   A.LinkPortafolio,
	   A.PrimerNombre + ' ' + ISNULL(A.SegundoNombre, '') AS Nombres,
	   A.PrimerApellido + ' ' + ISNULL(A.SedundoApellido, '') AS Apellidos,
	   A.PrimerNombre + ' ' + ISNULL(A.SegundoNombre, '') +  A.PrimerApellido + ' ' + ISNULL(A.SedundoApellido, '') as NombreCompleto,
	   P.ZOP_NOMBRE AS Pais,
	   D.ZON_NOMBRE as Departamento,
	   M.ZON_NOMBRE as Municipio,
	   E.Nombre AS Estado, 
	   A.Descripcion,
	   T.DOC_NOMBRE AS TipoDocumentoDescripcion
FROM ART_MUSICA_AGENTE A
INNER JOIN BAS_TIPOS_DOCUMENTOS_IDENTIDAD T ON A.CodTipoDocumento = T.DOC_ID
INNER JOIN BAS_ZONAS_PAISES P ON  A.CodPais = P.ZOP_ID
LEFT JOIN BAS_ZONAS_GEOGRAFICAS D ON A.CodigoDepartamento = D.ZON_ID
LEFT JOIN BAS_ZONAS_GEOGRAFICAS M ON A.CodMunicipio = M.ZON_ID
INNER JOIN ART_MUSICA_ESTADOS E ON A.EstadoId = E.Id
WHERE A.EstadoId = @EstadoId
order by a.PrimerNombre, a.PrimerApellido

   
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Grey Milena Jimenez 
-- Create date: 20/11/2015
-- Description:	Trae los agentes creados por el usuario
-- =============================================
create PROCEDURE [dbo].[ART_MUSICA_AGENTE_datos_UsuarioId]
	@usuarioId int
AS
BEGIN
	SELECT A.ID as AgenteId,
	   A.CodigoDepartamento,
	   A.CodMunicipio,
	   A.CodPais,
	   A.Telefono,
	   A.CodTipoDocumento,
	   A.CorreoElectronico,
	   A.Direccion,
	   A.FechaActualizacion,
	   A.Identificacion,
	   A.Imagen,
	   A.Sexo,
	   A.LinkPortafolio,
	   A.PrimerNombre + ' ' + ISNULL(A.SegundoNombre, '') AS Nombres,
	   A.PrimerApellido + ' ' + ISNULL(A.SedundoApellido, '') AS Apellidos,
	   A.PrimerNombre + ' ' + ISNULL(A.SegundoNombre, '') +  A.PrimerApellido + ' ' + ISNULL(A.SedundoApellido, '') as NombreCompleto,
	   P.ZOP_NOMBRE AS Pais,
	   D.ZON_NOMBRE as Departamento,
	   M.ZON_NOMBRE as Municipio,
	   E.Nombre AS Estado, 
	   A.Descripcion,
	   T.DOC_NOMBRE AS TipoDocumentoDescripcion
FROM ART_MUSICA_AGENTE A
INNER JOIN BAS_TIPOS_DOCUMENTOS_IDENTIDAD T ON A.CodTipoDocumento = T.DOC_ID
INNER JOIN BAS_ZONAS_PAISES P ON  A.CodPais = P.ZOP_ID
LEFT JOIN BAS_ZONAS_GEOGRAFICAS D ON A.CodigoDepartamento = D.ZON_ID
LEFT JOIN BAS_ZONAS_GEOGRAFICAS M ON A.CodMunicipio = M.ZON_ID
INNER JOIN ART_MUSICA_ESTADOS E ON A.EstadoId = E.Id
WHERE A.IdADM_ART_USUARIO = @usuarioId
order by a.PrimerNombre, a.PrimerApellido

   
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Grey Milena Jimenez 
-- Create date: 20/11/2015
-- Description:	Detalle de un agente
-- =============================================
create PROCEDURE [dbo].[ART_MUSICA_AGENTE_datos_Id]
	@AgenteId int
AS
BEGIN
	SELECT A.ID as AgenteId,
	   A.CodigoDepartamento,
	   A.CodMunicipio,
	   A.CodPais,
	   A.Telefono,
	   A.CodTipoDocumento,
	   A.CorreoElectronico,
	   A.Direccion,
	   A.FechaActualizacion,
	   A.Identificacion,
	   A.Imagen,
	   A.Sexo,
	    A.LinkPortafolio,
	   A.PrimerNombre + ' ' + ISNULL(A.SegundoNombre, '') AS Nombres,
	   A.PrimerApellido + ' ' + ISNULL(A.SedundoApellido, '') AS Apellidos,
	   A.PrimerNombre + ' ' + ISNULL(A.SegundoNombre, '') +  A.PrimerApellido + ' ' + ISNULL(A.SedundoApellido, '') as NombreCompleto,
	   P.ZOP_NOMBRE AS Pais,
	   D.ZON_NOMBRE as Departamento,
	   M.ZON_NOMBRE as Municipio,
	   E.Nombre AS Estado, 
	   A.Descripcion,
	   T.DOC_NOMBRE AS TipoDocumentoDescripcion
FROM ART_MUSICA_AGENTE A
INNER JOIN BAS_TIPOS_DOCUMENTOS_IDENTIDAD T ON A.CodTipoDocumento = T.DOC_ID
INNER JOIN BAS_ZONAS_PAISES P ON  A.CodPais = P.ZOP_ID
LEFT JOIN BAS_ZONAS_GEOGRAFICAS D ON A.CodigoDepartamento = D.ZON_ID
LEFT JOIN BAS_ZONAS_GEOGRAFICAS M ON A.CodMunicipio = M.ZON_ID
INNER JOIN ART_MUSICA_ESTADOS E ON A.EstadoId = E.Id
WHERE A.ID = @AgenteId

   
END
GO


/* TRAE TODOS LOS AGENTES */

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Grey Milena Jimenez 
-- Create date: 20/11/2015
-- Description:	Trae todos los agentes
-- =============================================
create PROCEDURE [dbo].[ART_MUSICA_AGENTE_Todos]
	
AS
BEGIN
	SELECT A.ID as AgenteId,
	   A.CodigoDepartamento,
	   A.CodMunicipio,
	   A.CodPais,
	   A.CodTipoDocumento,
	   A.CorreoElectronico,
	   A.Direccion,
	   A.FechaActualizacion,
	   A.Identificacion,
	   A.Imagen,
	   A.LinkPortafolio,
	   A.PrimerNombre + ' ' + ISNULL(A.SegundoNombre, '') AS Nombres,
	   A.PrimerApellido + ' ' + ISNULL(A.SedundoApellido, '') AS Apellidos,
	   A.PrimerNombre + ' ' + ISNULL(A.SegundoNombre, '') + ' ' +  A.PrimerApellido + ' ' + ISNULL(A.SedundoApellido, '') as NombreCompleto,
	   P.ZOP_NOMBRE AS Pais,
	   D.ZON_NOMBRE as Departamento,
	   M.ZON_NOMBRE as Municipio,
	   E.Nombre AS Estado, 
	   A.Descripcion
FROM ART_MUSICA_AGENTE A
INNER JOIN BAS_TIPOS_DOCUMENTOS_IDENTIDAD T ON A.CodTipoDocumento = T.DOC_ID
INNER JOIN BAS_ZONAS_PAISES P ON  A.CodPais = P.ZOP_ID
LEFT JOIN BAS_ZONAS_GEOGRAFICAS D ON A.CodigoDepartamento = D.ZON_ID
LEFT JOIN BAS_ZONAS_GEOGRAFICAS M ON A.CodMunicipio = M.ZON_ID
INNER JOIN ART_MUSICA_ESTADOS E ON A.EstadoId = E.Id
ORDER BY A.PrimerNombre, A.PrimerApellido

    
END
GO

