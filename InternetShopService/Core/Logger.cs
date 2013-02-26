﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetShopService.Core
{
    public class Logger
    {
        private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static log4net.ILog Log
        {
            get
            {
                return log;
            }
        }
    }
}