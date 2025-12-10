-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Grey Milena Jiménez
-- Create date: Octubre 15 de 2015
-- Description:	obtener los valores del formulario dinámico
-- =============================================
CREATE PROCEDURE ART_MUSICA_OBTENER_VALORES_FORMULARIOS
@FormularioId numeric(18,0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT ART_ME_FORMULARIOS_COLUMNAS.FCO_ID, ART_ME_FORMULARIOS_COLUMNAS.FCO_NOMBRE, 
			ART_ME_FORMULARIOS_COLUMNAS.FCO_DESCRIPCION, ART_ME_FORMULARIOS_COLUMNAS.FCO_TIPODATO,
			ART_ME_FORMULARIOS_COLUMNAS.FCO_ESOBLIGATORIA, ART_ME_FORMULARIOS_COLUMNAS.FLI_ID,
			ART_ME_FORMULARIOS_COLUMNAS.FOR_ID, ART_ME_FORMULARIOS_COLUMNAS.FCO_ORDEN, 
			ART_ME_FORMULARIOS_COLUMNAS.FSC_ID, ART_ME_FORMULARIOS_SECCIONES.FSC_NOMBRE,
			ART_ME_FORMULARIOS_SECCIONES.FSC_DUPLICACIONES 
	FROM ART_ME_FORMULARIOS_COLUMNAS 
   LEFT OUTER JOIN ART_ME_FORMULARIOS_SECCIONES ON ART_ME_FORMULARIOS_COLUMNAS.FSC_ID = ART_ME_FORMULARIOS_SECCIONES.FSC_ID 
   WHERE (ART_ME_FORMULARIOS_COLUMNAS.FOR_ID = @FormularioId) 
   ORDER BY ART_ME_FORMULARIOS_COLUMNAS.FCO_ORDEN
END
GO

/* OBTENER SECCIONES*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Grey Milena Jiménez
-- Create date: 15 de octubre de 2015
-- Description:	obtener las secciones
-- =============================================
CREATE PROCEDURE ART_MUSICA_OBTENER_SECCIONES
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select DISTINCT S.FSC_ID,
		S.FSC_NOMBRE,
		S.FSC_DUPLICACIONES,
		S.FOR_ID 
		from ART_ME_FORMULARIOS_SECCIONES S
		INNER JOIN ART_ME_FORMULARIOS_COLUMNAS C ON S.FSC_ID = C.FSC_ID
		where S.FOR_ID IN (SELECT FOR_ID FROM ART_ME_FORMULARIOS A WHERE A.FOR_ESACTIVA ='S')
END
GO

/* OBTENER CAMPOS FORMULARIOS*/
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Grey Milena Jiménez
-- Create date: Octubre 15 de 2015
-- Description:	obtener los valores del formulario dinámico
-- =============================================
CREATE PROCEDURE ART_MUSICA_OBTENER_VALORES_FORMULARIOS_TODOS

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT ART_ME_FORMULARIOS_COLUMNAS.FCO_ID, ART_ME_FORMULARIOS_COLUMNAS.FCO_NOMBRE, 
			ART_ME_FORMULARIOS_COLUMNAS.FCO_DESCRIPCION, ART_ME_FORMULARIOS_COLUMNAS.FCO_TIPODATO,
			ART_ME_FORMULARIOS_COLUMNAS.FCO_ESOBLIGATORIA, ART_ME_FORMULARIOS_COLUMNAS.FLI_ID,
			ART_ME_FORMULARIOS_COLUMNAS.FOR_ID, ART_ME_FORMULARIOS_COLUMNAS.FCO_ORDEN, 
			ART_ME_FORMULARIOS_COLUMNAS.FSC_ID, ART_ME_FORMULARIOS_SECCIONES.FSC_NOMBRE,
			ART_ME_FORMULARIOS_SECCIONES.FSC_DUPLICACIONES 
	FROM ART_ME_FORMULARIOS_COLUMNAS 
   LEFT OUTER JOIN ART_ME_FORMULARIOS_SECCIONES ON ART_ME_FORMULARIOS_COLUMNAS.FSC_ID = ART_ME_FORMULARIOS_SECCIONES.FSC_ID 
   WHERE (ART_ME_FORMULARIOS_COLUMNAS.FOR_ID IN (SELECT FOR_ID FROM ART_ME_FORMULARIOS A WHERE A.FOR_ESACTIVA ='S')) 
   ORDER BY ART_ME_FORMULARIOS_COLUMNAS.FCO_ORDEN
END
GO
