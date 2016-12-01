using System;
using GHIElectronics.TinyCLR.Devices.Dac.Provider;

namespace GHIElectronics.TinyCLR.Devices.Dac {
    public sealed class DacController {
        private readonly IDacControllerProvider provider;
        private static DacController instance;

        internal DacController(IDacControllerProvider provider) {
            this.provider = provider;
        }

        public int ChannelCount => provider.ChannelCount;
        public int ResolutionInBits => provider.ResolutionInBits;
        public int MinValue => provider.MinValue;
        public int MaxValue => provider.MaxValue;

        public static DacController GetDefault() => DacController.instance ?? (DacController.instance = new DacController(new NativeDacControllerProvider()));

        public static DacController[] GetControllers(IDacProvider provider) {
            var providers = provider.GetControllers();
            var controllers = new DacController[providers.Length];

            for (var i = 0; i < providers.Length; ++i)
                controllers[i] = new DacController(providers[i]);

            return controllers;
        }

        public DacChannel OpenChannel(int channel) {
            if (channel < 0 || channel >= provider.ChannelCount) throw new ArgumentOutOfRangeException();

            return new DacChannel(this, provider, channel);
        }
    }
}