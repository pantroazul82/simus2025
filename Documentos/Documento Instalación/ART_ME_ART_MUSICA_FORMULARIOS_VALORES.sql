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
-- Create date: Septiembre 10 de 2015
-- Description:	Trae los valores de las columnas de losFormularios dinámicos
-- =============================================
CREATE PROCEDURE ART_ME_ART_MUSICA_FORMULARIOS_VALORES
	-- Add the parameters for the stored procedure here
	@ENT_ID numeric(18, 0),
	@FormularioId numeric(18, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ART_ME_FORMULARIOS_VALORES.FVA_ID, 
			ART_ME_FORMULARIOS_VALORES.FVA_VALOR, 
			ART_ME_FORMULARIOS_VALORES.FCO_ID, ART_ME_FORMULARIOS_VALORES.FRE_ID, 
			ART_ME_FORMULARIOS_VALORES.FOR_ID, ART_ME_FORMULARIOS_VALORES.FVA_DUPLICACION, 
			ART_ME_FORMULARIOS_COLUMNAS.FCO_NOMBRE 
	FROM ART_ME_FORMULARIOS_VALORES 
	INNER JOIN ART_ME_FORMULARIOS_COLUMNAS ON ART_ME_FORMULARIOS_VALORES.FCO_ID = ART_ME_FORMULARIOS_COLUMNAS.FCO_ID 
	WHERE (ART_ME_FORMULARIOS_VALORES.FOR_ID = @FormularioId) 
	AND (ART_ME_FORMULARIOS_VALORES.FRE_ID = (SELECT FRE_ID FROM ART_ME_FORMULARIOS_REGISTRO WHERE (ENT_ID = @ENT_ID) 
											AND (FRE_FECHA_REGISTRO = (SELECT MAX(FRE_FECHA_REGISTRO) AS Expr1 
											FROM ART_ME_FORMULARIOS_REGISTRO AS ART_ME_FORMULARIOS_REGISTRO_1 WHERE (ENT_ID = @ENT_ID)))))
											
END
GO
