using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESORuleEngine
{
    public interface IVerifier
    {
        /// <summary>
        /// Checks whether the constraint on the current request session is satisfied or not
        /// </summary>
        /// <param name="context">context object representing the current OData interop session</param>
        /// <param name="result">output paramater to return detailed information if checking did not pass</param>
        /// <returns>true/false</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", Justification = "followed the interface definition")]
        bool Verify(ServiceContext context, out TestResult result);
    }
}
