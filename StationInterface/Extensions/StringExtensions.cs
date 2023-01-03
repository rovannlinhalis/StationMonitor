using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace StationInterface.Extensions
{
    public static class StringExtensions
    {
        #region Normalização

        /// <summary>
        /// Remove os acentos de uma string
        /// </summary>
        /// <param name="texto">ÁÉÍÓÚ</param>
        /// <returns>AEIOU</returns>
        public static string RemoverAcentos(this string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return String.Empty;

            byte[] bytes = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(texto);
            return Encoding.UTF8.GetString(bytes,0,bytes.Length);
        }


        /// <summary>
        /// Remove a pontuação de uma string
        /// </summary>
        /// <param name="texto">(--Teste--) ; [1.2.3]</param>
        /// <returns>Teste123</returns>
        public static string RemoverPontuacao(this string texto)
        {
            string retorno;
            if (texto != null)
            {
                retorno = texto;
                retorno = retorno.Replace("(", "");
                retorno = retorno.Replace(")", "");
                retorno = retorno.Replace("-", "");
                retorno = retorno.Replace(".", "");
                retorno = retorno.Replace(";", "");
                retorno = retorno.Replace(",", "");
                retorno = retorno.Replace("/", "");
                retorno = retorno.Replace(@"\", "");
                retorno = retorno.Replace("'", "");
                retorno = retorno.Replace("*", "");
                retorno = retorno.Replace("+", "");
                retorno = retorno.Replace("[", "");
                retorno = retorno.Replace("]", "");
                retorno = retorno.Replace("{", "");
                retorno = retorno.Replace("}", "");
                retorno = retorno.Replace("º", "");
                retorno = retorno.Replace("ª", "");
                retorno = retorno.Replace("°", "");
                retorno = retorno.Replace("=", "");
                //retorno = retorno.Replace(" ", "");
                retorno = retorno.Replace(":", "");
            }
            else
            {
                retorno = null;
            }
            return retorno;
        }

        /// <summary>
        /// Remove caracteres numéricos de uma string 0 a 9
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string RemoverNumeros(this string texto)
        {
            texto = texto.Replace("0", "");
            texto = texto.Replace("1", "");
            texto = texto.Replace("2", "");
            texto = texto.Replace("3", "");
            texto = texto.Replace("4", "");
            texto = texto.Replace("5", "");
            texto = texto.Replace("6", "");
            texto = texto.Replace("7", "");
            texto = texto.Replace("8", "");
            texto = texto.Replace("9", "");
            return texto;
        }

        /// <summary>
        /// Retorna uma string normalizada (sem acentos ou pontuação, em UpperCase)
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>string</returns>
        public static string NormalizeExt(this string s)
        {
            return s.ToUpper().RemoverAcentos().RemoverPontuacao();
        }

        /// <summary>
        /// Retorna a string em snake_case
        /// </summary>
        /// <param name="input">SnakeCase</param>
        /// <returns>snake_case</returns>
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }

        public static bool IsEmail(this string s)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return rg.IsMatch(s);
        }

        public static string ToShortDateString(this DateTime? data)
        {
            if (data == null)
                return null;
            else
            {
                return ((DateTime)data).ToString("dd/MM/yyyy");
            }
        }


        #endregion

    }
}
