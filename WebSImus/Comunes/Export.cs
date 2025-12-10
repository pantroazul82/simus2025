using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebSImus.Comunes
{
    public static class Export
    {
        /// <summary>
        /// Convertir list BasicoReporteDTO to DATASET
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataSet ToDataSet(List<BasicoReporteDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Total", typeof(int));

            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.label;
                row["Total"] = item.value;

                t.Rows.Add(row);

            }

            return ds;
        }

        public static DataSet ToDataSet(List<BasicoReporteDTO> list, int valueadd)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Total", typeof(int));



            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.label;
                row["Total"] = valueadd / int.Parse(item.value);//estudiantes/profesores

                t.Rows.Add(row);

            }

            return ds;
        }


        public static DataSet ToDataSetComplexNaturaleza(List<ReporteDescargarDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Municipio", typeof(String));
            t.Columns.Add("CodMunicipio", typeof(String));
            t.Columns.Add("Nombre", typeof(String));
            t.Columns.Add("Naturaleza", typeof(String));


            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.Departamento;
                row["Municipio"] = item.Municipio;
                row["CodMunicipio"] = item.codMunicipio;
                row["Nombre"] = item.Nombre;
                row["Naturaleza"] = item.Naturaleza;
                t.Rows.Add(row);

            }

            return ds;
        }

        public static DataSet ToDataSetComplexLegalmente(List<ReporteDescargarDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Municipio", typeof(String));
            t.Columns.Add("CodMunicipio", typeof(String));
            t.Columns.Add("Nombre", typeof(String));
            t.Columns.Add("Naturaleza", typeof(String));
            t.Columns.Add("Legalmente", typeof(String));

            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.Departamento;
                row["Municipio"] = item.Municipio;
                row["CodMunicipio"] = item.codMunicipio;
                row["Nombre"] = item.Nombre;
                row["Naturaleza"] = item.Naturaleza;
                row["Legalmente"] = item.criterio6;
                t.Rows.Add(row);

            }

            return ds;
        }

        public static DataSet ToDataSetComplexTipoEscuela(List<ReporteDescargarDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Municipio", typeof(String));
            t.Columns.Add("CodMunicipio", typeof(String));
            t.Columns.Add("Nombre", typeof(String));
            t.Columns.Add("Naturaleza", typeof(String));
            t.Columns.Add("TipoEscuela", typeof(String));

            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.Departamento;
                row["Municipio"] = item.Municipio;
                row["CodMunicipio"] = item.codMunicipio;
                row["Nombre"] = item.Nombre;
                row["Naturaleza"] = item.Naturaleza;
                row["TipoEscuela"] = item.criterio6;
                t.Rows.Add(row);

            }

            return ds;
        }

        public static DataSet ToDataSetComplexFamiliaInstrumental(List<ReporteDescargarDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Municipio", typeof(String));
            t.Columns.Add("CodMunicipio", typeof(String));
            t.Columns.Add("Nombre", typeof(String));
            t.Columns.Add("Naturaleza", typeof(String));
            t.Columns.Add("CuerdasPulsadas", typeof(String));
            t.Columns.Add("CuerdasSinfónicas", typeof(String));
            t.Columns.Add("VientosMaderas", typeof(String));
            t.Columns.Add("VientosMetales", typeof(String));
            t.Columns.Add("PercusiónMenor", typeof(String));
            t.Columns.Add("PercusiónSinfónica", typeof(String));
            t.Columns.Add("OtrosInstrumentos", typeof(String));
            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.Departamento;
                row["Municipio"] = item.Municipio;
                row["CodMunicipio"] = item.codMunicipio;
                row["Nombre"] = item.Nombre;
                row["Naturaleza"] = item.Naturaleza;
                row["CuerdasPulsadas"] = item.criterio6;
                row["CuerdasSinfónicas"] = item.criterio7;
                row["VientosMaderas"] = item.criterio12;
                row["VientosMetales"] = item.criterio19;
                row["PercusiónMenor"] = item.criterio26;
                row["PercusiónSinfónica"] = item.criterio27;
                row["OtrosInstrumentos"] = item.criterio28;
                t.Rows.Add(row);

            }

            return ds;
        }

        public static DataSet ToDataSetComplexPracticaMusical(List<ReporteDescargarDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Municipio", typeof(String));
            t.Columns.Add("CodMunicipio", typeof(String));
            t.Columns.Add("Nombre", typeof(String));
            t.Columns.Add("Naturaleza", typeof(String));
            t.Columns.Add("Banda", typeof(String));
            t.Columns.Add("MúsicaTradicional", typeof(String));
            t.Columns.Add("Coros", typeof(String));
            t.Columns.Add("Orquesta", typeof(String));
            t.Columns.Add("Urbana", typeof(String));
            t.Columns.Add("IniciaciónMusical", typeof(String));
         
            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.Departamento;
                row["Municipio"] = item.Municipio;
                row["CodMunicipio"] = item.codMunicipio;
                row["Nombre"] = item.Nombre;
                row["Naturaleza"] = item.Naturaleza;
                row["Banda"] = item.criterio6;
                row["MúsicaTradicional"] = item.criterio7;
                row["Coros"] = item.criterio12;
                row["Orquesta"] = item.criterio19;
                row["Urbana"] = item.criterio26;
                row["IniciaciónMusical"] = item.criterio27;
                t.Rows.Add(row);

            }

            return ds;
        }

        public static DataSet ToDataSetComplexRangoEtarios(List<ReporteDescargarDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Municipio", typeof(String));
            t.Columns.Add("CodMunicipio", typeof(String));
            t.Columns.Add("Nombre", typeof(String));
            t.Columns.Add("Naturaleza", typeof(String));
            t.Columns.Add("Menorde6", typeof(String));
            t.Columns.Add("Entre6y11", typeof(String));
            t.Columns.Add("Entre12y18", typeof(String));
            t.Columns.Add("Entre19y25", typeof(String));
            t.Columns.Add("Entre26y60", typeof(String));
            t.Columns.Add("Mayoresde60", typeof(String));
         
            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.Departamento;
                row["Municipio"] = item.Municipio;
                row["CodMunicipio"] = item.codMunicipio;
                row["Nombre"] = item.Nombre;
                row["Naturaleza"] = item.Naturaleza;
                row["Menorde6"] = item.criterio6;
                row["Entre6y11"] = item.criterio7;
                row["Entre12y18"] = item.criterio12;
                row["Entre19y25"] = item.criterio19;
                row["Entre26y60"] = item.criterio26;
                row["Mayoresde60"] = item.criterio27;
                 t.Rows.Add(row);

            }

            return ds;
        }

        public static DataSet ToDataSetComplexDocentes(List<ReporteDescargarDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Municipio", typeof(String));
            t.Columns.Add("CodMunicipio", typeof(String));
            t.Columns.Add("Nombre", typeof(String));
            t.Columns.Add("Naturaleza", typeof(String));
            t.Columns.Add("Primaria", typeof(String));
            t.Columns.Add("Secundaria", typeof(String));
            t.Columns.Add("Tecnico", typeof(String));
            t.Columns.Add("PregradoIncompleto", typeof(String));
            t.Columns.Add("PregradoMusica", typeof(String));
            t.Columns.Add("PregradoOtraArea", typeof(String));
            t.Columns.Add("Posgrado", typeof(String));
            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.Departamento;
                row["Municipio"] = item.Municipio;
                row["CodMunicipio"] = item.codMunicipio;
                row["Nombre"] = item.Nombre;
                row["Naturaleza"] = item.Naturaleza;
                row["Primaria"] = item.criterio6;
                row["Secundaria"] = item.criterio7;
                row["Tecnico"] = item.criterio12;
                row["PregradoIncompleto"] = item.criterio19;
                row["PregradoMusica"] = item.criterio26;
                row["PregradoOtraArea"] = item.criterio27;
                row["Posgrado"] = item.criterio28;
                t.Rows.Add(row);

            }

            return ds;
        }

        public static DataSet ToDataSetComplexCirculacion(List<ReporteDescargarDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Municipio", typeof(String));
            t.Columns.Add("CodMunicipio", typeof(String));
            t.Columns.Add("Nombre", typeof(String));
            t.Columns.Add("Naturaleza", typeof(String));
            t.Columns.Add("Local", typeof(String));
            t.Columns.Add("Nacional", typeof(String));
            t.Columns.Add("Internacional", typeof(String));
          
            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.Departamento;
                row["Municipio"] = item.Municipio;
                row["CodMunicipio"] = item.codMunicipio;
                row["Nombre"] = item.Nombre;
                row["Naturaleza"] = item.Naturaleza;
                row["Local"] = item.criterio6;
                row["Nacional"] = item.criterio7;
                row["Internacional"] = item.criterio12;
               
                t.Rows.Add(row);

            }

            return ds;
        }
        public static DataSet ToDataSetComplexGrupoEtnico(List<ReporteDescargarDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Municipio", typeof(String));
            t.Columns.Add("CodMunicipio", typeof(String));
            t.Columns.Add("Nombre", typeof(String));
            t.Columns.Add("Naturaleza", typeof(String));
            t.Columns.Add("Afrocolombiana", typeof(String));
            t.Columns.Add("Raizales", typeof(String));
            t.Columns.Add("ROM", typeof(String));
            t.Columns.Add("Indigenas", typeof(String));
          

            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.Departamento;
                row["Municipio"] = item.Municipio;
                row["CodMunicipio"] = item.codMunicipio;
                row["Nombre"] = item.Nombre;
                row["Naturaleza"] = item.Naturaleza;
                row["Afrocolombiana"] = item.criterio6;
                row["Raizales"] = item.criterio7;
                row["ROM"] = item.criterio12;
                row["Indigenas"] = item.criterio19;
           
                t.Rows.Add(row);

            }

            return ds;
        }
        public static DataSet ToDataSetComplexUbicacion(List<ReporteDescargarDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Municipio", typeof(String));
            t.Columns.Add("CodMunicipio", typeof(String));
            t.Columns.Add("Nombre", typeof(String));
            t.Columns.Add("Naturaleza", typeof(String));
            t.Columns.Add("Urbana", typeof(String));
            t.Columns.Add("Rural", typeof(String));
          
            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.Departamento;
                row["Municipio"] = item.Municipio;
                row["CodMunicipio"] = item.codMunicipio;
                row["Nombre"] = item.Nombre;
                row["Naturaleza"] = item.Naturaleza;
                row["Urbana"] = item.criterio6;
                row["Rural"] = item.criterio7;
               
                t.Rows.Add(row);

            }

            return ds;
        }

        public static DataSet ToDataSetComplexSexo(List<ReporteDescargarDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Municipio", typeof(String));
            t.Columns.Add("CodMunicipio", typeof(String));
            t.Columns.Add("Nombre", typeof(String));
            t.Columns.Add("Naturaleza", typeof(String));
            t.Columns.Add("Femenino", typeof(String));
            t.Columns.Add("Masculino", typeof(String));

            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.Departamento;
                row["Municipio"] = item.Municipio;
                row["CodMunicipio"] = item.codMunicipio;
                row["Nombre"] = item.Nombre;
                row["Naturaleza"] = item.Naturaleza;
                row["Femenino"] = item.criterio6;
                row["Masculino"] = item.criterio7;

                t.Rows.Add(row);

            }

            return ds;
        }
        public static DataSet ToDataSetComplex(List<ReporteComplexDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Menorde6", typeof(int));
            t.Columns.Add("Entre7y11", typeof(int));
            t.Columns.Add("Entre12y18", typeof(int));
            t.Columns.Add("Entre19y25", typeof(int));
            t.Columns.Add("Mayora26", typeof(int));


            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.departamento;
                row["Menorde6"] = item.criterio6;
                row["Entre7y11"] = item.criterio7;
                row["Entre12y18"] = item.criterio12;
                row["Entre19y25"] = item.criterio19;
                row["Mayora26"] = item.criterio26;
                t.Rows.Add(row);

            }

            return ds;
        }
        /// <summary>
        /// Cantidad de escuelas por estado de consolidación
        /// Practicas musicales en las escuelas DPTO
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataSet ToDataSetComplexConslDpto(List<ReporteComplexDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));


            List<string> lstCat = new List<string>();
            foreach (var item in list)
            {

                if (!lstCat.Exists(X => X == item.criterio6))
                {
                    t.Columns.Add(item.criterio6, typeof(String));
                    lstCat.Add(item.criterio6);
                }
            }

            //  t.Columns.Add("Total", typeof(int));


            //go through each property on T and add each value to the table
            List<string> lstdpto = new List<string>();
        
            foreach (var item in list)
            {

                if (!lstdpto.Exists(X => X == item.departamento))
                {
                    DataRow row = t.NewRow();
                    row["Departamento"] = item.departamento;
                    row[item.criterio6] = item.criterio7;
                   
                    lstdpto.Add(item.departamento);
                    t.Rows.Add(row);
                }


            }


            foreach (DataRow item in t.Rows)
            {
                string dpto = (string)item["Departamento"];

                foreach (var ct in lstCat)
                {
                    item[ct] = obtenerValorConsilicaion(list, dpto, ct);
                }

            }




            return ds;
        }


        private static string obtenerValorConsilicaion(List<ReporteComplexDTO> list, string dpto, string cat)
        {
            string value = "0";

            var respuesta = list.Find(x => x.departamento.Equals(dpto) && x.criterio6.Equals(cat));
            if (respuesta != null)
            {
                value = respuesta.criterio7;
            }



            return value;
        }


        /// <summary>
        /// Cantidad de participaciones de los estudiantes en escenarios
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataSet ToDataSetComplexEstudiantesESC(List<ReporteComplexDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("Giras", typeof(String));
            //t.Columns.Add("CantidadPresentacionesLocalesUltimoAño", typeof(String));
            //t.Columns.Add("CantidadGirasInterUltimoAño", typeof(String));


            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.departamento;
                row["Giras"] =  Convert.ToString( Convert.ToDecimal( item.criterio6 )+ Convert.ToDecimal( item.criterio7) + Convert.ToDecimal( item.criterio12));
                //row["CantidadPresentacionesLocalesUltimoAño"] = item.criterio7;
                //row["CantidadGirasInterUltimoAño"] = item.criterio12;
                t.Rows.Add(row);

            }

            return ds;
        }


        public static DataSet ToDataSetProfesorDpto(List<ReporteProfesorDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("primaria", typeof(int));
            t.Columns.Add("Secundaria", typeof(int));
            t.Columns.Add("Tecnico", typeof(int));
            t.Columns.Add("Universitario", typeof(int));
            t.Columns.Add("PregardoMusica", typeof(int));
            t.Columns.Add("OtroPregrado", typeof(int));


            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.departamento;
                row["primaria"] = item.primaria;
                row["Secundaria"] = item.secundaria;
                row["Tecnico"] = item.tecnico;
                row["Universitario"] = item.universiatrio;
                row["PregardoMusica"] = item.pregradomusica;
                row["OtroPregrado"] = item.pregradootra;
                t.Rows.Add(row);

            }

            return ds;
        }

        public static DataSet ToDataSetInstrumentoDpto(List<ReporteInstrumentoDTO> list)
        {
            Type elementType = list.GetType();

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            t.Columns.Add("Departamento", typeof(String));
            t.Columns.Add("CuerdaPulsada", typeof(int));
            t.Columns.Add("CuerdaSinfonica", typeof(int));
            t.Columns.Add("VientoMadera", typeof(int));
            t.Columns.Add("PercusionMenor", typeof(int));
            t.Columns.Add("PercusionSinfonica", typeof(int));
            t.Columns.Add("OtroInstrumento", typeof(int));



            //go through each property on T and add each value to the table
            foreach (var item in list)
            {
                DataRow row = t.NewRow();

                row["Departamento"] = item.departamento;
                row["CuerdaPulsada"] = item.cuerdapulsada;
                row["CuerdaSinfonica"] = item.cuerdassinf;
                row["VientoMadera"] = item.vientomadera;
                row["PercusionMenor"] = item.pmenor;
                row["PercusionSinfonica"] = item.psinfonica;
                row["OtroInstrumento"] = item.instrumentootra;
                t.Rows.Add(row);

            }

            return ds;
        }





    }
}