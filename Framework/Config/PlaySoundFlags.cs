
namespace TLF.Framework.Config
{
    #region :: PlaySoundFlags ::

    /// <summary>
    /// PlaySoundFlags
    /// </summary>
    public enum PlaySoundFlags : int
    {
        /// <summary>
        /// Play Synchronously(default)
        /// </summary>
        SND_SYNC = 0x0,
        /// <summary>
        /// Play Asynchronously
        /// </summary>
        SND_ASYNC = 0x1,
        /// <summary>
        /// Silence (!default) if sound not found
        /// </summary>
        SND_NODEFAULT = 0x2,
        /// <summary>
        /// pszSound points to a memory file
        /// </summary>
        SND_MEMORY = 0x4,
        /// <summary>
        /// loop the sound until next sndPlaySound
        /// </summary>
        SND_LOOP = 0x8,
        /// <summary>
        /// don't stop any currently playing sound
        /// </summary>
        SND_NOSTOP = 0x10,
        /// <summary>
        /// don't wait if the driver is busy
        /// </summary>
        SND_NOWAIT = 0x2000,
        /// <summary>
        /// name is a registry alias
        /// </summary>
        SND_ALIAS = 0x10000,
        /// <summary>
        /// alias is a predefined ID
        /// </summary>
        SND_ALIAS_ID = 0x110000,
        /// <summary>
        /// name is file name
        /// </summary>
        SND_FILENAME = 0x20000,
        /// <summary>
        /// name is resource name or atom
        /// </summary>
        SND_RESOURCE = 0x40004
    }

    #endregion
}
