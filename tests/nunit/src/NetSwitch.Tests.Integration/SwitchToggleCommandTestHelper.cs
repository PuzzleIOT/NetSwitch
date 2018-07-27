using System;
using NUnit.Framework;
namespace NetSwitch.Tests.Integration
{
	public class SwitchToggleCommandTestHelper : NetSwitchHardwareTestHelper
	{
		public int SwitchPin = -1;

		public bool SwitchState = false;

		public void TestSwitchToggleCommand()
		{
			WriteTitleText("Starting switch toggle command test");

			EnableDevices();

			// On
			ToggleSwitch();

			// Off
			ToggleSwitch();

			// On
			ToggleSwitch();

			// Off
			ToggleSwitch();
		}

		public void ToggleSwitch()
		{
			SwitchState = !SwitchState;

			var cmd = "T" + SwitchPin;

			SendDeviceCommand(cmd);

			var pinOutputValue = SimulatorClient.DigitalRead(SwitchPin);

			Assert.AreEqual(SwitchState, pinOutputValue, "Pin output is incorrect.");
		}
	}
}