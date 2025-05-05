﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicReview.Domain.Interfaces
{
    public interface IAppLogger
    {
        void LogInfo(string message);
        void LogError(string message);
    }
}
