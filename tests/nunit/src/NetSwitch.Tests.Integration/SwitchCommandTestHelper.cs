using System;
using NUnit.Framework;
namespace NetSwitch.Tests.Integration
{
	public class SwitchCommandTestHelper : NetSwitchHardwareTestHelper
	{
		public int SwitchPin = -1;

		public void TestSwitchCommand()
		{
			WriteTitleText("Starting switch command test");

			EnableDevices();

			TurnSwitch(On);

			TurnSwitch(Off);
		}

		public void TurnSwitch(bool state)
		{
			var pinValue = (state ? 1 : 0);

			var cmd = "D" + SwitchPin + ":" + pinValue;

			SendDeviceCommand(cmd);

			var pinOutputValue = SimulatorClient.DigitalRead(SwitchPin);

			Assert.AreEqual(state, pinOutputValue, "Pin output is incorrect.");
		}
	}
}