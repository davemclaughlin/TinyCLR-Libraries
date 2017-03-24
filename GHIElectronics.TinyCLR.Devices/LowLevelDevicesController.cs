﻿using GHIElectronics.TinyCLR.Devices.Adc.Provider;
using GHIElectronics.TinyCLR.Devices.Dac.Provider;
using GHIElectronics.TinyCLR.Devices.Gpio.Provider;
using GHIElectronics.TinyCLR.Devices.I2c.Provider;
using GHIElectronics.TinyCLR.Devices.Pwm.Provider;
using GHIElectronics.TinyCLR.Devices.Spi.Provider;

namespace GHIElectronics.TinyCLR.Devices {
    public sealed class LowLevelDevicesController {
        public static ILowLevelDevicesAggregateProvider DefaultProvider { get; set; } = new LowLevelDevicesAggregateProvider(new DefaultAdcControllerProvider(), new NativeDacControllerProvider(), null, DefaultGpioControllerProvider.Instance, null, null);
    }

    public interface ILowLevelDevicesAggregateProvider {
        IAdcControllerProvider AdcControllerProvider { get; }
        IDacControllerProvider DacControllerProvider { get; }
        IGpioControllerProvider GpioControllerProvider { get; }
        II2cControllerProvider I2cControllerProvider { get; }
        IPwmControllerProvider PwmControllerProvider { get; }
        ISpiControllerProvider SpiControllerProvider { get; }
    }

    public sealed class LowLevelDevicesAggregateProvider : ILowLevelDevicesAggregateProvider {
        public IAdcControllerProvider AdcControllerProvider { get; }
        public IDacControllerProvider DacControllerProvider { get; }
        public IGpioControllerProvider GpioControllerProvider { get; }
        public II2cControllerProvider I2cControllerProvider { get; }
        public IPwmControllerProvider PwmControllerProvider { get; }
        public ISpiControllerProvider SpiControllerProvider { get; }

        public LowLevelDevicesAggregateProvider(IAdcControllerProvider adc, IDacControllerProvider dac, IPwmControllerProvider pwm, IGpioControllerProvider gpio, II2cControllerProvider i2c, ISpiControllerProvider spi) {
            this.AdcControllerProvider = adc;
            this.DacControllerProvider = dac;
            this.PwmControllerProvider = pwm;
            this.GpioControllerProvider = gpio;
            this.I2cControllerProvider = i2c;
            this.SpiControllerProvider = spi;
        }
    }
}
