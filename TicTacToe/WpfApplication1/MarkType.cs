using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    /// <summary>
    /// The type of the cell currently is at
    /// </summary>
    public enum MarkType
    {   
        /// <summary>
        /// The button is not clicked, default value
        /// </summary>
        Free,
        /// <summary>
        /// The value is 'O'
        /// </summary>
        Nought,
        /// <summary>
        /// The value is 'X'
        /// </summary>
        Cross
    }
}
