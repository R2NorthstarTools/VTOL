using System;
using System.Collections.Generic;
using System.Text;

namespace VTOL
{
    public enum UpdaterState
    {
        Idle,
        GettingRepository,
        CheckingForUpdate,
        Downloading,
        Installing,
        RollingBack
    }
}
