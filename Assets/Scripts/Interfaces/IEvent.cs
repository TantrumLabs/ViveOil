/*  Creator: Eric Z Mouledoux
 *  Contact: Eric@TantrumLab.com
 *  
 *  Usage:
 *  
 *  Notes:
 * 
 */

public interface IEvent
{
    bool isComplete { get; set; }
    /// <summary>
    /// A refrence to the GameObject this is attached to.
    /// </summary>
    UnityEngine.GameObject self { get; }
}