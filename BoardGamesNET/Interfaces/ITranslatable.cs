namespace BoardGamesNET.Interfaces
{
    /// <summary>
    /// Interface that contains the informations for tranlatable elements.
    /// </summary>
    public interface ITranslatable
    {
        /// <summary>
        /// Language reference, where reference is the ID of the row of the database where is stored the tranlation.
        /// </summary>
        long LanguageReference { get; set; }

        /// <summary>
        /// Event to manage the <see cref="LanguageReference"/> change.
        /// </summary>
        event EventHandler<long> LanguageReferenceChangedEvent;
    }
}
