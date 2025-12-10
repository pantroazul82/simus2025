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
-- Create date: 6 de octubre 2015
-- Description: Devuelve datos básicos de la escuela y su categoría
-- =============================================
CREATE PROCEDURE ART_MUSICA_NOMBRE_CATEGORIA
	@EscuelaId numeric (18, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT E.ENT_ID AS EscuelaId,
			E.ENT_NOMBRE as Nombre,
			ART_MUSICA_ENTIDAD_CATEGORIZACION.PORCENTAJE_TOTAL as Porcentaje, 
			ART_MUSICA_CATEGORIA_ESCUELA.DESCRIPCION_CATEGORIA as Categoria
	FROM ART_ENTIDADES_ARTES E
		LEFT OUTER JOIN aRT_MUSICA_ENTIDAD_CATEGORIZACION ON E.ENT_ID = ART_MUSICA_ENTIDAD_CATEGORIZACION.ENT_ID 
		LEFT OUTER JOIN ART_MUSICA_CATEGORIA_ESCUELA ON  ART_MUSICA_ENTIDAD_CATEGORIZACION.ID_CATEGORIA = ART_MUSICA_CATEGORIA_ESCUELA.ID_CATEGORIA
	WHERE E.ENT_ID = @EscuelaId
END
GO
