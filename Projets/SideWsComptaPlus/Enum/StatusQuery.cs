namespace SideWsComptaPlus.Enum
{
    /// <summary>
    /// Enumerator  :   Etat de travail pour le Query
    /// </summary>
    public enum StatusQuery
    {
        /// <summary>
        /// Ajouter = INSERT INTO
        /// </summary>
        Create = 0,
        /// <summary>
        /// Modifier = UPDATE
        /// </summary>
        Update = 1 ,
        /// <summary>
        /// Supprimer = DELETE
        /// </summary>
        Delete = 2,
        /// <summary>
        /// Réserver pour un usage futur.
        /// </summary>
        ReservedElement = 3
    }
}