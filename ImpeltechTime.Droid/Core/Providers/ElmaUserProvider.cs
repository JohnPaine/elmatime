﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;
using ImpeltechTime.Droid.Core.Internal;
using ImpeltechTime.Droid.Core.Model;
using ImpeltechTime.Droid.Core.Model.Providers;

namespace ImpeltechTime.Droid.Core.Providers
{
    public sealed class ElmaUserProvider : IElmaUserProvider
    {
        private readonly IElmaWcfService _wcfService;

        public ElmaUserProvider (IElmaServiceProvider elmaServiceProvider) {
            _wcfService = elmaServiceProvider.ElmaWcfService;
        }

        public IElmaUser LoginUser (string accName, string pass) {
            return _wcfService.LoginUser (accName, pass);
        }
    }
}