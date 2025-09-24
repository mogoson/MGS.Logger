/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IFilter.cs
 *  Description  :  Interface for log filter.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/15/2021
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Logger
{
    /// <summary>
    /// Interface for log filter.
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Check message is selected?
        /// </summary>
        /// <param name="tag">Tag of log message.</param>
        /// <param name="content">Content of log.</param>
        /// <returns>The message is selected?</returns>
        bool Select(string tag, string content);
    }
}