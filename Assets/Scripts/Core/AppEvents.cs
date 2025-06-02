using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core
{
    public static class AppEvents
    {
        // Activated when a call is made to the API
        public static Action OnAPICallBegin;

        // Activated when an API call is completed
        // bool: true if successful, false if error
        public static Action<bool> OnAPICallEnd;
    }
}
