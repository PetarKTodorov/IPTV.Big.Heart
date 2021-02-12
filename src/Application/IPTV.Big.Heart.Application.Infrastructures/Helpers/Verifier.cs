namespace IPTV.Big.Heart.Application.Infrastructures.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using IPTV.Big.Heart.Application.Common.Constants;
    using Microsoft.VisualBasic.CompilerServices;

    public static class Verifier
    {
        public static Guid CheckId(string id, ICollection<string> errors)
        {
            Guid verifiedId = Guid.Empty;

            bool isInvalidId = Guid.TryParse(id, out verifiedId) == false;

            if (isInvalidId)
            {
                errors.Add(ApplicationConstants.InvalidIdMessage);
            }

            return verifiedId;            
        }
    }
}
