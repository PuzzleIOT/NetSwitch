using System;
using NUnit.Framework;
using duinocom;
using System.Threading;
using ArduinoSerialControllerClient;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.IO.Ports;

namespace NetSwitch.Tests.Integration
{
	[TestFixture(Category = "Integration")]
	public class SwitchCommandTestFixture : BaseTestFixture
	{
		[Test]
		public void Test_SwitchCommand_13()
		{
			using (var helper = new SwitchCommandTestHelper())
			{
				helper.SwitchPin = 13;

				helper.DevicePort = GetDevicePort();
				helper.DeviceBaudRate = GetDeviceSerialBaudRate();

				helper.SimulatorPort = GetSimulatorPort();
				helper.SimulatorBaudRate = GetSimulatorSerialBaudRate();

				helper.TestSwitchCommand();
			}
		}
	}
}
