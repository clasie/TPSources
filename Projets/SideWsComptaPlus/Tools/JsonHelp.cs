using System.Web.Script.Serialization;

namespace SideWsComptaPlus.Tools
{
    /// <summary>
    /// Class : JSon 
    /// </summary>
    public class JsonHelp
    {
        #region Membres
        /// <summary>
        /// Member  :   Sérialisation en JavaScript -> JSON
        /// </summary>
        private static JavaScriptSerializer _jsonSerialize;
        #endregion
        
        #region Methods
        /// <summary>
        /// Method  :   Sérialiser l'objet à Json
        /// </summary>
        /// <typeparam name="T">Obtient le schéma de la class Business</typeparam>
        /// <param name="objList">Obtient les données de la class Business déclarée</param>
        /// <returns>Renvoyer une donnée json</returns>
        public static string JsonSerialize<T>(T objList)
        {
            _jsonSerialize = new JavaScriptSerializer();
            return _jsonSerialize.Serialize(objList);
        }

        /// <summary>
        /// Method  :   Désérialiser json sur un objet
        /// </summary>
        /// <typeparam name="T">Obtient le schéma de la class Business</typeparam>
        /// <param name="strJson">Obtient la chaîne au format Json</param>
        /// <returns>Renvoyer la/les donnée(s) suivant le schéma de la Class Business</returns>
        public static T JsonDeserialize<T>(string strJson)
        {
            _jsonSerialize = new JavaScriptSerializer();
            return _jsonSerialize.Deserialize<T>(strJson);
        }
        #endregion
    }
}
